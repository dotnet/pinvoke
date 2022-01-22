// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;
using System.Diagnostics;

/// <summary>
/// Decorated on a method to suppress automatic generation of friendly overloads.
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
[Conditional("CodeGeneration")]
public sealed class NoFriendlyOverloadsAttribute : Attribute
{
}
