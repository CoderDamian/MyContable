namespace MyDTO.MyContabilidad
{
    public record class AddSecuencialDTO
    {
        public int PeriodoFk { get; set; }
        public int TipoAsientoFk { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}