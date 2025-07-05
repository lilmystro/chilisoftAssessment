
using UserMenu.Models;
using UserMenu.Utils;

namespace UserMenu.Presentation
{
    public class App : IApp
    {
        private readonly IModelBuilder _modelBuilder;
        private readonly IFileReader _fileReader;
        private readonly IJsonWriter _jsonWriter;

        public App(IModelBuilder modelBuilder, IFileReader fileReader, IJsonWriter jsonWriter)
        {
            _modelBuilder = modelBuilder;
            _fileReader = fileReader;
            _jsonWriter = jsonWriter;
        }
        public void GenerateUserMenuPermissions(string[] args)
        {
            string[] rawMenuItems;
            string[] rawUsers;

            (rawUsers, rawMenuItems) = _fileReader.ReadLinesFromFile(args);
            
            List<MenuItem> menuItems = _modelBuilder.GetMenuItems(rawMenuItems);
            List<User> users = _modelBuilder.GetUsers(rawUsers, menuItems);
            _jsonWriter.WriteToJson(users);
        }
    }
}
