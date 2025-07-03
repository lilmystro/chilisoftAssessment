
using UserMenu.Models;
using UserMenu.Utils;

namespace UserMenu.Presentation
{
    public class App
    {
        public static void GenerateUserMenuPermissions(string[] args)
        {
            // Get input from menu.txt file in TextInput folder
            string[] rawMenuItems = File.ReadAllLines("C:\\Users\\Jonathan\\Documents\\Job Offers\\Chilisoft\\Chillisoft-ProblemSolvingAssessment-MenuPermissions\\menus.txt");
            string[] rawUsers = File.ReadAllLines("C:\\Users\\Jonathan\\Documents\\Job Offers\\Chilisoft\\Chillisoft-ProblemSolvingAssessment-MenuPermissions\\users.txt");


            List<MenuItem> menuItems = ModelBuilder.GetMenuItems(rawMenuItems);
            List<User> users = ModelBuilder.GetUsers(rawUsers, menuItems);
            JsonWriter.WriteToJson(users, "");
        }
    }
}
