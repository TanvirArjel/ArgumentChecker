// <copyright file="SpanArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check <see cref="Span{T}"/> argument types and throw appropriate exception.
    /// </summary>
    public static class SpanArgumentExtensions
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
        public static Span<T> ThrowIfNull<T>([ValidatedNotNull] this Span<T> value, string paramName, string message = null)
        {
            if (value == null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="value"/> is <see langword="null"/> and
        /// <see cref="ArgumentException"/> if the <paramref name="value"/> is empty.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is empty.</exception>
        public static Span<T> ThrowIfNullOrEmpty<T>([ValidatedNotNull] this Span<T> value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);

            if (value.Length == 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of parameter is empty.", paramName);
                }

                throw new ArgumentException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="value"/> is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        public static ReadOnlySpan<T> ThrowIfNull<T>([ValidatedNotNull] this ReadOnlySpan<T> value, string paramName, string message = null)
        {
            if (value == null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="value"/> is <see langword="null"/> and
        /// <see cref="ArgumentException"/> if the <paramref name="value"/> is empty.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is empty.</exception>
        public static ReadOnlySpan<T> ThrowIfNullOrEmpty<T>([ValidatedNotNull] this ReadOnlySpan<T> value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);

            if (value.Length == 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of parameter is empty.", paramName);
                }

                throw new ArgumentException(paramName, message);
            }

            return value;
        }
    }
}
