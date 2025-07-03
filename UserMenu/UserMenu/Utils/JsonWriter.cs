
using UserMenu.Models;

namespace UserMenu.Utils
{
    public class JsonWriter
    {
        public static void WriteToJson(List<User> users, string filePath)
        {
            Users userList = new Users(users);

            // Convert the list of users to JSON format
            string json = System.Text.Json.JsonSerializer.Serialize(userList, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            // Write the JSON to a file
            //File.WriteAllText(filePath, json);

            // write json string to Console
            Console.WriteLine(json);
        }
    }
}
