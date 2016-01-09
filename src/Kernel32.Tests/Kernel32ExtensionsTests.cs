// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PInvoke;
using Xunit;

public partial class Kernel32ExtensionsTests
{
    [Fact]
    public void NTStatusException_Serializable()
    {
        var exception = new NTStatusException(NTStatus.STATUS_TPM_AUDITFAIL_SUCCESSFUL, "It works, yo");
        var formatter = new BinaryFormatter();
        var ms = new MemoryStream();
        formatter.Serialize(ms, exception);
        ms.Position = 0;
        var deserializedException = (NTStatusException)formatter.Deserialize(ms);
        Assert.Equal(exception.Message, deserializedException.Message);
        Assert.Equal(exception.StatusCode, deserializedException.StatusCode);
    }
}
