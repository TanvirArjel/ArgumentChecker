// <copyright file="NumericArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check different numeric argument types and throw appropriate exception.
    /// </summary>
    public static class NumericArgumentExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="value"/> is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        public static T ThrowIfNull<T>([ValidatedNotNull] this T? value, string paramName, string message = null)
            where T : struct
        {
            if (value is null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value.Value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static T ThrowIfZeroOrNegative<T>(this T value, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value.CompareTo(default(T)) <= 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, "The value cannot be zero or negative.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static T? ThrowIfZeroOrNegative<T>([ValidatedNotNull] this T? value, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value == null)
            {
                return value;
            }

            if (value.Value.CompareTo(default(T)) <= 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, "The value cannot be zero or negative.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static T ThrowIfNegative<T>(this T value, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value.CompareTo(default(T)) < 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, "The value cannot be negative.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static T? ThrowIfNegative<T>([ValidatedNotNull] this T? value, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value == null)
            {
                return value;
            }

            if (value.Value.CompareTo(default(T)) < 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, "The value cannot be negative.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static T ThrowIfOutOfRange<T>(this T value, T min, T max, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, $"The value must be in between {min} and {max}.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static T? ThrowIfOutOfRange<T>([ValidatedNotNull] this T? value, T min, T max, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value == null)
            {
                return value;
            }

            if (value.Value.CompareTo(min) < 0 || value.Value.CompareTo(max) > 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, $"The value must be in between {min} and {max}.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }
    }
}
