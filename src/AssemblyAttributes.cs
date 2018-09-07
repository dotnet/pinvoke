// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETFRAMEWORK || NETSTANDARD || PROFILE111

using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

#if NET45_ORLATER || NETSTANDARD || PROFILE111

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

#endif

#endif
