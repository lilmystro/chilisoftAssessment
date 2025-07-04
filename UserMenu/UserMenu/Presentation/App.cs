
using UserMenu.Models;
using UserMenu.Utils;

namespace UserMenu.Presentation
{
    public class App
    {
        public static void GenerateUserMenuPermissions(string[] args)
        {
            // Declare variables
            string[] rawMenuItems;
            string[] rawUsers;

            (rawUsers, rawMenuItems) = FileReader.ReadLinesFromFile(args);

            List<MenuItem> menuItems = ModelBuilder.GetMenuItems(rawMenuItems);
            List<User> users = ModelBuilder.GetUsers(rawUsers, menuItems);
            JsonWriter.WriteToJson(users);
        }
    }
}
