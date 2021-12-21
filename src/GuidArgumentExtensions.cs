// <copyright file="GuidArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check different <see cref="Guid"/> types and throw appropriate exception.
    /// </summary>
    public static class GuidArgumentExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the <paramref name="value"/> is empty.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is empty.</exception>
        public static Guid ThrowIfEmpty([ValidatedNotNull] this Guid value, string paramName, string message = null)
        {
            if (value == Guid.Empty)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of parameter is empty.", paramName);
                }

                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the <paramref name="value"/> is empty.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is empty.</exception>
        public static Guid? ThrowIfEmpty([ValidatedNotNull] this Guid? value, string paramName, string message = null)
        {
            if (value == null)
            {
                return null;
            }

            value.Value.ThrowIfEmpty(paramName, message);
            return value.Value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="value"/> is <see langword="null"/> and
        /// <see cref="ArgumentException"/> if the <paramref name="value"/> is empty.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is empty.</exception>
        public static Guid ThrowIfNullOrEmpty([ValidatedNotNull] this Guid? value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);
            value.Value.ThrowIfEmpty(paramName, message);
            return value.Value;
        }
    }
}
