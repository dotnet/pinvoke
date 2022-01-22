// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
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
            NTSTATUS status = NtOpenSection(out SafeNTObjectHandle hObject, Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ, attrs);
            Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_ACCESS_DENIED, status);
        }
    }

    [Fact]
    public unsafe void NtQueryInformationProcess_Test()
    {
        var desiredAccess = new Kernel32.ACCESS_MASK(Kernel32.ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION);
        using (Kernel32.SafeObjectHandle process = Kernel32.OpenProcess(desiredAccess, false, Process.GetCurrentProcess().Id))
        {
            PROCESS_BASIC_INFORMATION pbi = default;

            NTSTATUS result = NtQueryInformationProcess(
                    process,
                    PROCESSINFOCLASS.ProcessBasicInformation,
                    &pbi,
                    sizeof(PROCESS_BASIC_INFORMATION),
                    out int _);

            Assert.Equal(NTSTATUS.Code.STATUS_SUCCESS, result.Value);
        }
    }

    [Fact]
    public void RtlGetVersion_OSVERSIONINFO_Test()
    {
        var versionInfo = Kernel32.OSVERSIONINFO.Create();

        Assert.Equal(NTSTATUS.Code.STATUS_SUCCESS, RtlGetVersion(ref versionInfo).Value);
        Assert.Equal(Kernel32.OSPlatformId.VER_PLATFORM_WIN32_NT, versionInfo.dwPlatformId);
        Assert.NotEqual(0, versionInfo.dwMajorVersion);
        Assert.NotEqual(0, versionInfo.dwBuildNumber);
    }

    [Fact]
    public unsafe void RtlGetVersion_OSVERSIONINFOEX_Test()
    {
        var versionInfoEx = Kernel32.OSVERSIONINFOEX.Create();

        Assert.Equal(NTSTATUS.Code.STATUS_SUCCESS, RtlGetVersion((Kernel32.OSVERSIONINFO*)&versionInfoEx).Value);
        Assert.Equal(2, versionInfoEx.dwPlatformId); // VER_PLATFORM_WIN32_NT
        Assert.NotEqual(0, versionInfoEx.dwMajorVersion);
        Assert.NotEqual(0, versionInfoEx.dwBuildNumber);
        Assert.True(Enum.IsDefined(typeof(Kernel32.OS_TYPE), versionInfoEx.wProductType), $"Unexpected OS_TYPE value: 0x{(int)versionInfoEx.wProductType:X}");
    }
}
