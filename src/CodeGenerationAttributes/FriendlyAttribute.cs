// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;
using System.Diagnostics;

/// <summary>
/// An attribute applied to native pointer parameters to indicate its semantics
/// such that a friendly overload of the method can be generated with the right signature.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
[Conditional("CodeGeneration")]
public class FriendlyAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FriendlyAttribute"/> class.
    /// </summary>
    /// <param name="flags">The flags that describe this parameter's semantics.</param>
    public FriendlyAttribute(FriendlyFlags flags)
    {
        this.Flags = flags;
    }

    /// <summary>
    /// Gets the flags that describe this parameter's semantics.
    /// </summary>
    public FriendlyFlags Flags { get; }

    /// <summary>
    /// Gets or sets the 0-based index to the parameter that takes the length of the array given by this array parameter.
    /// An overload will be generated that drops this parameter and sets it automatically based on the length of the array provided to the parameter this attribute is applied to.
    /// </summary>
    /// <value>-1 is the default and indicates that no automated parameter removal should be generated.</value>
    /// <remarks>
    /// Only applicable when <see cref="Flags"/> includes <see cref="FriendlyFlags.Array"/>.
    /// </remarks>
    public int ArrayLengthParameter { get; set; } = -1;
}
