// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// We must type forward so that folks who compiled against a PInvoke library that defines this type,
// it can still run when linking against a PInvoke library at runtime that doesn't define it.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeRegistryHandle))]
