namespace UserMenu.Models
{
    public class User
    {
        public string userName { get; set; }
        public string[] menuItems { get; set; }

        public User(string name, string[] permissionIndices)
        {
            userName = name;
            menuItems = permissionIndices;
        }

        public override string ToString()
        {
            return $"{userName}: {string.Join(",", menuItems)}";
        }
    }
}
