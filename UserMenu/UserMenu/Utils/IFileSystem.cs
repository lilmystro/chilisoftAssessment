
namespace UserMenu.Utils

{
    public interface IFileSystem
    {
        bool Exists(string path);

        string[] ReadAllLines(string path);
    }
}
