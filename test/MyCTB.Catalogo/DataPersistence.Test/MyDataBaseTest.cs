using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyCTB.Catalogo.BusinessDomain;
using MyCTB.Catalogo.DataPersistence;

namespace DataPersistence.Test
{
    public class MyDataBaseTest
    {
        [Fact]
        public void Be_Valid_Categoria_Map()
        {
            using var myDbContext = new MyDbContext();
            
            var categorias = myDbContext.Categorias.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase CategoriaMap esta correcto
            Assert.NotNull(categorias);
        }

        [Fact]
        public void Be_Valid_Centro_Costo_Map()
        {
            using var myDbContext = new MyDbContext();
            
            IEntityType? entity = myDbContext.Model.FindEntityType(typeof(CentroCosto));

            var centros = myDbContext.CentrosCostos.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase CentroCostoMap esta correcto
            Assert.NotNull(centros);
        }

        [Fact]
        public void Be_Valid_Conection_To_DataBase()
        {
            using var myDbContext = new MyDbContext();

            try
            {
                myDbContext.Database.OpenConnection();
                myDbContext.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se pudo conectar a la base de datos: {ex.Message}");
            }
        }

        [Fact]
        public void Be_Valid_Cuenta_Map()
        {
            using var myDbContext = new MyDbContext();
            
            var cuentas = myDbContext.CuentasContables.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase CuentasMap esta correcto
            Assert.NotNull(cuentas);
        }

        [Fact]
        public void Be_Valid_Ejercicio_Map()
        {
            using var myDbContext = new MyDbContext();
            
            var ejercicios = myDbContext.EjerciciosContables.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase CuentasMap esta correcto
            Assert.NotNull(ejercicios);
        }

        [Fact]
        public void Be_Valid_Periodo_Map()
        {
            using var myDbContext = new MyDbContext();

            var periodos = myDbContext.Periodos.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase PeriodosMap esta correcto
            Assert.NotNull(periodos);
        }

        [Fact]
        public void Be_Valid_Secuencial_Map()
        {
            using var myDbContext = new MyDbContext();

            var secuenciales = myDbContext.Secuenciales.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase SecuencialesMap esta correcto
            Assert.NotNull(secuenciales);
        }

        [Fact]
        public void Be_Valid_Tipo_Asiento_Map()
        {
            using var myDbContext = new MyDbContext();

            var tiposAsientos = myDbContext.TiposAsientos.ToList();

            // si los registros son recuperados, entonces el mapeo de la clase TipoAsientosMap esta correcto
            Assert.NotNull(tiposAsientos);
        }
    }
}
