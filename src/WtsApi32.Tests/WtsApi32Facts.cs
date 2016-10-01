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
    public void CheckWorkingOfWtsSafeMemoryGuard()
    {
        System.Diagnostics.Debugger.Break();

        WtsSafeSessionInfoGuard wtsSafeMemoryGuard = new WtsSafeSessionInfoGuard();
        int sessionCount = 0;
        Assert.True(WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref wtsSafeMemoryGuard, ref sessionCount));
        Assert.NotEqual(0, sessionCount);

        var list = wtsSafeMemoryGuard.Take(sessionCount).ToList();
        foreach (var ses in list)
        {
            this.output.WriteLine($"{ses.pWinStationName}, {ses.SessionID}, {ses.State}");
        }
    }
}
