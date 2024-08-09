namespace MyDTO.MyContabilidad
{
    /// <summary>
    /// 
    /// </summary>
    public record class AddAsientoContableDTO
    {
        public DateTime Fecha { get; set; }
        public string Glosa { get; set; } = string.Empty;
        public int TipoAsientoID { get; set; }
        public IList<PartidaDTO> PartidasDTO { get; set; }
        public string UserName { get; set; } = string.Empty;

        public AddAsientoContableDTO()
        {
            this.PartidasDTO = new List<PartidaDTO>();
        }
    }
}