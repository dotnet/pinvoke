// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class IPHlpApiFacts
{
    [Fact]
    public void GetExtendedTcpTableTest()
    {
        IntPtr tcpTable = IntPtr.Zero;
        int tcpTableLength = 0;

        if (IPHlpApi.GetExtendedTcpTable(tcpTable, ref tcpTableLength, sort: true, AddressFamily.InterNetwork, IPHlpApi.TcpTableType.OwnerPidAll, 0) == Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
        {
            try
            {
                tcpTable = Marshal.AllocHGlobal(tcpTableLength);

                if (IPHlpApi.GetExtendedTcpTable(tcpTable, ref tcpTableLength, sort: true, AddressFamily.InterNetwork, IPHlpApi.TcpTableType.OwnerPidAll, 0) == Win32ErrorCode.ERROR_SUCCESS)
                {
                    byte[] data = new byte[tcpTableLength];
                    Marshal.Copy(tcpTable, data, 0, tcpTableLength);

                    int offset = 0;

                    var table = Marshal.PtrToStructure<IPHlpApi.MIB_TCPTABLE_OWNER_PID>(tcpTable + offset);
                    offset += Marshal.SizeOf<IPHlpApi.MIB_TCPTABLE_OWNER_PID>();

                    for (int i = 0; i < table.Length; ++i)
                    {
                        var row = Marshal.PtrToStructure<IPHlpApi.MIB_TCPROW_OWNER_PID>(tcpTable + offset);
                        offset += Marshal.SizeOf<IPHlpApi.MIB_TCPROW_OWNER_PID>();

                        Assert.NotEqual(0, row.LocalPort);
                        Assert.True(Enum.IsDefined(typeof(TcpState), row.State));
                    }
                }
            }
            finally
            {
                if (tcpTable != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(tcpTable);
                }
            }
        }
    }
}
