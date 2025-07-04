using NUnit.Framework;
using UserMenu.Models;
using UserMenu.Utils;

namespace UserMenu.Tests.Unit
{
    [TestFixture]
    public class ModelBuilderTests
    {
        [TestCase("1, Applications Menu, 5", "1, Applications Menu, super")]
        [TestCase("Applications Menu")]
        public void GivenInvalidInputFormat_WhenGettingMenuItems_ShouldThrowException(params string[] menuItems)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetMenuItems(menuItems));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing menu items: wrong format: Expected format: <int>,<name>"));
        }

        [TestCase("a, Applications Menu")]
        [TestCase("?, Applications Menu")]
        public void GivenInvalidMenuId_WhenGettingMenuItems_ShouldThrowException(params string[] menuItems)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetMenuItems(menuItems));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing menu items: Invalid ID. ID should be an integer."));
        }

        [TestCase("1, ")]
        public void GivenEmptyMenuItemName_WhenGettingMenuItems_ShouldThrowException(params string[] menuItems)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetMenuItems(menuItems));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing menu items: Invalid name. Name should not be empty."));
        }

        [TestCase()]
        public void GivenEmptyMenuItemList_WhenGettingMenuItems_ShouldThrowException(params string[] menuItems)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetMenuItems(menuItems));

            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing menu items: No valid menu items found in the provided data."));
        }

        [TestCase("user1 ABCD")]
        [TestCase("user2 YNYNa")]
        public void GivenInvalidUserPermissions_WhenGettingUsers_ShouldThrowException(params string[] userPermisions)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem(1, "Menu1"),
                new MenuItem(2, "Menu2")
            };
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetUsers(userPermisions, menuItems));
            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing user permissions: Invalid permissions format: Permissions should be either a 'y' or a 'n' "));
        }

        [TestCase()]
        public void GivenEmptyUserList_WhenGettingUsers_ShouldThrowException(params string[] userPermisions)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem(1, "Menu1"),
                new MenuItem(2, "Menu2")
            };
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetUsers(userPermisions, menuItems));
            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing user permissions: No valid users found in the provided data."));
        }


        [TestCase("user1 YYN")]
        [TestCase("user2 Y")]
        public void GivenUserListWithIncorrectNumberOfPermissions_WhenGettingUsers_ShouldThrowException(params string[] userPermisions)
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem(1, "Menu1"),
                new MenuItem(2, "Menu2")
            };
            // Act
            var ex = Assert.Throws<Exception>(() => modelBuilder.GetUsers(userPermisions, menuItems));
            // Assert
            Assert.That(ex?.Message, Is.EqualTo("Error processing user permissions: Invalid permissions length: Expected length should be the same as the number of menu items"));
        }
    }
}
