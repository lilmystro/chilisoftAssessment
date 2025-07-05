
using System.Text.Json;

namespace UserMenu.Utils
{
    public class ConsoleJsonSerializer : IConsoleJsonSerializer
    {
        public string Serialize(object packet) => JsonSerializer.Serialize(packet, new JsonSerializerOptions { WriteIndented = true });
    }
}
