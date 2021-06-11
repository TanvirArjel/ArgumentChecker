// <copyright file="ValidatedNotNullAttribute.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace TanvirArjel.ArgumentChecker
{
    /// <summary>
    /// This empty attribute is used to remove compiler warning for reference type paramter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
