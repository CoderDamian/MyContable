namespace MyDTO.MyContabilidad
{
    public record class PartidaDTO
    {
        public int Orden { get; set; }
        public int CentroCostoID { get; set; }
        public int CodigoContableID { get; set; }
        public string CodigoContable { get; set; } = string.Empty;
        public string Glosa { get; set; } = string.Empty;
        public double Debe { get; set; }
        public double Haber { get; set; }
    }
}