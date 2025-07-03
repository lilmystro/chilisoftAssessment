namespace UserMenu.Models
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // menu service constructor
        public MenuItem(int menuId, string menuName)
        {
            ID = menuId;
            Name = menuName;
        }

        public override string ToString()
        {
            return $"{ID}: {Name}";
        }
    }
}
