namespace MyDTO.MyContabilidad
{
    public readonly record struct PlanCuentasDTO
    {
        public int Id { get; init; }
        public string NombreCategoria { get; init; }
        public string CodigoContable { get; init; }
        public string Nombre { get; init; }

    }
}
