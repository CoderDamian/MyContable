using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyCTB.Catalogo.BusinessDomain;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class TipoAsientoRepository : ITipoAsientoRepository
    {
        private readonly MyDbContext _myDbContext;

        public TipoAsientoRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task Add_Async(TipoAsiento tipoAsientoContable)
        {
            await this._myDbContext.TiposAsientos
                .AddAsync(tipoAsientoContable)
                .ConfigureAwait(false);
        }

        public async Task<int> Delete_Async(int id, string updatedBy, DateTime? concurrency_token)
        {
            var p_tipo_asiento_id = new OracleParameter("p_tipo_asiento_id", OracleDbType.Int32, id, ParameterDirection.Input);
            var p_updated_by = new OracleParameter("p_updated_by", OracleDbType.NVarchar2, updatedBy, ParameterDirection.Input);
            var p_concurrency_token = new OracleParameter("p_concurrency_token", OracleDbType.TimeStamp, concurrency_token, ParameterDirection.Input);
            var p_rows_affected = new OracleParameter("p_rows_affected", OracleDbType.Int32, ParameterDirection.Output);

            await this._myDbContext.Database
                .ExecuteSqlRawAsync("BEGIN ctb_tipo_asiento_pkg.delete_by_id(:p_tipo_asiento_id, :p_updated_by, :p_concurrency_token, :p_rows_affected); END;", p_tipo_asiento_id, p_updated_by, p_concurrency_token, p_rows_affected)
                .ConfigureAwait(false);

            return Convert.ToInt32(p_rows_affected.Value.ToString());
        }

        public async Task<IEnumerable<TipoAsiento>> Get_All_Async(int skip, int take)
        {
            return await this._myDbContext.TiposAsientos
                .OrderBy(t => t.Nombre)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TipoAsiento?> Get_By_Id_Async(int id)
        {
            return await this._myDbContext.TiposAsientos
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public void Update(TipoAsiento tipoAsiento)
        {
            this._myDbContext.Attach(tipoAsiento);
            this._myDbContext.Entry(tipoAsiento).Property(p => p.Nombre).IsModified = true;
            this._myDbContext.Entry(tipoAsiento).Property(p => p.Abreviatura).IsModified = true;
            this._myDbContext.Entry(tipoAsiento).Property(p => p.EsActiva).IsModified = true;
        }
    }
}
