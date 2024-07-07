namespace MyDTO.MyContabilidad
{
    /// <summary>
    /// 
    /// </summary>
    public record class AddAsientoContableDTO
    {
        public DateTime Fecha { get; set; }
        public string Glosa { get; set; } = string.Empty;
        public int Tipo_Asiento_ID { get; set; }
        public IList<PartidaDTO> Partidas_DTO { get; set; }
        public string User_Name { get; set; } = string.Empty;

        public AddAsientoContableDTO()
        {
            this.Partidas_DTO = new List<PartidaDTO>();
        }
    }
}