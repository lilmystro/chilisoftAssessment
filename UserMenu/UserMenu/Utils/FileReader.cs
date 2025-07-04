
namespace UserMenu.Utils
{
    public class FileReader: IFileReader
    {
        private readonly IFileSystem _fileSystem;

        public FileReader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public (string[], string[]) ReadLinesFromFile(string[] args)
        {
            try
            {
                if (args.Length != 2)
                    throw new ArgumentException("Please provide paths to both the menu file and the users file");

                if (!(args[0].Contains("users.txt")))
                    throw new ArgumentException("The first argument must be the path to the users file");

                if (!(args[1].Contains("menus.txt")))
                    throw new ArgumentException("The second argument must be the path to the menus file");

                if (!_fileSystem.Exists(args[0]) || !_fileSystem.Exists(args[1]))
                    throw new ArgumentException("One or both of the specified files do not exist or have the wrong path");

                return (_fileSystem.ReadAllLines(args[0]), _fileSystem.ReadAllLines(args[1]));
            }
            catch (Exception e)
            {
                throw new Exception("Error reading files: " + e.Message);
            }

        }
    }
}
