using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyContabilidad.DataPersistence.Mappings;
using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            
        }
        
        public MyDbContext()
        {
            
        }

        internal DbSet<Categoria> Categorias { get; set; }
        internal DbSet<CentroCosto> CentrosCostos { get; set; }
        internal DbSet<Cuenta> CuentasContables { get; set; }
        internal DbSet<Ejercicio> EjerciciosContables { get; set; }
        internal DbSet<Secuencial> Secuenciales { get; set; }
        internal DbSet<Periodo> Periodos { get; set; }
        internal DbSet<TipoAsiento> TiposAsientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Adding User Secret service to read the appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<MyDbContext>()
                .Build();

            // Getting the oracle connection string settings
            var connectionString = configuration.GetConnectionString("Oracle");
            
            optionsBuilder.UseOracle(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new CentroCostoMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new PeriodoMap());
            modelBuilder.ApplyConfiguration(new SecuencialMap());
            modelBuilder.ApplyConfiguration(new TipoAsientoMap());
        }
    }
}