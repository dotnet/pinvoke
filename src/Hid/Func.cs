// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET20

namespace PInvoke
{
    internal delegate TReturn Func<TArg, TReturn>(TArg arg);
}

#endif
