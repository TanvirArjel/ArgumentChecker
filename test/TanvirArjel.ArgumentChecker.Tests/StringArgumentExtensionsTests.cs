using System;
using Xunit;

namespace TanvirArjel.ArgumentChecker.Tests
{
    public class StringArgumentExtensionsTests
    {
        [Fact]
        public void ThrowIfNullOrEmpty_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            string argument = null;

            // Act
            Action act = () => argument.ThrowIfNullOrEmpty(nameof(argument));

            // Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ThrowIfNullOrEmpty_WithEmpty_ThrowsArgumentException()
        {
            // Arrange
            string argument = string.Empty;

            // Act
            Action act = () => argument.ThrowIfNullOrEmpty(nameof(argument));

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ThrowIfNullOrEmpty_WithValidValue_ReturnsValue()
        {
            // Arrange
            string argument = "TanvirArjel";

            // Act
            string actual = argument.ThrowIfNullOrEmpty(nameof(argument));

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(argument, actual);
        }

        [Fact]
        public void ThrowIfOutOfLength_WithInValidRange_ThrowsArgumentException()
        {
            // Arrange
            string argument = "TanvirArjel";

            // Act
            Action act = () => argument.ThrowIfOutOfLength(6, 2, nameof(argument));

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ThrowIfOutOfLength_WithInValidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string argument = "TanvirArjel";

            // Act
            Action act = () => argument.ThrowIfOutOfLength(2, 6, nameof(argument));

            // Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ThrowIfOutOfLength_WithValidValue_ReturnsValue()
        {
            // Arrange
            string argument = "Tanvir";

            // Act
            string actual = argument.ThrowIfOutOfLength(2, 6, nameof(argument));

            // Assert
            Assert.Equal(argument, actual);
        }

        [Fact]
        public void ThrowIfExceedsLength_WithInValidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string argument = "TanvirArjel";

            // Act
            Action act = () => argument.ThrowIfExceedsLength(6, nameof(argument));

            // Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ThrowIfExceedsLength_WithValidValue_ReturnsValue()
        {
            // Arrange
            string argument = "Tanvir";

            // Act
            string actual = argument.ThrowIfExceedsLength(6, nameof(argument));

            // Assert
            Assert.Equal(argument, actual);
        }

        [Fact]
        public void ThrowIfNotValidEmail_WithInValidEmail_ThrowsArgumentException()
        {
            // Arrange
            string argument = "tanvir";

            // Act
            Action action = () => argument.ThrowIfNotValidEmail(nameof(argument));

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void ThrowIfNotValidEmail_WithValidEmail_ReturnsValue()
        {
            // Arrange
            string argument = "tanvir@gmail.com";

            // Act
            string actual = argument.ThrowIfNotValidEmail(nameof(argument));

            // Assert
            Assert.Equal(argument, actual);
        }
    }
}
