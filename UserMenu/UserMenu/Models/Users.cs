
namespace UserMenu.Models
{
    public class Users
    {
        public User[] users { get; set; }

        public Users(List<User> userList)
        {
            users = userList.ToArray();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, users.Select(u => u.ToString()));
        }
    }
}
