namespace MyDTO.MyContabilidad
{
    public readonly record struct ListTiposAsientoDTO
    {
        public int Id { get; init; }
        public string Nombre { get; init; }
        public string Abreviatura { get; init; }
        public bool EsActiva{ get; init; }
    }
}