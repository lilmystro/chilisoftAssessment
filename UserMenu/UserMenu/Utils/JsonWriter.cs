
using UserMenu.Models;

namespace UserMenu.Utils
{
    public class JsonWriter
    {
        public static void WriteToJson(List<User> users)
        {
            Users userList = new Users(users);

            // Convert the list of users to JSON format
            string json = System.Text.Json.JsonSerializer.Serialize(userList, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
          
            // write json string to Console
            Console.WriteLine(json);
        }
    }
}
