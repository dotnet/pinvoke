// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using PInvoke;
using Xunit;
using Xunit.Abstractions;
using static PInvoke.WtsApi32;

public class WtsApi32Facts
{
    private readonly ITestOutputHelper output;

    public WtsApi32Facts(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public unsafe void CheckWorkingOfWtsSafeMemoryGuard()
    {
        WTS_SESSION_INFO* pSessions;
        int sessionCount;
        Assert.True(WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, out pSessions, out sessionCount));
        try
        {
            Assert.NotEqual(0, sessionCount);

            for (int i = 0; i < sessionCount; i++)
            {
                var ses = pSessions[i];
                this.output.WriteLine($"#{i} {ses.WinStationName}, {ses.SessionID}, {ses.State}");
            }
        }
        finally
        {
            if (pSessions != null)
            {
                WTSFreeMemory(pSessions);
            }
        }
    }
}
