// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;
using System.Diagnostics;

/// <summary>
/// Causes generation of property accessors that expose native pointer fields
/// as <see cref="IntPtr"/> properties.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
[Conditional("CodeGeneration")]
public class OfferIntPtrPropertyAccessorsAttribute : Attribute
{
}
