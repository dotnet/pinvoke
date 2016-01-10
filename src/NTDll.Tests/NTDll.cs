// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.NTDll;

public class NTDll
{
    [Fact]
    public void RtlNtStatusToDosError_Test()
    {
        Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, RtlNtStatusToDosError(NTStatus.Code.STATUS_PENDING));
        Assert.Equal(Win32ErrorCode.ERROR_SUCCESS, RtlNtStatusToDosError(NTStatus.Code.STATUS_SUCCESS));
        Assert.Equal(Win32ErrorCode.ERROR_OBJECT_ALREADY_EXISTS, RtlNtStatusToDosError(NTStatus.Code.STATUS_DUPLICATE_OBJECTID));

        // You'd think these would be more or less obviously correct return values, but this API
        // actually does a pitiful job of producing valid return values.
        ////Assert.Equal(Win32ErrorCode.ERROR_DS_DUPLICATE_ID_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_DUPLICATE_OBJECTID));
        ////Assert.Equal(Win32ErrorCode.ERROR_PROFILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_PCP_PROFILE_NOT_FOUND));
        ////Assert.Equal(Win32ErrorCode.ERROR_FILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_NDIS_FILE_NOT_FOUND));
        ////Assert.Equal(Win32ErrorCode.ERROR_MUI_FILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_MUI_FILE_NOT_FOUND));
    }
}
