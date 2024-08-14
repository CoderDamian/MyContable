using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class PeriodoRepository : IPeriodoRepository
    {
        private readonly MyDbContext _myDbContext;

        public PeriodoRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }

        public async Task Add_Async(string nombre, DateTime fechaInicial, short numeroPeriodos, char longitud, string userName)
        {
            var p_nombre = new OracleParameter("p_nombre", OracleDbType.NVarchar2, nombre, ParameterDirection.Input);
            var p_fecha_inicial = new OracleParameter("p_fecha_inicial", OracleDbType.Date, fechaInicial, ParameterDirection.Input);
            var p_numero_periodos = new OracleParameter("p_numero_periodos", OracleDbType.Int16, numeroPeriodos, ParameterDirection.Input);
            var p_longitud_periodo = new OracleParameter("p_longitud_periodo", OracleDbType.NVarchar2, longitud, ParameterDirection.Input);
            var p_created_by = new OracleParameter("p_created_by", OracleDbType.NVarchar2, userName, ParameterDirection.Input);

            await this._myDbContext.Database.ExecuteSqlRawAsync("BEGIN ctb_periodo_pkg.ins_new_periodo (:p_nombre, :p_fecha_inicial, :p_numero_periodos, :p_longitud_periodo, :p_created_by); END;", p_nombre, p_fecha_inicial, p_numero_periodos, p_longitud_periodo, p_longitud_periodo, p_created_by).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ListPeriodoDTO>> Get_All_Async()
        {
            Collection<ListPeriodoDTO> periodos = new Collection<ListPeriodoDTO>();
            
            string connectionString = this._myDbContext.Database.GetConnectionString() ?? String.Empty;

            using (var connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                using (var command = new OracleCommand("ctb_periodo_pkg.get_all", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_result", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                    using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            periodos.Add(new ListPeriodoDTO()
                            {
                                Id = reader.GetInt32("id"),
                                NombreEjercicioContable = reader.GetString("nombre_ejercicio"),
                                NombrePeriodo = reader.GetString("nombre_periodo"),
                                FechaInicial = reader.GetDateTime("fecha_inicial"),
                                FechaFinal = reader.GetDateTime("fecha_final"),
                                EsCerrado = reader.GetBoolean("es_cerrado")
                            });
                        }
                    }
                }

                await connection.CloseAsync().ConfigureAwait(false);

                return periodos;
            }
        }
    }
}
