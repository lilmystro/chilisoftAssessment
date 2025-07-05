
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
            Users userList = new Users(users);

            // Convert the list of users to JSON format
            string json = _consoleJsonSerializer.Serialize(userList);

            // write json string to Console
            Console.WriteLine(json);
        }
    }
}
