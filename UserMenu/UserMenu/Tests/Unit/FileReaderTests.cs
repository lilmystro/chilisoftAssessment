
using NSubstitute;
using NUnit.Framework;
using UserMenu.Utils;

namespace UserMenu.Tests.Unit
{
    [TestFixture]
    public class FileReaderTests
    {
        [TestCase("users.txt", "menus.txt", "menus.txt")]
        [TestCase("users.txt")]
        public void GivenIncorrectNumberOfArguments_WhenReadingLinesFromFile_ShouldThrowException(params string[] args)
        {
            // Arrange
            var mockFileSystem = Substitute.For<IFileSystem>();
            mockFileSystem.Exists(Arg.Any<string>()).Returns(false);
            var reader = new FileReader(mockFileSystem);

            // Act
            var ex = Assert.Throws<Exception>(() => reader.ReadLinesFromFile(args));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error reading files: Please provide paths to both the menu file and the users file"));
        }

        [TestCase("Error reading files: The first argument must be the path to the users file", "wrong_File.txt", "menus.txt")]
        [TestCase("Error reading files: The second argument must be the path to the menus file", "users.txt", "wrong_File.txt")]
        public void GivenIncorrectFileName_WhenReadingLinesFromFile_ShouldThrowException(string errorMessage, params string[] args)
        {
            // Arrange
            var mockFileSystem = Substitute.For<IFileSystem>();
            mockFileSystem.Exists(Arg.Any<string>()).Returns(false);
            var reader = new FileReader(mockFileSystem);

            // Act
            var ex = Assert.Throws<Exception>(() => reader.ReadLinesFromFile(args));
            // Assert
            Assert.That(ex?.Message, Is.EqualTo(errorMessage));
        }

        [Test]
        public void GivenNonExistentFiles_WhenReadingLinesFromFile_ShouldThrowException()
        {
            // Arrange
            var mockFileSystem = Substitute.For<IFileSystem>();
            mockFileSystem.Exists(Arg.Any<string>()).Returns(false);
            var reader = new FileReader(mockFileSystem);
            string[] args = { "users.txt", "menus.txt" };
            // Act
            var ex = Assert.Throws<Exception>(() => reader.ReadLinesFromFile(args));
            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error reading files: One or both of the specified files do not exist or have the wrong path"));
        }
    }
}
