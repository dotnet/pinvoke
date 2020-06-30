// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="OVERLAPPED"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>Contains information used in asynchronous (or overlapped) input and output (I/O).</summary>
        /// <remarks>
        /// Any unused members of this structure should always be initialized to zero before the structure is used in a function
        /// call. Otherwise, the function may fail and return <see cref="Win32ErrorCode.ERROR_INVALID_PARAMETER"/>.
        /// <para>
        /// The Offset and OffsetHigh members together represent a 64-bit file position.It is a byte offset from the start of
        /// the file or file-like device, and it is specified by the user; the system will not modify these values.The calling
        /// process must set this member before passing the OVERLAPPED structure to functions that use an offset, such as the
        /// ReadFile or WriteFile (and related) functions.
        /// </para>
        /// <para>
        /// You can use the HasOverlappedIoCompleted macro to check whether an asynchronous I/O operation has completed if
        /// GetOverlappedResult is too cumbersome for your application.
        /// </para>
        /// <para>You can use the CancelIo function to cancel an asynchronous I/O operation.</para>
        /// <para>
        /// A common mistake is to reuse an OVERLAPPED structure before the previous asynchronous operation has been
        /// completed. You should use a separate structure for each request. You should also create an event object for each thread
        /// that processes data. If you store the event handles in an array, you could easily wait for all events to be signaled
        /// using the WaitForMultipleObjects function.
        /// </para>
        /// </remarks>
        public struct OVERLAPPED
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
