
using UserMenu.Models;

namespace UserMenu.Utils
{
    public interface IModelBuilder
    {
        List<MenuItem> GetMenuItems(string[] rawMenuItems);

        List<User> GetUsers(string[] rawUsers, List<MenuItem> menuItems);
    }
}
