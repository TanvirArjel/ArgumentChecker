using System;
using System.Collections.Generic;
using Xunit;

namespace TanvirArjel.ArgumentChecker.Tests
{
    public class ReferenceTypeArgumentExtensionsTests
    {
        [Fact]
        public void ThrowIfNull_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<int> items = null;
            string message = null;

            // Act
            Action action1 = () => items.ThrowIfNull(nameof(items));
            Action action2 = () => message.ThrowIfNull(nameof(message));

            // Assert
            Assert.Throws<ArgumentNullException>(action1);
            Assert.Throws<ArgumentNullException>(action2);
        }

        [Fact]
        public void ThrowIfNull_WithNotNull_ReturnsValue()
        {
            // Arrange
            IEnumerable<int> items = new List<int>();
            string message = "Good Morning!";

            // Act
            IEnumerable<int> actual1 = items.ThrowIfNull(nameof(items));
            string actual2 = message.ThrowIfNull(nameof(message));

            // Assert
            Assert.NotNull(actual1);
            Assert.NotNull(actual2);
        }
    }
}
