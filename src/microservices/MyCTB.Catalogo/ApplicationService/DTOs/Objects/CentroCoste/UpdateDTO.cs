namespace MyDTO.MyContabilidad
{
    public record class UpdateCentroCostoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string User_Name { get; set; } = string.Empty;
        public DateTime? Last_Updated_Date { get; set; }
    }
}
