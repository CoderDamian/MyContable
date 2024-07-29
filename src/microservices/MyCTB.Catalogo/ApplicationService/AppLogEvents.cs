using Microsoft.Extensions.Logging;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Define los identificadores de evento
    /// </summary>
    internal static class AppLogEvents
    {
        internal static EventId Create = new (4000, "Error trying to insert a record in database");
        internal static EventId Delete = new(1003, "Deleted");
        internal static EventId Read = new(1001, "Read");
        internal static EventId ReadNotFound = new(4000, "Read not found");
        internal static EventId Update = new(1002, "Updated");
    }
}
