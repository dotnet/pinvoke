// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public unsafe class CabinetFacts
{
    private readonly Cabinet.FNALLOC fdiAllocMemDelegate;
    private readonly Cabinet.FNFREE fdiFreeMemDelegate;
    private readonly Cabinet.FNOPEN fdiOpenStreamDelegate;
    private readonly Cabinet.FNREAD fdiReadStreamDelegate;
    private readonly Cabinet.FNWRITE fdiWriteStreamDelegate;
    private readonly Cabinet.FNCLOSE fdiCloseStreamDelegate;
    private readonly Cabinet.FNSEEK fdiSeekStreamDelegate;

    private readonly Cabinet.ERF* erf;

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

    private IntPtr AllocMem(int byteCount) => Marshal.AllocHGlobal((IntPtr)byteCount);

    private void FreeMem(IntPtr memPointer) => Marshal.FreeHGlobal(memPointer);

    private int Open(string path, int openFlags, int shareMode)
    {
        var handle = Kernel32.CreateFile(path, (Kernel32.ACCESS_MASK)Kernel32.ACCESS_MASK.GenericRight.GENERIC_READ, Kernel32.FileShare.FILE_SHARE_READ, IntPtr.Zero, Kernel32.CreationDisposition.OPEN_EXISTING, Kernel32.CreateFileFlags.FILE_ATTRIBUTE_NORMAL, Kernel32.SafeObjectHandle.Null);
        return (int)handle.DangerousGetHandle();
    }

    private int Read(int streamHandle, void* memory, int cb)
    {
        int? read = 0;
        Kernel32.ReadFile(
            new Kernel32.SafeObjectHandle(new IntPtr(streamHandle), ownsHandle: false),
            memory,
            cb,
            ref read,
            null);
        return read.Value;
    }

    private int Write(int streamHandle, void* memory, int cb)
    {
        int? written = 0;
        Kernel32.WriteFile(
            new Kernel32.SafeObjectHandle(new IntPtr(streamHandle), ownsHandle: false),
            memory,
            cb,
            ref written,
            null);
        return written.Value;
    }

    private uint Seek(int streamHandle, int offset, SeekOrigin seekOrigin)
    {
        return Kernel32.SetFilePointer(
            new Kernel32.SafeObjectHandle(new IntPtr(streamHandle)),
            offset,
            out long _,
            seekOrigin) ? 0u : 1u;
    }

    private uint Close(int streamHandle)
    {
        return Kernel32.CloseHandle(new IntPtr(streamHandle)) ? 0u : 1u;
    }
}
