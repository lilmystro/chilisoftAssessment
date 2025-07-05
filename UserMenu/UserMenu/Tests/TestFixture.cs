using NSubstitute;
using UserMenu.Presentation;
using UserMenu.Utils;

namespace UserMenu.Tests
{
    public class TestFixture
    {
        public IFileSystem FileSystem { get; }
        public IFileReader FileReader { get; }
        public IModelBuilder ModelBuilder { get; }
        public IConsoleJsonSerializer ConsoleJsonSerializer { get; }
        public IJsonWriter JsonWriter { get; }
        public IApp App { get; }

        public string[] DefaultUsers => new[] { "user1 YNY", "user2 YNN" };
        public string[] DefaultMenus => new[] { "1, Menu1", "2, Menu2", "3, Menu3" };
        public string[] Args => new[] { "users.txt", "menus.txt" };

        public TestFixture()
        {
            FileSystem = Substitute.For<IFileSystem>();
            FileSystem.Exists(Arg.Any<string>()).Returns(true);
            FileSystem.ReadAllLines("users.txt").Returns(DefaultUsers);
            FileSystem.ReadAllLines("menus.txt").Returns(DefaultMenus);

            FileReader = new FileReader(FileSystem);
            ModelBuilder = new ModelBuilder();

            ConsoleJsonSerializer = Substitute.For<IConsoleJsonSerializer>();
            ConsoleJsonSerializer.Serialize(Arg.Any<object>()).Returns("Serialized JSON");

            JsonWriter = new JsonWriter(ConsoleJsonSerializer);

            App = new App(ModelBuilder, FileReader, JsonWriter);
        }
    }
}
