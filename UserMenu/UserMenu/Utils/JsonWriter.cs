
using System.Text.Json;
using UserMenu.Models;

namespace UserMenu.Utils
{
    public class JsonWriter : IJsonWriter
    {
        private readonly IConsoleJsonSerializer _consoleJsonSerializer;

        public JsonWriter(IConsoleJsonSerializer consoleJsonSerializer)
        {
            _consoleJsonSerializer = consoleJsonSerializer;
        }

        public void WriteToJson(List<User> users)
        {
            var userList = new Users(users);

            var json = _consoleJsonSerializer.Serialize(userList);

            Console.WriteLine(json);
        }
    }
}
