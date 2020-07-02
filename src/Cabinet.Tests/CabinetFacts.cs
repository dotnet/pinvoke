// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public unsafe class CabinetFacts : IDisposable
{
    private readonly Cabinet.FNALLOC fdiAllocMemDelegate;
    private readonly Cabinet.FNFREE fdiFreeMemDelegate;
    private readonly Cabinet.FNOPEN fdiOpenStreamDelegate;
    private readonly Cabinet.FNREAD fdiReadStreamDelegate;
    private readonly Cabinet.FNWRITE fdiWriteStreamDelegate;
    private readonly Cabinet.FNCLOSE fdiCloseStreamDelegate;
    private readonly Cabinet.FNSEEK fdiSeekStreamDelegate;

    private readonly Cabinet.ERF* erf;

    private readonly Dictionary<int, Kernel32.SafeObjectHandle> handles = new Dictionary<int, Kernel32.SafeObjectHandle>();
    private readonly Random handleGenerator = new Random();

    public CabinetFacts()
    {
        this.erf = (Cabinet.ERF*)Marshal.AllocHGlobal(sizeof(Cabinet.ERF));

        this.fdiAllocMemDelegate = this.AllocMem;
        this.fdiFreeMemDelegate = this.FreeMem;
        this.fdiOpenStreamDelegate = this.Open;
        this.fdiReadStreamDelegate = this.Read;
        this.fdiWriteStreamDelegate = this.Write;
        this.fdiCloseStreamDelegate = this.Close;
        this.fdiSeekStreamDelegate = this.Seek;
    }

    [Fact]
    public void CreateDisposeContext()
    {
        var handle = Cabinet.FDICreate(
            this.fdiAllocMemDelegate,
            this.fdiFreeMemDelegate,
            this.fdiOpenStreamDelegate,
            this.fdiReadStreamDelegate,
            this.fdiWriteStreamDelegate,
            this.fdiCloseStreamDelegate,
            this.fdiSeekStreamDelegate,
            Cabinet.CpuType.Unknown,
            this.erf);

        handle.Dispose();
    }

    [Fact (Skip = "Currently fails on 32-bit Windows")]
    public void ExtractCabinetFileTest()
    {
        var enterprisePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Microsoft Visual Studio\2019\Enterprise\Common7\IDE\CommonExtensions\Microsoft\IntelliTrace\");
        var communityPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\IntelliTrace\");

        string sampleCabinetPath = null;

        if (Directory.Exists(enterprisePath))
        {
            sampleCabinetPath = enterprisePath;
        }
        else if (Directory.Exists(communityPath))
        {
            sampleCabinetPath = communityPath;
        }
        else
        {
            throw new Exception("Could not find Visual Studio 2019 Enterprise or Community.");
        }

        string sampleCabinetName = "IntelliTraceCollection.cab";

        using (var handle = Cabinet.FDICreate(
            this.fdiAllocMemDelegate,
            this.fdiFreeMemDelegate,
            this.fdiOpenStreamDelegate,
            this.fdiReadStreamDelegate,
            this.fdiWriteStreamDelegate,
            this.fdiCloseStreamDelegate,
            this.fdiSeekStreamDelegate,
            Cabinet.CpuType.Unknown,
            this.erf))
        {
            if (!Cabinet.FDICopy(
                handle,
                sampleCabinetName,
                sampleCabinetPath,
                0,
                this.ExtractNotify,
                IntPtr.Zero,
                IntPtr.Zero))
            {
                throw new Exception($"Failed to extract the cabinet: {this.erf->Oper}");
            }
        }
    }

    public void Dispose()
    {
        Marshal.FreeHGlobal((IntPtr)this.erf);
    }

    private int ExtractNotify(Cabinet.NOTIFICATIONTYPE notificationType, Cabinet.NOTIFICATION notification)
    {
        switch (notificationType)
        {
            case Cabinet.NOTIFICATIONTYPE.CABINET_INFO:
                return 0;  // Continue

            case Cabinet.NOTIFICATIONTYPE.NEXT_CABINET:
                // Not supported
                return -1;

            case Cabinet.NOTIFICATIONTYPE.COPY_FILE:
                {
                    string filename = new string(notification.psz1);
                    var date = notification.date;
                    var time = notification.time;
                    var attribs = notification.attribs;

                    filename = Path.Combine(Environment.CurrentDirectory, filename);

                    var directory = Path.GetDirectoryName(filename);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    var handle = Kernel32.CreateFile(filename, Kernel32.ACCESS_MASK.GenericRight.GENERIC_WRITE, Kernel32.FileShare.None, IntPtr.Zero, Kernel32.CreationDisposition.CREATE_ALWAYS, Kernel32.CreateFileFlags.FILE_ATTRIBUTE_NORMAL, Kernel32.SafeObjectHandle.Null);

                    if (handle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }

                    int value = this.handleGenerator.Next();
                    this.handles.Add(value, handle);
                    return value;
                }

            case Cabinet.NOTIFICATIONTYPE.CLOSE_FILE_INFO:
                {
                    var handle = this.handles[notification.hf.ToInt32()];
                    handle.Dispose();
                    this.handles.Remove(notification.hf.ToInt32());

                    string filename = new string(notification.psz1);

                    // FILETIME really is just long
                    long filetime;
                    if (Kernel32.DosDateTimeToFileTime(notification.date, notification.time, (Kernel32.FILETIME*)&filetime))
                    {
                        var dateTime = DateTime.FromFileTimeUtc(filetime);
                        var attributes = (FileAttributes)notification.attribs &
                            (FileAttributes.Archive | FileAttributes.Hidden | FileAttributes.ReadOnly | FileAttributes.System);

                        File.SetLastWriteTimeUtc(Path.Combine(Environment.CurrentDirectory, filename), dateTime);
                        File.SetAttributes(Path.Combine(Environment.CurrentDirectory, filename), attributes);
                    }

                    return 1; /* TRUE to continue */
                }

            case Cabinet.NOTIFICATIONTYPE.ENUMERATE:
                return 0;

            default:
                throw new NotSupportedException();
        }
    }

    private IntPtr AllocMem(int byteCount) => Marshal.AllocHGlobal((IntPtr)byteCount);

    private void FreeMem(IntPtr memPointer) => Marshal.FreeHGlobal(memPointer);

    private int Open(string path, int openFlags, int shareMode)
    {
        var handle = Kernel32.CreateFile(path, (Kernel32.ACCESS_MASK)Kernel32.ACCESS_MASK.GenericRight.GENERIC_READ, Kernel32.FileShare.FILE_SHARE_READ, IntPtr.Zero, Kernel32.CreationDisposition.OPEN_EXISTING, Kernel32.CreateFileFlags.FILE_ATTRIBUTE_NORMAL, Kernel32.SafeObjectHandle.Null);

        if (handle.IsInvalid)
        {
            throw new Win32Exception();
        }

        var value = this.handleGenerator.Next();
        this.handles.Add(value, handle);
        return value;
    }

    private int Read(int streamHandle, byte* memory, int cb)
    {
        var handle = this.handles[streamHandle];

        int? read = 0;

        if (!Kernel32.ReadFile(
            handle,
            memory,
            cb,
            ref read,
            null))
        {
            throw new Win32Exception();
        }

        return read.Value;
    }

    private int Write(int streamHandle, byte* memory, int cb)
    {
        var handle = this.handles[streamHandle];

        int? written = 0;

        if (!Kernel32.WriteFile(
            handle,
            memory,
            cb,
            ref written,
            null))
        {
            throw new Win32Exception();
        }

        return written.Value;
    }

    private uint Seek(int streamHandle, int offset, SeekOrigin seekOrigin)
    {
        var handle = this.handles[streamHandle];

        return (uint)Kernel32.SetFilePointer(
            handle,
            offset,
            null,
            seekOrigin);
    }

    private uint Close(int streamHandle)
    {
        var handle = this.handles[streamHandle];

        handle.Dispose();
        this.handles.Remove(streamHandle);

        return 0;
    }
}
