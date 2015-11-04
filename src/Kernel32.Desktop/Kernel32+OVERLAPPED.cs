// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="OVERLAPPED"/> nested class.
    /// </content>
    public partial class Kernel32
    {
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        [StructLayout(LayoutKind.Sequential)]
        public class OVERLAPPED
        {
            /// <summary>
            /// The status code for the I/O request. When the request is issued, the system sets this member to STATUS_PENDING to indicate that the operation has not yet started. When the request is completed, the system sets this member to the status code for the completed request.
            /// <para>The Internal member was originally reserved for system use and its behavior may change.</para>
            /// </summary>
            public IntPtr Internal;

            /// <summary>
            /// The number of bytes transferred for the I/O request. The system sets this member if the request is completed without errors.
            /// <para>The InternalHigh member was originally reserved for system use and its behavior may change.</para>
            /// </summary>
            public IntPtr InternalHigh;

            /// <summary>
            /// The low-order portion of the file position at which to start the I/O request, as specified by the user.
            /// <para>This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset(also referred to as a file pointer mechanism), such as a file.Otherwise, this member must be zero.</para>
            /// <para>For additional information, see Remarks.</para>
            /// </summary>
            public int Offset;

            /// <summary>
            /// The high-order portion of the file position at which to start the I/O request, as specified by the user.
            /// <para>This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset(also referred to as a file pointer mechanism), such as a file.Otherwise, this member must be zero.</para>
            /// <para>For additional information, see Remarks.</para>
            /// </summary>
            public int OffsetHigh;

            /// <summary>
            /// A handle to the event that will be set to a signaled state by the system when the operation has completed. The user must initialize this member either to zero or a valid event handle using the CreateEvent function before passing this structure to any overlapped functions. This event can then be used to synchronize simultaneous I/O requests for a device. For additional information, see Remarks.
            /// <para>Functions such as ReadFile and WriteFile set this handle to the nonsignaled state before they begin an I/O operation.When the operation has completed, the handle is set to the signaled state.</para>
            /// <para>Functions such as GetOverlappedResult and the synchronization wait functions reset auto-reset events to the nonsignaled state. Therefore, you should use a manual reset event; if you use an auto-reset event, your application can stop responding if you wait for the operation to complete and then call GetOverlappedResult with the bWait parameter set to TRUE.</para>
            /// </summary>
            public IntPtr hEvent;
        }
    }
}
