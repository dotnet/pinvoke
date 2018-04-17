// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows the C# compiler to target .NET 2.0 while still using extension method syntax.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Method)]
    internal class ExtensionAttribute : Attribute
    {
    }
}
