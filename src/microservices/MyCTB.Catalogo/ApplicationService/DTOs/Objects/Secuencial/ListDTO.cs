namespace MyDTO.MyContabilidad
{
    public readonly record struct ListSecuencialDTO
    {
        public string NombreEjercicioContable { get; init; }
        public string NombrePeriodo { get; init; }
        public DateTime FechaInicialPeriodo { get; init; }
        public DateTime FechaFinalPeriodo { get; init; }
        public string TipoAsiento { get; init; }
        public int Secuencial { get; init; }
    }
}