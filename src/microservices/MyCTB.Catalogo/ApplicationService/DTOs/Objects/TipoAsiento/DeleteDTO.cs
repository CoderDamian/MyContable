namespace MyDTO.MyContabilidad
{
    public readonly record struct DeleteTipoAsientoDTO
    {
        public string UserName { get; init; }
        public DateTime? LastUpdatedDate { get; init; }
    }
}