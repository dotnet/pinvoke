// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PInvoke;
using Xunit;

public partial class Kernel32ExtensionsFacts
{
    [Fact]
    [UseCulture("en-US")]
    public void GetMessage_NTStatus()
    {
        NTSTATUS error = NTSTATUS.Code.EPT_NT_INVALID_ENTRY;
        string message = error.GetMessage();
        Assert.Equal("The entry is invalid", message);
    }

    [Fact]
    public void NTStatusException_Serializable()
    {
        var exception = new NTStatusException(NTSTATUS.Code.STATUS_TPM_AUDITFAIL_SUCCESSFUL, "It works, yo");
        var formatter = new BinaryFormatter();
        var ms = new MemoryStream();
        formatter.Serialize(ms, exception);
        ms.Position = 0;
        var deserializedException = (NTStatusException)formatter.Deserialize(ms);
        Assert.Equal(exception.Message, deserializedException.Message);
        Assert.Equal(exception.NativeErrorCode, deserializedException.NativeErrorCode);
    }

    [Fact]
    public void Win32Exception_Serializable()
    {
        var exception = new Win32Exception(Win32ErrorCode.DNS_ERROR_AXFR, "It works, yo");
        var formatter = new BinaryFormatter();
        var ms = new MemoryStream();
        formatter.Serialize(ms, exception);
        ms.Position = 0;
        var deserializedException = (Win32Exception)formatter.Deserialize(ms);
        Assert.Equal(exception.Message, deserializedException.Message);
        Assert.Equal(exception.NativeErrorCode, deserializedException.NativeErrorCode);
    }
}
