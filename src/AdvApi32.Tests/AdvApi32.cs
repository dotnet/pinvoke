// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.AdvApi32;

public class AdvApi32
{
    [Fact]
    public void LsaNtStatusToWinError_UsesTable()
    {
        Assert.Equal(Win32ErrorCode.ERROR_NOACCESS, LsaNtStatusToWinError(NTStatus.Code.STATUS_ACCESS_VIOLATION));
    }
}
