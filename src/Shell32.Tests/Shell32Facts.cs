// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.Shell32;

#pragma warning disable CS0618 // Type or member is obsolete

public class Shell32Facts
{
    [Fact]
    public void SHGetFolderPath_LocalAppData()
    {
        string actual = SHGetFolderPath(CSIDL.CSIDL_LOCAL_APPDATA);
        string expected = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SHGetKnownFolderPath_LocalAppData()
    {
        string actual = SHGetKnownFolderPath(KNOWNFOLDERID.FOLDERID_LocalAppData);
        string expected = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public unsafe void SHGetFolderLocation_SHGetPathFromIDList()
    {
        ITEMIDLIST* list;
        SHGetFolderLocation(IntPtr.Zero, CSIDL.CSIDL_LOCAL_APPDATA, IntPtr.Zero, 0, out list).ThrowOnFailure();
        try
        {
            string actual = SHGetPathFromIDList(list);
            string expected = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Assert.Equal(expected, actual);
        }
        finally
        {
            ILFree(list);
        }
    }

    [Fact]
    public unsafe void SHGetKnownFolderIDList_SHGetPathFromIDList()
    {
        ITEMIDLIST* list;
        SHGetKnownFolderIDList(KNOWNFOLDERID.FOLDERID_LocalAppData, KNOWN_FOLDER_FLAG.None, IntPtr.Zero, out list).ThrowOnFailure();
        try
        {
            string actual = SHGetPathFromIDList(list);
            string expected = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Assert.Equal(expected, actual);
        }
        finally
        {
            ILFree(list);
        }
    }
}
