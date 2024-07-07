namespace MyDTO.MyContabilidad
{
    public record class PartidaDTO
    {
        public int Orden { get; set; }
        public int Centro_Costo_ID { get; set; }
        public int Codigo_Contable_ID { get; set; }
        public string Codigo_Contable { get; set; } = string.Empty;
        public string Glosa { get; set; } = string.Empty;
        public double Debe { get; set; }
        public double Haber { get; set; }
    }
}