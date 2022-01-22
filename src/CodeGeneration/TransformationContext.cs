// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal struct TransformationContext
{
    internal TypeDeclarationSyntax ProcessingNode { get; set; }

    internal Compilation Compilation { get; set; }
}
