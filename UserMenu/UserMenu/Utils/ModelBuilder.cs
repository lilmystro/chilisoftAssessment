
using UserMenu.Models;

namespace UserMenu.Utils
{
    public class ModelBuilder
    {
        public static List<MenuItem> GetMenuItems(string[] rawMenuItems)
        {
            // Create a list of menu items
            List<MenuItem> menuItems = new List<MenuItem>();
            // Populate the list with menu items from the rawMenuItems array
            foreach (string item in rawMenuItems)
            {
                string[] parts = item.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int id))
                {
                    menuItems.Add(new MenuItem(id, parts[1].Trim()));
                }
            }
            return menuItems;
        }

        public static List<User> GetUsers(string[] rawUsers, List<MenuItem> menuItems)
        {
            // Create a list of users
            List<User> users = new List<User>();
            // Populate the list with users from the rawUsers array
            foreach (string user in rawUsers)
            {
                string[] parts = user.Split(' ');
                string permissions = "";
                for (int i = 1; i < parts.Length; i++)
                {
                    permissions += parts[i].Trim();
                }

                users.Add(new User(parts[0], GetUserPermissionIndices(permissions, menuItems)));
            }
            return users;
        }

        public static string[] GetUserPermissionIndices(string permissions, List<MenuItem> menuItems)
        {
            permissions = new string(permissions.Where(c => !char.IsWhiteSpace(c)).ToArray());

            List<string> enabledIPermissions = new List<string>();
            for (int i = 0; i < permissions.Length; i++)
            {
                if (char.ToUpperInvariant(permissions[i]) == 'Y')
                {
                    var menu = menuItems.FirstOrDefault(m => m.ID == i + 1);
                    if (menu != null)
                    {
                        enabledIPermissions.Add(menu.Name);
                    }
                }
            }

            return enabledIPermissions.ToArray();
        }
    } 
}
