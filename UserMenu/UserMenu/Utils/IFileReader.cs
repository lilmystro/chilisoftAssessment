
namespace UserMenu.Utils
{
    public interface IFileReader
    {
        (string[], string[]) ReadLinesFromFile(string[] args);
    }
}
