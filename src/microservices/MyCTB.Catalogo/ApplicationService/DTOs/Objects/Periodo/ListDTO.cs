namespace MyDTO.MyContabilidad
{
    public readonly record struct ListPeriodoDTO
    {
        public int Id { get; init; }
        public string NombreEjercicioContable { get; init; }
        public string NombrePeriodo { get; init; }
        public DateTime FechaInicial { get; init; }
        public DateTime FechaFinal { get; init; }
        public bool EsCerrado { get; init; }
    }
}