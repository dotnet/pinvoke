// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;
    using CodeGeneration.Roslyn;

    /// <summary>
    /// Causes generation of an overload of the method that accepts
    /// <see cref="IntPtr"/> parameters instead of native pointers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    [CodeGenerationAttribute("PInvoke.OfferFriendlyOverloadsGenerator, CodeGeneration, Version=0.1.0.0, Culture=neutral, PublicKeyToken=9e300f9f87f04a7a")]
    [Conditional("CodeGeneration")]
    public class OfferFriendlyOverloadsAttribute : Attribute
    {
    }
}
