using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class SecuencialRepository : ISecuencialRepository
    {
        private readonly MyDbContext _myDbContext;

        public SecuencialRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task Add_Async(Secuencial secuencial)
        {
            await this._myDbContext.Secuenciales
                .AddAsync(secuencial)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<ListSecuencialDTO>> Gell_All_Async()
        {
            using OracleConnection oracleConnection = new(this._myDbContext.Database.GetDbConnection().ConnectionString);

            // Setting the procedure
            using OracleCommand command = new("periodo_tipo_asiento_pkg.list_sequences", oracleConnection);
            command.CommandType = CommandType.StoredProcedure;

            // Setting the parameters
            command.Parameters.Add("p_result", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            await oracleConnection.OpenAsync().ConfigureAwait(false);

            DbDataReader dataReader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            Collection<ListSecuencialDTO> secuencialesDTOs = new Collection<ListSecuencialDTO>();

            while (await dataReader.ReadAsync().ConfigureAwait(false))
            {
                secuencialesDTOs.Add(new ListSecuencialDTO()
                {
                    NombreEjercicioContable = dataReader.GetString(0),
                    NombrePeriodo = dataReader.GetString(1),
                    FechaInicialPeriodo = dataReader.GetDateTime(2),
                    FechaFinalPeriodo = dataReader.GetDateTime(3),
                    TipoAsiento = dataReader.GetString(4),
                    Secuencial = dataReader.GetInt32(5)
                });
            }

            await dataReader.CloseAsync().ConfigureAwait(false);

            await oracleConnection.CloseAsync().ConfigureAwait(false);

            return secuencialesDTOs;
        }
    }
}