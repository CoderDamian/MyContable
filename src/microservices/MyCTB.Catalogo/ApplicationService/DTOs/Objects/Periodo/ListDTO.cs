namespace MyDTO.MyContabilidad
{
    public readonly record struct ListPeriodoDTO
    {
        public int Id { get; init; }
        public string Nombre_Ejercicio_Contable { get; init; }
        public string Nombre_Periodo { get; init; }
        public DateTime Fecha_Inicial { get; init; }
        public DateTime Fecha_Final { get; init; }
        public bool EsCerrado { get; init; }
    }
}