namespace MyDTO.MyContabilidad
{
    public record class UpdateCentroCostoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime? LastUpdatedDate { get; set; }
    }
}
