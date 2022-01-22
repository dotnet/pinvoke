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
    public unsafe void StructSizeTest()
    {
        Assert.Equal(0x04, sizeof(IPHlpApi.MIB_TCPTABLE_OWNER_PID));
        Assert.Equal(0x18, sizeof(IPHlpApi.MIB_TCPROW_OWNER_PID));
    }

    [Fact]
    public unsafe void GetExtendedTcpTableTest()
    {
        IntPtr tcpTablePtr = IntPtr.Zero;
        int tcpTableLength = 0;

        if (IPHlpApi.GetExtendedTcpTable(tcpTablePtr, ref tcpTableLength, bOrder: true, AddressFamily.InterNetwork, IPHlpApi.TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0) == Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
        {
            try
            {
                tcpTablePtr = Marshal.AllocHGlobal(tcpTableLength);

                if (IPHlpApi.GetExtendedTcpTable(tcpTablePtr, ref tcpTableLength, bOrder: true, AddressFamily.InterNetwork, IPHlpApi.TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0) == Win32ErrorCode.ERROR_SUCCESS)
                {
                    IPHlpApi.MIB_TCPTABLE_OWNER_PID* tcpTable = (IPHlpApi.MIB_TCPTABLE_OWNER_PID*)tcpTablePtr;
                    int tableSize = sizeof(IPHlpApi.MIB_TCPTABLE_OWNER_PID);

                    IPHlpApi.MIB_TCPROW_OWNER_PID* tcpRow = (IPHlpApi.MIB_TCPROW_OWNER_PID*)(tcpTablePtr + tableSize);

                    for (int i = 0; i < tcpTable->dwNumEntries; ++i)
                    {
                        Assert.InRange(tcpRow->LocalPort, 0, 65535);
                        Assert.True(Enum.IsDefined(typeof(TcpState), tcpRow->dwState));

                        tcpRow++;
                    }
                }
            }
            finally
            {
                if (tcpTablePtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(tcpTablePtr);
                }
            }
        }
    }
}
