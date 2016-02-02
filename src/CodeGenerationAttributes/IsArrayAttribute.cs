// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// An attribute applied to native pointer parameters to indicate whether
    /// the pointer is to the start of an array as opposed to at most one value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    [Conditional("CodeGeneration")]
    public class IsArrayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsArrayAttribute"/> class.
        /// </summary>
        public IsArrayAttribute()
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IsArrayAttribute"/> class.
        /// </summary>
        /// <param name="isArray"><c>true</c> if the parameter is a pointer to an array of values; <c>false</c> if the pointer is to at most one value.</param>
        public IsArrayAttribute(bool isArray)
        {
            this.IsArray = isArray;
        }

        /// <summary>
        /// Gets a value indicating whether the parameter is a pointer to an array of values as opposed to just one value.
        /// </summary>
        /// <value>
        /// <c>true</c> if the parameter is a pointer to an array of values; <c>false</c> if the pointer is to at most one value.
        /// </value>
        public bool IsArray { get; }
    }
}
