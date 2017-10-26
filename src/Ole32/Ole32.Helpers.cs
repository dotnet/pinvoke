// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Ole32
    {
        // This is where you define methods that assist in calling P/Invoke methods.
        // For example, if a P/Invoke method requires allocating unmanaged memory
        // and freeing it up after the call, a helper method in this file would
        // make "P/Invoking" for most callers much easier and is a welcome addition.

        /// <summary>
        /// Enables cancellation of synchronous calls on the calling thread.
        /// </summary>
        /// <returns>This function can return the standard return values <see cref="HResult.Code.S_OK"/>, <see cref="HResult.Code.E_FAIL"/>, <see cref="HResult.Code.E_INVALIDARG"/>, and <see cref="HResult.Code.E_OUTOFMEMORY"/>.</returns>
        public static HResult CoEnableCallCancellation()
        {
            return CoEnableCallCancellation(IntPtr.Zero);
        }

        /// <summary>
        /// Undoes the action of a call to <see cref="CoEnableCallCancellation()"/>. Disables cancellation of synchronous calls on the calling thread when all calls to CoEnableCallCancellation are balanced by calls to CoDisableCallCancellation.
        /// </summary>
        /// <returns>This function can return the standard return values <see cref="HResult.Code.E_FAIL"/>, <see cref="HResult.Code.E_INVALIDARG"/>, <see cref="HResult.Code.E_OUTOFMEMORY"/>, and <see cref="HResult.Code.E_UNEXPECTED"/>, as well as the following values.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Return code</term>
        ///         <term>Description</term>
        ///     </listheader>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.S_OK"/></c></term>
        ///         <term>Call cancellation was successfully disabled on the thread.</term>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.CO_E_CANCEL_DISABLED"/></c></term>
        ///         <term>There have been more successful calls to CoEnableCallCancellation on the thread than there have been calls to CoDisableCallCancellation. Cancellation is still enabled on the thread.</term>
        ///     </item>
        /// </list>
        /// </returns>
        public static HResult CoDisableCallCancellation()
        {
            return CoDisableCallCancellation(IntPtr.Zero);
        }
    }
}
