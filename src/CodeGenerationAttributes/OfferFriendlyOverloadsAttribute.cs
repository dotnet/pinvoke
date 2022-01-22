// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;
using System.Diagnostics;

/// <summary>
/// Causes generation of an overload of the method that accepts
/// <see cref="IntPtr"/> parameters instead of native pointers.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[Conditional("CodeGeneration")]
public class OfferFriendlyOverloadsAttribute : Attribute
{
}
