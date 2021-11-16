// <copyright file="ReferenceTypeArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check different argument types and throw appropriate exception.
    /// </summary>
    public static class ReferenceTypeArgumentExtensions
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
        public static T ThrowIfNull<T>([ValidatedNotNull] this T value, string paramName, string message = null)
            where T : class
        {
            if (value is null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }
    }
}
