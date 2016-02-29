// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.NTDll;

public class NTDllFacts
{
    [Fact]
    public void RtlNtStatusToDosError_Test()
    {
        Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, RtlNtStatusToDosError(NTSTATUS.Code.STATUS_PENDING));
        Assert.Equal(Win32ErrorCode.ERROR_SUCCESS, RtlNtStatusToDosError(NTSTATUS.Code.STATUS_SUCCESS));
        Assert.Equal(Win32ErrorCode.ERROR_OBJECT_ALREADY_EXISTS, RtlNtStatusToDosError(NTSTATUS.Code.STATUS_DUPLICATE_OBJECTID));

        // You'd think these would be more or less obviously correct return values, but this API
        // actually does a pitiful job of producing valid return values.
        ////Assert.Equal(Win32ErrorCode.ERROR_DS_DUPLICATE_ID_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_DUPLICATE_OBJECTID));
        ////Assert.Equal(Win32ErrorCode.ERROR_PROFILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_PCP_PROFILE_NOT_FOUND));
        ////Assert.Equal(Win32ErrorCode.ERROR_FILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_NDIS_FILE_NOT_FOUND));
        ////Assert.Equal(Win32ErrorCode.ERROR_MUI_FILE_NOT_FOUND, RtlNtStatusToDosError(NTStatus.STATUS_MUI_FILE_NOT_FOUND));
    }

    [Fact]
    public unsafe void NtOpenSection_Test()
    {
        string nameString = "\\Device\\PhysicalMemory";
        fixed (char* name = nameString)
        {
            var objectNameUnicode = new UNICODE_STRING
            {
                Buffer = name,
                Length = (ushort)(nameString.Length * sizeof(char)),
                MaximumLength = (ushort)(nameString.Length * sizeof(char)),
            };
            var attrs = OBJECT_ATTRIBUTES.Create();
            attrs.ObjectName = &objectNameUnicode;
            attrs.Attributes = OBJECT_ATTRIBUTES.ObjectHandleAttributes.OBJ_CASE_INSENSITIVE;
            SafeNTObjectHandle hObject;
            NTSTATUS status = NtOpenSection(out hObject, Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ, attrs);
            Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_ACCESS_DENIED, status);
        }
    }
}
