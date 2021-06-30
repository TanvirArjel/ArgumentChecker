// <copyright file="ArgumentExtensions.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// Contains all the extension methods to check different argument types and throw appropriate exception.
    /// </summary>
    public static class ArgumentExtensions
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
            value.ThrowIfNullOrEmpty(paramName, message);
            minLength.ThrowIfZeroOrNegative(nameof(minLength));
            maxLength.ThrowIfZeroOrNegative(nameof(maxLength));

            int stringLength = value.Length;

            if (stringLength < minLength && stringLength > maxLength)
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
            value.ThrowIfNullOrEmpty(paramName, message);

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

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <paramref name="collection"/> is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The tuype of the item of the collection.</typeparam>
        /// <param name="collection">The collection to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentNullException">Throws if the <paramref name="collection"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> ThrowIfNull<T>([ValidatedNotNull] this IEnumerable<T> collection, string paramName, string message = null)
        {
            if (collection == null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return collection;
        }

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
        public static IEnumerable<T> ThrowIfNullOrEmpty<T>([ValidatedNotNull] this IEnumerable<T> collection, string paramName, string message = null)
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
            ((Guid)value).ThrowIfEmpty(paramName, message);
            return value.Value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static int ThrowIfZeroOrNegative(this int value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<int>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static long ThrowIfZeroOrNegative(this long value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<long>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static float ThrowIfZeroOrNegative(this float value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<float>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static double ThrowIfZeroOrNegative(this double value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<double>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        public static decimal ThrowIfZeroOrNegative(this decimal value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<decimal>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static int ThrowIfNegative(this int value, string paramName, string message = null)
        {
            return ThrowIfNegative<int>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static long ThrowIfNegative(this long value, string paramName, string message = null)
        {
            return ThrowIfNegative<long>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static float ThrowIfNegative(this float value, string paramName, string message = null)
        {
            return ThrowIfNegative<float>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static double ThrowIfNegative(this double value, string paramName, string message = null)
        {
            return ThrowIfNegative<double>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        public static decimal ThrowIfNegative(this decimal value, string paramName, string message = null)
        {
            return ThrowIfNegative<decimal>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static int ThrowIfOutOfRange(this int value, int min, int max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<int>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static long ThrowIfOutOfRange(this long value, long min, long max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<long>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static float ThrowIfOutOfRange(this float value, float min, float max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<float>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static double ThrowIfOutOfRange(this double value, double min, double max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<double>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static decimal ThrowIfOutOfRange(this decimal value, decimal min, decimal max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<decimal>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static DateTime ThrowIfOutOfRange(this DateTime value, DateTime min, DateTime max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<DateTime>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        public static TimeSpan ThrowIfOutOfRange(this TimeSpan value, TimeSpan min, TimeSpan max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<TimeSpan>(value, min, max, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is zero or negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is zero or negative.</exception>
        private static T ThrowIfZeroOrNegative<T>(T value, string paramName, string message = null)
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
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is negative.</exception>
        private static T ThrowIfNegative<T>(T value, string paramName, string message = null)
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
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the <paramref name="value"/> is out of specified range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>The original value if check is passed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the <paramref name="value"/> is out of specified range.</exception>
        private static T ThrowIfOutOfRange<T>(T value, T min, T max, string paramName, string message = null)
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
    }
}
