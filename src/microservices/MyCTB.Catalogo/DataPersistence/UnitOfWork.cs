using MyCTB.Catalogo.ApplicationService;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private MyDbContext _myDbContext;
        private ICuentaRepository? _cuentaContableRepository;
        private ICentroCostoRepository? _centroCostoRepository;
        private IEjercicioRepository? _ejercicioRepository;
        private IPeriodoRepository? _periodoRepository;
        private ISecuencialRepository? _secuencialRepository;
        private ITipoAsientoRepository? _tipoAsientoRepository;

        public UnitOfWork(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext ?? throw new ArgumentNullException(MyMessages.dbcontext_not_be_null);
        }

        public ICentroCostoRepository CentroCostoRepository
        {
            get
            {
                if (this._centroCostoRepository == null)
                    this._centroCostoRepository = new CentroCostoRepository(this._myDbContext);

                return this._centroCostoRepository;
            }
        }

        public ICuentaRepository CuentaRepository
        {
            get
            {
                if (this._cuentaContableRepository is null)
                    this._cuentaContableRepository = new CuentaRepository(this._myDbContext);

                return this._cuentaContableRepository;
            }
        }

        public IEjercicioRepository EjercicioRepository
        {
            get
            {
                if (this._ejercicioRepository is null)
                    this._ejercicioRepository = new EjercicioRepository(this._myDbContext);

                return this._ejercicioRepository;
            }
        }

        public IPeriodoRepository PeriodoRepository
        {
            get
            {
                if (this._periodoRepository is null)
                    this._periodoRepository = new PeriodoRepository(this._myDbContext);

                return this._periodoRepository;
            }
        }

        public ISecuencialRepository SecuencialRepository
        {
            get
            {
                if (this._secuencialRepository is null)
                    this._secuencialRepository = new SecuencialRepository(this._myDbContext);

                return this._secuencialRepository;
            }
        }

        public ITipoAsientoRepository TipoAsientoRepository
        {
            get
            {
                if (this._tipoAsientoRepository is null)
                    this._tipoAsientoRepository = new TipoAsientoRepository(this._myDbContext);

                return this._tipoAsientoRepository;
            }
        }

        public async Task Save_Async()
        {
            await _myDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
