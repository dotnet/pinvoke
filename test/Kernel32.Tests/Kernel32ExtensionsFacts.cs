// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using PInvoke;
using Xunit;

public partial class Kernel32ExtensionsFacts
{
    [Fact]
    [UseCulture("en-US")]
    public void ThrowOnError_Win32ErrorCode()
    {
        Win32ErrorCode success = Win32ErrorCode.ERROR_SUCCESS;
        success.ThrowOnError();
        Win32ErrorCode failure = Win32ErrorCode.ERROR_FAIL_NOACTION_REBOOT;
        Assert.Throws<Win32Exception>(() => failure.ThrowOnError());

        try
        {
            failure.ThrowOnError();
            Assert.False(true, "Expected exception not thrown.");
        }
        catch (Win32Exception ex)
        {
            Assert.Equal("No action was taken as a system reboot is required", ex.Message);
        }
    }

    [Fact]
    [UseCulture("en-US")]
    public void ThrowOnError_NTStatus()
    {
        NTSTATUS success = NTSTATUS.Code.STATUS_SUCCESS;
        success.ThrowOnError();
        NTSTATUS failure = NTSTATUS.Code.RPC_NT_CALL_FAILED;
        Assert.Throws<NTStatusException>(() => failure.ThrowOnError());

        try
        {
            failure.ThrowOnError();
            Assert.False(true, "Expected exception not thrown.");
        }
        catch (NTStatusException ex)
        {
#if NETFRAMEWORK
            Assert.Equal("The remote procedure call failed (NT_STATUS error: RPC_NT_CALL_FAILED (0xC002001B))", ex.Message);
#else
            Assert.Equal("NT_STATUS error: RPC_NT_CALL_FAILED (0xC002001B)", ex.Message);
#endif
        }
    }

    [Fact]
    [UseCulture("en-US")]
    public void GetMessage_Win32ErrorCode()
    {
        string message = Win32ErrorCode.ERROR_INVALID_LABEL.GetMessage();
        Assert.Equal("Indicates a particular Security ID may not be assigned as the label of an object", message);
    }
}
