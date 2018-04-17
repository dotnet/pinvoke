// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET20 || NET40 || NET45 || NETSTANDARD1_1 || PROFILE111

using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

#if NET45 || NETSTANDARD1_1 || PROFILE111

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

#endif

#endif
