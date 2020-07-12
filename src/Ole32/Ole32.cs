// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the Ole32.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Ole32
    {
        /// <summary>
        /// Enables cancellation of synchronous calls on the calling thread.
        /// </summary>
        /// <param name="pReserved">This parameter is reserved and must be NULL (<see cref="IntPtr.Zero"/>).</param>
        /// <returns>This function can return the standard return values <see cref="HResult.Code.S_OK"/>, <see cref="HResult.Code.E_FAIL"/>, <see cref="HResult.Code.E_INVALIDARG"/>, and <see cref="HResult.Code.E_OUTOFMEMORY"/>.</returns>
        [DllImport(nameof(Ole32))]
        public static extern unsafe HResult CoEnableCallCancellation(void* pReserved);

        /// <summary>
        /// Undoes the action of a call to <see cref="CoEnableCallCancellation(IntPtr)"/>. Disables cancellation of synchronous calls on the calling thread when all calls to CoEnableCallCancellation are balanced by calls to CoDisableCallCancellation.
        /// </summary>
        /// <param name="pReserved">This parameter is reserved and must be NULL (<see cref="IntPtr.Zero"/>).</param>
        /// <returns>This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
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
        [DllImport(nameof(Ole32))]
        public static extern unsafe HResult CoDisableCallCancellation(void* pReserved);

        /// <summary>
        /// Requests cancellation of an outbound DCOM method call pending on a specified thread.
        /// </summary>
        /// <param name="dwThreadId">The identifier of the thread on which the pending DCOM call is to be canceled. If this parameter is 0, the call is on the current thread.</param>
        /// <param name="ulTimeout">The number of seconds <see cref="CoCancelCall"/> waits for the server to complete the outbound call after the client requests cancellation.</param>
        /// <returns>This function can return the standard return values E_FAIL, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Return code</term>
        ///         <term>Description</term>
        ///     </listheader>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.S_OK"/></c></term>
        ///         <term>The cancellation request was made.</term>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.E_NOINTERFACE"/></c></term>
        ///         <term><c>There is no cancel object corresponding to the specified thread.</c></term>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.CO_E_CANCEL_DISABLED"/></c></term>
        ///         <term>Call cancellation is not enabled on the specified thread.</term>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.RPC_E_CALL_COMPLETE"/></c></term>
        ///         <term>The call was completed during the timeout interval.</term>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="HResult.Code.RPC_E_CALL_CANCELED"/></c></term>
        ///         <term>The call was already canceled.</term>
        ///     </item>
        /// </list></returns>
        /// <remarks>
        /// <paramref name="dwThreadId"/> is the ID of the native thread (typically obtained by
        /// calling GetCurrentThreadId or GetThreadId functions. This is not the same as the
        /// managed thread ID returned by System.Threading.Thread.ManagedThreadId or System.Environment.CurrentManagedThreadId.
        /// </remarks>
        [DllImport(nameof(Ole32))]
        public static extern HResult CoCancelCall(int dwThreadId, int ulTimeout);
    }
}
