// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETFRAMEWORK || NETSTANDARD

using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

#if NET45_ORLATER || NETSTANDARD

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]

#endif

#endif
