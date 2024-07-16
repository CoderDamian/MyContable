namespace MyDTO.MyContabilidad
{
    public record class AddCentroCostoDTO
    {
        public int PadreId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}