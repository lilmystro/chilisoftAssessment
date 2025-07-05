
using NSubstitute;
using NUnit.Framework;
using UserMenu.Presentation;
using UserMenu.Utils;

namespace UserMenu.Tests.Integration
{
    [TestFixture]
    public class UserMenuTests
    {

        [Test]
        public void GivenValidInput_WhenRunningUserMenu_ShouldReturnExpectedOutput()
        {
            // Arrange
            var fixture = new TestFixture();

            // Act
            fixture.App.GenerateUserMenuPermissions(fixture.Args);

            // Assert
            fixture.ConsoleJsonSerializer.Received(1).Serialize(Arg.Any<object>());
            fixture.FileSystem.Received(2).ReadAllLines(Arg.Any<string>());
            fixture.FileSystem.Received(2).Exists(Arg.Any<string>());
        }
    }
}
