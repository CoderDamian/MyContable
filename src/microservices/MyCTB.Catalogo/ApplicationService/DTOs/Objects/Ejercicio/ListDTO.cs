namespace MyDTO.MyContabilidad
{
    public readonly record struct ListEjercicioDTO
    {
        public int Id { get; init; }
        public string Nombre { get; init; }
        public bool Es_Cerrado { get; init; }
    }
}
