// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal interface IGenerator
{
    SyntaxList<MemberDeclarationSyntax> Generate(TransformationContext context, CancellationToken cancellationToken);
}
