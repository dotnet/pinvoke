// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#if NET45 || NETSTANDARD1_1 || PROFILE111

using System.Runtime.InteropServices;

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

#endif
