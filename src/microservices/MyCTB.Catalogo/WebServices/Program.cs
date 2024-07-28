using MyCTB.Catalogo.WebServices;
using Serilog;

// log errors during the web application start-up.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("starting web application ...");

try
{
    var builder = WebApplication.CreateBuilder(args);   // start-up the web application

    // redirect log events through the serilog pipeline and replace the initial "CreateBootstrapLogger" logger
    builder.Services.AddSerilog((services, lc) => lc
       .ReadFrom.Configuration(builder.Configuration) // configure serilog from appsettings.json
       .WriteTo.Console()); // sink console that log events will be emitted to

    // add services to the container
    builder.Services.Add_MyDataAccess();
    builder.Services.Add_CQRS();
    builder.Services.Add_Mappings();
    builder.Services.Add_Authentication(builder.Configuration);
    builder.Services.Add_API_Documentation();

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "application terminated unexpectedly !!!");
}
finally
{
    await Log.CloseAndFlushAsync();
}
