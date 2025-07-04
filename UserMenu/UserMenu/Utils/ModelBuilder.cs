
using UserMenu.Models;

namespace UserMenu.Utils
{
    public class ModelBuilder
    {
        public static List<MenuItem> GetMenuItems(string[] rawMenuItems)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            try
            {
                foreach (string item in rawMenuItems)
                {
                    string[] parts = item.Split(',');

                    if (parts.Length != 2)
                    {
                        throw new ArgumentException($"wrong format: '{item}'. Expected format: <int>,<name>");
                    }

                    if (!int.TryParse(parts[0], out int id))
                    {
                        throw new ArgumentException($"Invalid ID '{parts[0]}' in line: '{item}'. ID should be an integer.");
                    }

                    if (string.IsNullOrWhiteSpace(parts[1]))
                    {
                        throw new ArgumentException($"Invalid name '{parts[1]}' in line: '{item}'. Name should not be empty.");
                    }

                    menuItems.Add(new MenuItem(id, parts[1].Trim()));
                }

                if (menuItems.Count == 0)
                {
                    throw new ArgumentException("No valid menu items found in the provided data.");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error processing menu items: " + e.Message);
            }

            return menuItems;
        }

        public static List<User> GetUsers(string[] rawUsers, List<MenuItem> menuItems)
        {
            List<User> users = new List<User>();
            try
            {
                foreach (string user in rawUsers)
                {
                    string[] parts = user.Split(' ');
                    string permissions = "";
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (!(parts[1].Trim().All(c => char.ToLowerInvariant(c) == 'y' || char.ToLowerInvariant(c) == 'n')))
                        {
                            throw new ArgumentException($"Invalid permissions format: '{user}'. Permissions should be either a 'y' or a 'n' ");
                        }
                        permissions += parts[i].Trim();
                    }
                    
                    users.Add(new User(parts[0], GetUserPermissionIndices(permissions, menuItems)));
                }

                if (users.Count == 0)
                {
                    throw new ArgumentException("No valid users found in the provided data.");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error processing user permissions: " + e.Message);
            }
            
            return users;
        }

        public static string[] GetUserPermissionIndices(string permissions, List<MenuItem> menuItems)
        {
            permissions = new string(permissions.Where(c => !char.IsWhiteSpace(c)).ToArray());

            if (permissions.Length != menuItems.Count)
            {
                throw new ArgumentException($"Invalid permissions length: '{permissions}'. Expected length should be the same as the number of many items: {menuItems.Count}");
            }

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
