namespace MyDTO.MyContabilidad
{
    public record class AddSecuencialDTO
    {
        public int Periodo_Fk { get; set; }
        public int TipoAsiento_Fk { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}