namespace MyDTO.MyContabilidad
{
    public readonly record struct ListCentrosCostosDTO
    {
        public int Id { get; init; }
        public int Nivel { get; init; }
        public string Nombre { get; init; }
        public bool EsAuxiliar { get; init; }
    }
}
