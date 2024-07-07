namespace MyDTO.MyContabilidad
{
    //https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    //https://www.youtube.com/watch?v=-imbCoyINwA&ab_channel=PlainConcepts
    public record class AddPeriodoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicial { get; set; } = DateTime.Today;
        public Int16 NumeroPeridos { get; set; }
        public char Longitud { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}