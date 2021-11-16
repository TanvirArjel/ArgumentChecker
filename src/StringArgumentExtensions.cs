// <copyright file="StringArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Net.Mail;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check <see cref="string"/> argument types and throw appropriate exception.
    /// </summary>
    public static class StringArgumentExtensions
    {
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
        public static string ThrowIfNullOrEmpty([ValidatedNotNull] this string value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of parameter is empty.", paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified lengths.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="minLength">The minimum length of string.</param>
        /// <param name="maxLength">The maximum length of the string.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="minLength"/> is zero or negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="maxLength"/> is zero or negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified lengths.</exception>
        public static string ThrowIfOutOfLength(
            [ValidatedNotNull] this string value,
            int minLength,
            int maxLength,
            string paramName,
            string message = null)
        {
            value.ThrowIfNull(paramName, message);
            minLength.ThrowIfNegative(nameof(minLength));
            maxLength.ThrowIfNegative(nameof(maxLength));

            if (minLength > maxLength)
            {
                throw new ArgumentException($"The value of {nameof(minLength)} must be smaller than or equal to {nameof(maxLength)}");
            }

            int stringLength = value.Length;

            if (stringLength < minLength || stringLength > maxLength)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, $"The length must be in between {minLength} and {maxLength}.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the length of <paramref name="value"/> exceeds specified length.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="maxLength">The maximum length of the string.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="maxLength"/> is zero or negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified lengths.</exception>
        public static string ThrowIfExceedsLength(
            [ValidatedNotNull] this string value,
            int maxLength,
            string paramName,
            string message = null)
        {
            maxLength.ThrowIfNegative(nameof(maxLength));

            if (value == null)
            {
                return value;
            }

            if (value.Length > maxLength)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, $"The length must be less than or equal to {maxLength}.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the <paramref name="value"/> is not a valid email address.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="value"/> is <see langword="null"/> or empty.</exception>
        /// <exception cref="ArgumentException">Throws if the <paramref name="value"/> is not a valid email address.</exception>
        public static string ThrowIfNotValidEmail(
            [ValidatedNotNull] this string value,
            string paramName,
            string message = null)
        {
            if (value == null)
            {
                return value;
            }

            try
            {
                MailAddress mailAddress = new MailAddress(value);
                return mailAddress.Address;
            }
            catch
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The provied string is not a valid email address.", paramName);
                }

                throw new ArgumentException(message, paramName);
            }
        }
    }
}
