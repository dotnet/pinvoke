// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the SetupApi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class Cabinet
    {
        /// <summary>
        /// The <see cref="FNALLOC"/> provides the declaration for the application-defined callback function to allocate memory in an FDI context.
        /// </summary>
        /// <param name="cb">
        /// The number of bytes to allocate.
        /// </param>
        /// <returns>
        /// A pointer to the allocated memory.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr FNALLOC(int cb);

        /// <summary>
        /// The <see cref="FNFREE"/> macro provides the declaration for the application-defined callback function to free previously allocated memory in an FDI context.
        /// </summary>
        /// <param name="pv">
        /// Pointer to the allocated memory block to free.
        /// </param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FNFREE(IntPtr pv);

        /// <summary>
        /// The <see cref="FNOPEN"/> macro provides the declaration for the application-defined callback function to open a file in an FDI context.
        /// </summary>
        /// <param name="path">
        /// The name of the file.
        /// </param>
        /// <param name="oflag">
        /// File name.
        /// </param>
        /// <param name="pmode">
        /// The kind of operations allowed.
        /// </param>
        /// <returns>
        /// Permission mode.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int FNOPEN(string path, int oflag, int pmode);

        /// <summary>
        /// The <see cref="FNREAD"/> macro provides the declaration for the application-defined callback function to read data from a file in an FDI context.
        /// </summary>
        /// <param name="hf">
        /// An application-defined value used to identify the open file.
        /// </param>
        /// <param name="pv">
        /// Storage location for data.
        /// </param>
        /// <param name="cb">
        /// Maximum number of bytes to read.
        /// </param>
        /// <returns>
        /// The number of bytes read.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int FNREAD(int hf, byte* pv, int cb);

        /// <summary>
        /// The <see cref="FNWRITE"/> macro provides the declaration for the application-defined callback function to write data to a file in an FDI context.
        /// </summary>
        /// <param name="hf">
        /// An application-defined value used to identify the open file.
        /// </param>
        /// <param name="pv">
        /// Data to be written.
        /// </param>
        /// <param name="cb">
        /// Number of bytes.
        /// </param>
        /// <returns>
        /// If successful, _write returns the number of bytes written.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int FNWRITE(int hf, byte* pv, int cb);

        /// <summary>
        /// The <see cref="FNCLOSE"/> macro provides the declaration for the application-defined callback function to close a file in an FDI context.
        /// </summary>
        /// <param name="hf">
        /// An application-defined value used to identify the open file.
        /// </param>
        /// <returns>
        /// 0 if the file was successfully closed. A return value of -1 indicates an error.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FNCLOSE(int hf);

        /// <summary>
        /// The <see cref="FNSEEK"/> macro provides the declaration for the application-defined callback function to move a file pointer to the specified location in an FDI context.
        /// </summary>
        /// <param name="hf">
        /// An application-defined value used to identify the open file.
        /// </param>
        /// <param name="dist">
        /// Number of bytes from origin.
        /// </param>
        /// <param name="seektype">
        /// Initial position.
        /// </param>
        /// <returns>
        /// The offset, in bytes, of the new position from the beginning of the file.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FNSEEK(int hf, int dist, SeekOrigin seektype);

        /// <summary>
        /// The <see cref="FNFDINOTIFY"/> macro provides the declaration for the application-defined callback notification function to update the application on the status of the decoder.
        /// </summary>
        /// <param name="fdint">
        /// The type of notification.
        /// </param>
        /// <param name="fdin">
        /// The notification.
        /// </param>
        /// <returns>
        /// The return value, which is passed from the application to the Cabinet API.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int FNFDINOTIFY(NOTIFICATIONTYPE fdint, NOTIFICATION* fdin);

        /// <summary>
        /// The FDICreate function creates an FDI context.
        /// </summary>
        /// <param name="pfnalloc">
        /// Pointer to an application-defined callback function to allocate memory. The function should be declared using the FNALLOC macro.
        /// </param>
        /// <param name="pfnfree">
        /// Pointer to an application-defined callback function to free previously allocated memory. The function should be declared using the FNFREE macro.
        /// </param>
        /// <param name="pfnopen">
        /// Pointer to an application-defined callback function to open a file. The function should be declared using the FNOPEN macro.
        /// </param>
        /// <param name="pfnread">
        /// Pointer to an application-defined callback function to read data from a file. The function should be declared using the FNREAD macro.
        /// </param>
        /// <param name="pfnwrite">
        /// Pointer to an application-defined callback function to write data to a file. The function should be declared using the FNWRITE macro.
        /// </param>
        /// <param name="pfnclose">
        /// Pointer to an application-defined callback function to close a file. The function should be declared using the FNCLOSE macro.
        /// </param>
        /// <param name="pfnseek">
        /// Pointer to an application-defined callback function to move a file pointer to the specified location. The function should be declared using the FNSEEK macro.
        /// </param>
        /// <param name="cpuType">
        /// In the 16-bit version of FDI, specifies the CPU type and can be any of the following values.
        /// </param>
        /// <param name="perf">
        /// Pointer to an ERF structure that receives the error information.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a non-<see cref="IntPtr.Zero"/> HFDI context pointer; otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport(nameof(Cabinet), CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern FdiHandle FDICreate(
            FNALLOC pfnalloc,
            FNFREE pfnfree,
            FNOPEN pfnopen,
            FNREAD pfnread,
            FNWRITE pfnwrite,
            FNCLOSE pfnclose,
            FNSEEK pfnseek,
            CpuType cpuType,
            [Friendly(FriendlyFlags.Out)] ERF* perf);

        /// <summary>
        /// The FDICopy function extracts files from cabinets.
        /// </summary>
        /// <param name="hfdi">
        /// A valid FDI context handle returned by the FDICreate function.
        /// </param>
        /// <param name="pszCabinet">
        /// The name of the cabinet file, excluding any path information, from which to extract files.
        /// If a file is split over multiple cabinets, FDICopy allows for subsequent cabinets to be opened.
        /// </param>
        /// <param name="pszCabPath">
        /// The pathname of the cabinet file, but not including the name of the file itself. For example, "C:\MyCabs".
        /// The contents of pszCabinet are appended to pszCabPath to create the full pathname of the cabinet.
        /// </param>
        /// <param name="flags">
        /// No flags are currently defined and this parameter should be set to zero.
        /// </param>
        /// <param name="pfnfdin">
        /// An application-defined callback notification function to update the application on the status of the decoder.
        /// </param>
        /// <param name="pfnfdid">
        /// Not currently used by FDI. This parameter should be set to <see langword="null"/>.
        /// </param>
        /// <param name="pvUser">
        /// Pointer to an application-specified value to pass to the notification function.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </returns>
        [DllImport(nameof(Cabinet), CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool FDICopy(
            FdiHandle hfdi,
            string pszCabinet,
            string pszCabPath,
            int flags,
            FNFDINOTIFY pfnfdin,
            void* pfnfdid,
            void* pvUser);

        /// <summary>
        /// The FDIDestroy function deletes an open FDI context.
        /// </summary>
        /// <param name="hfdi">
        /// A valid FDI context handle returned by the FDICreate function.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </returns>
        [DllImport(nameof(Cabinet), CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FDIDestroy(IntPtr hfdi);
    }
}
