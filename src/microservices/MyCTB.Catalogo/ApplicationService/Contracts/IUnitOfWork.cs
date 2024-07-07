namespace MyCTB.Catalogo.ApplicationService
{
    internal interface IUnitOfWork
    {
        internal ICuentaRepository CuentaRepository { get; }
        
        internal ICentroCostoRepository CentroCostoRepository { get; }
        
        internal IEjercicioRepository EjercicioRepository { get; }
        
        internal ISecuencialRepository SecuencialRepository { get; }
        
        internal ITipoAsientoRepository TipoAsientoRepository { get; }
        
        internal IPeriodoRepository PeriodoRepository { get; }

        internal Task Save_Async();
    }
}