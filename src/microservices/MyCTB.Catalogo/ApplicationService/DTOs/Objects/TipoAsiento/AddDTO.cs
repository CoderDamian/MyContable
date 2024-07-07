namespace MyDTO.MyContabilidad
{
    public record class AddTipoAsientoDTO
    {
        public string Descripcion { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}