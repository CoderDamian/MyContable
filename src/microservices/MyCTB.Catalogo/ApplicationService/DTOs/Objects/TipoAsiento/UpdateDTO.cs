namespace MyDTO.MyContabilidad
{
    public record class UpdateTipoAsientoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
        public bool Es_Activa { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public DateTime? Last_Updated_Date { get; set; }
    }
}