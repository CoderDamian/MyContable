using MyCTB.Catalogo.WebServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
