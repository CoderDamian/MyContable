namespace MyDTO.MyContabilidad
{
    public record class UpdateTipoAsientoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
        public bool EsActiva { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? LastUpdatedDate { get; set; }
    }
}