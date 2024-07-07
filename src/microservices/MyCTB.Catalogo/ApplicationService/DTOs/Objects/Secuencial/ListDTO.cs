namespace MyDTO.MyContabilidad
{
    public readonly record struct ListSecuencialDTO
    {
        public string Nombre_Ejercicio_Contable { get; init; }
        public string Nombre_Periodo { get; init; }
        public DateTime Fecha_Inicial_Periodo { get; init; }
        public DateTime Fecha_Final_Periodo { get; init; }
        public string Tipo_Asiento { get; init; }
        public int Secuencial { get; init; }
    }
}