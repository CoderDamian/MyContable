//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyCTB.Catalogo.DataPersistence;
using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.WebServices
{
    public static class ServiceExtension
    {
        public static void Add_MyDataAccess(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICuentaRepository, CuentaRepository>();

            services.AddDbContext<MyDbContext>();
        }

        public static void Add_CQRS(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(PlanCuentasListHandler).Assembly);
            });
        }

        /// <summary>
        /// Add the authentication service by specifying the JWT bearer scheme
        /// </summary>
        /// <remarks>The domain and audience values are getting from the appsettings.json configuration file</remarks>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Add_Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(opt =>
            //{
            //    opt.Authority = $"https://{configuration["Auth0:Domain"]}/";
            //    opt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidAudience = configuration["Auth0:Audience"],
            //        ValidIssuer = $"{configuration["Auth0.Domain"]}",
            //        ValidateLifetime = true
            //    };
            //});
        }

        public static void Add_Mappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TipoAsientoProfile));
        }

        public static void Add_API_Documentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });


                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Using the Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                { securitySchema, new[] { "Bearer" } }
                });

            });
        }
    }
}
