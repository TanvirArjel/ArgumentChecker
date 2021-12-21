using System;
using Xunit;

namespace TanvirArjel.ArgumentChecker.Tests
{
    public class SpanArgumentExtensionsTests
    {

        private void CallThrowIfEmptyWithEmptySpan()
        {
            // Arrange
            Span<string> argument = null;

            // Act
            argument.ThrowIfEmpty(nameof(argument));
        }

        private void CallThrowIfEmptyWithEmptyReadOnlySpan()
        {
            // Arrange
            ReadOnlySpan<string> argument = null;

            // Act
            argument.ThrowIfEmpty(nameof(argument));
        }

        [Fact]
        public void ThrowIfNull_WithEmptySpan_ThrowsArgumentNullException()
        {
            // Act
            Action action = () => CallThrowIfEmptyWithEmptySpan();

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void ThrowIfNull_WithNotNullSpan_ReturnsValue()
        {
            // Arrange
            string[] items = { "Tanvir" };
            Span<string> argument = new Span<string>(items);

            // Act
            Span<string> actual = argument.ThrowIfEmpty(nameof(argument));

            // Assert
            Assert.Equal(argument.Length, actual.Length);
        }

        [Fact]
        public void ThrowIfNull_WithEmptyReadOnlySpan_ThrowsArgumentNullException()
        {
            // Act
            Action action = () => CallThrowIfEmptyWithEmptyReadOnlySpan();

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void ThrowIfNull_WithNotNullReadOnlySpan_ReturnsValue()
        {
            // Arrange
            string[] items = { "Tanvir" };
            ReadOnlySpan<string> argument = new Span<string>(items);

            // Act
            ReadOnlySpan<string> actual = argument.ThrowIfEmpty(nameof(argument));

            // Assert
            Assert.Equal(argument.Length, actual.Length);
        }
    }
}
