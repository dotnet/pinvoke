// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// We must type forward so that folks who compiled against our netstandard1.x library
// can still run when linking against a more recent library at runtime.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeHandleZeroOrMinusOneIsInvalid))]
