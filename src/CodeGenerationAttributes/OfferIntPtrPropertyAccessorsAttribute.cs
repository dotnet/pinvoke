// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;
    using CodeGeneration.Roslyn;

    /// <summary>
    /// Causes generation of property accessors that expose native pointer fields
    /// as <see cref="IntPtr"/> properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    [CodeGenerationAttribute("PInvoke.OfferIntPtrPropertyAccessorsGenerator, CodeGeneration, Version=0.1.0.0, Culture=neutral, PublicKeyToken=9e300f9f87f04a7a")]
    [Conditional("CodeGeneration")]
    public class OfferIntPtrPropertyAccessorsAttribute : Attribute
    {
    }
}
