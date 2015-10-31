// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using PInvoke;
using Xunit;

public class KernelExtensionsTests
{
    [Fact]
    public void ThrowOnError_DoesNotThrowOnSuccess()
    {
        NTStatus.STATUS_SUCCESS.ThrowOnError();
    }
}
