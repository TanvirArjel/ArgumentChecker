// <copyright file="EnumerableArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check <see cref="IEnumerable{T}"/> argument types and throw appropriate exception.
    /// </summary>
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="collection"/> is <see langword="null"/> and
        /// <see cref="ArgumentException"/> if the <paramref name="collection"/> is empty.
        /// </summary>
        /// <typeparam name="T">The type of the item of the collection.</typeparam>
        /// <param name="collection">The collection to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="collection"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Throws if the <paramref name="collection"/> is empty.</exception>
        public static IEnumerable<T> ThrowIfNullOrEmpty<T>(
            [ValidatedNotNull] this IEnumerable<T> collection,
            string paramName,
            string message = null)
        {
            collection.ThrowIfNull(paramName, message);

            if (!collection.Any())
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The collection is empty.", paramName);
                }

                throw new ArgumentException(message, paramName);
            }

            return collection;
        }
    }
}
