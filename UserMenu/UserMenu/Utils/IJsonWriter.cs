
using UserMenu.Models;

namespace UserMenu.Utils
{
    public interface IJsonWriter
    {
        void WriteToJson(List<User> users);
    }
}
