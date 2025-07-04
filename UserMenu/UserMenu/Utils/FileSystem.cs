
namespace UserMenu.Utils
{
    public class FileSystem : IFileSystem
    {
        public bool Exists(string path) => File.Exists(path);

        public string[] ReadAllLines(string path) => File.ReadAllLines(path);
    }
}
