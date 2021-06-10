using System;
using System.Collections.Generic;
using System.Linq;

namespace TanvirArjel.ArgumentChecker
{
    public static class ArgumentExtensions
    {
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

        public static T ThrowIfNull<T>(this T? value, string paramName, string message = null)
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

        public static int ThrowIfZeroOrNegative(this int value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<int>(value, paramName, message);
        }

        public static long ThrowIfZeroOrNegative(this long value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<long>(value, paramName, message);
        }

        public static float ThrowIfZeroOrNegative(this float value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<float>(value, paramName, message);
        }

        public static double ThrowIfZeroOrNegative(this double value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<double>(value, paramName, message);
        }

        public static decimal ThrowIfZeroOrNegative(this decimal value, string paramName, string message = null)
        {
            return ThrowIfZeroOrNegative<decimal>(value, paramName, message);
        }


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

        public static int ThrowIfOutOfRange(this int value, int min, int max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<int>(value, min, max, paramName, message);
        }

        public static long ThrowIfOutOfRange(this long value, long min, long max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<long>(value, min, max, paramName, message);
        }

        public static float ThrowIfOutOfRange(this float value, float min, float max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<float>(value, min, max, paramName, message);
        }

        public static double ThrowIfOutOfRange(this double value, double min, double max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<double>(value, min, max, paramName, message);
        }

        public static decimal ThrowIfOutOfRange(this decimal value, decimal min, decimal max, string paramName, string message = null)
        {
            return ThrowIfOutOfRange<decimal>(value, min, max, paramName, message);
        }

        private static T ThrowIfOutOfRange<T>(T value, T min, T max, string paramName, string message = null)
            where T : struct, IComparable
        {
            if (value.CompareTo(default(T)) < min.CompareTo(default(T)) || value.CompareTo(default(T)) > max.CompareTo(default(T)))
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentOutOfRangeException(paramName, $"The value must be in between {min} and {max}.");
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }

            return value;
        }

        public static string ThrowIfNullOrEmpty(this string value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of paramter is empty", paramName);
                }

                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }

        public static Guid ThrowIfEmpty(this Guid value, string paramName, string message = null)
        {
            if (value == Guid.Empty)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("The value of paramter is empty", paramName);
                }

                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        public static Guid ThrowIfNullOrEmpty(this Guid? value, string paramName, string message = null)
        {
            value.ThrowIfNull(paramName, message);
            ((Guid)value).ThrowIfEmpty(paramName, message);
            return value.Value;
        }

        public static IEnumerable<T> ThrowIfNull<T>(this IEnumerable<T> collection, string paramName, string message = null)
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

        public static IEnumerable<T> ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection, string paramName, string message = null)
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
