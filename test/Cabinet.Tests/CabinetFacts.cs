// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public unsafe class CabinetFacts
{
    private static readonly string SampleCabinetPath = Path.GetDirectoryName(typeof(CabinetFacts).Assembly.Location) + "\\";

    private readonly Cabinet.FNALLOC fdiAllocMemDelegate;
    private readonly Cabinet.FNFREE fdiFreeMemDelegate;
    private readonly Cabinet.FNOPEN fdiOpenStreamDelegate;
    private readonly Cabinet.FNREAD fdiReadStreamDelegate;
    private readonly Cabinet.FNWRITE fdiWriteStreamDelegate;
    private readonly Cabinet.FNCLOSE fdiCloseStreamDelegate;
    private readonly Cabinet.FNSEEK fdiSeekStreamDelegate;

    private readonly Dictionary<int, Kernel32.SafeObjectHandle> handles = new Dictionary<int, Kernel32.SafeObjectHandle>();
    private int nextHandle;

    private Cabinet.ERF erf;

    public CabinetFacts()
    {
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
        Cabinet.FdiHandle handle = Cabinet.FDICreate(
            this.fdiAllocMemDelegate,
            this.fdiFreeMemDelegate,
            this.fdiOpenStreamDelegate,
            this.fdiReadStreamDelegate,
            this.fdiWriteStreamDelegate,
            this.fdiCloseStreamDelegate,
            this.fdiSeekStreamDelegate,
            Cabinet.CpuType.Unknown,
            out this.erf);

        handle.Dispose();
    }

    [Fact]
    public void ExtractCabinetFileTest()
    {
        string sampleCabinetName = "demo.CAB";

        using (Cabinet.FdiHandle handle = Cabinet.FDICreate(
            this.fdiAllocMemDelegate,
            this.fdiFreeMemDelegate,
            this.fdiOpenStreamDelegate,
            this.fdiReadStreamDelegate,
            this.fdiWriteStreamDelegate,
            this.fdiCloseStreamDelegate,
            this.fdiSeekStreamDelegate,
            Cabinet.CpuType.Unknown,
            out this.erf))
        {
            if (!Cabinet.FDICopy(
                handle,
                sampleCabinetName,
                SampleCabinetPath,
                0,
                this.ExtractNotify,
                IntPtr.Zero,
                IntPtr.Zero))
            {
                throw new Exception($"Failed to extract the cabinet: {this.erf.Oper}");
            }
        }
    }

    private int ExtractNotify(Cabinet.NOTIFICATIONTYPE notificationType, Cabinet.NOTIFICATION* notification)
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
                    string filename = new string(notification->psz1);
                    ushort date = notification->date;
                    ushort time = notification->time;
                    short attribs = notification->attribs;

                    filename = Path.Combine(SampleCabinetPath, filename);
                    Kernel32.SafeObjectHandle handle = Kernel32.CreateFile(filename, Kernel32.ACCESS_MASK.GenericRight.GENERIC_WRITE, Kernel32.FileShare.None, IntPtr.Zero, Kernel32.CreationDisposition.CREATE_ALWAYS, Kernel32.CreateFileFlags.FILE_ATTRIBUTE_NORMAL, Kernel32.SafeObjectHandle.Null);

                    if (handle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }

                    int value = this.nextHandle++;
                    this.handles.Add(value, handle);
                    return value;
                }

            case Cabinet.NOTIFICATIONTYPE.CLOSE_FILE_INFO:
                {
                    Kernel32.SafeObjectHandle handle = this.handles[notification->hf.ToInt32()];
                    handle.Dispose();
                    this.handles.Remove(notification->hf.ToInt32());

                    string filename = new string(notification->psz1);

                    // FILETIME really is just long
                    long filetime;
                    if (Kernel32.DosDateTimeToFileTime(notification->date, notification->time, (Kernel32.FILETIME*)&filetime))
                    {
                        var dateTime = DateTime.FromFileTimeUtc(filetime);
                        FileAttributes attributes = (FileAttributes)notification->attribs &
                            (FileAttributes.Archive | FileAttributes.Hidden | FileAttributes.ReadOnly | FileAttributes.System);

                        File.SetLastWriteTimeUtc(Path.Combine(SampleCabinetPath, filename), dateTime);
                        File.SetAttributes(Path.Combine(SampleCabinetPath, filename), attributes);
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
        Kernel32.SafeObjectHandle handle = Kernel32.CreateFile(path, (Kernel32.ACCESS_MASK)Kernel32.ACCESS_MASK.GenericRight.GENERIC_READ, Kernel32.FileShare.FILE_SHARE_READ, IntPtr.Zero, Kernel32.CreationDisposition.OPEN_EXISTING, Kernel32.CreateFileFlags.FILE_ATTRIBUTE_NORMAL, Kernel32.SafeObjectHandle.Null);

        if (handle.IsInvalid)
        {
            throw new Win32Exception();
        }

        int value = this.nextHandle++;
        this.handles.Add(value, handle);
        return value;
    }

    private int Read(int streamHandle, byte* memory, int cb)
    {
        Kernel32.SafeObjectHandle handle = this.handles[streamHandle];

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
        Kernel32.SafeObjectHandle handle = this.handles[streamHandle];

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
        Kernel32.SafeObjectHandle handle = this.handles[streamHandle];

        return (uint)Kernel32.SetFilePointer(
            handle,
            offset,
            null,
            seekOrigin);
    }

    private uint Close(int streamHandle)
    {
        Kernel32.SafeObjectHandle handle = this.handles[streamHandle];

        handle.Dispose();
        this.handles.Remove(streamHandle);

        return 0;
    }
}
