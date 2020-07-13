// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;

    /// <content>
    /// Exported functions from the NTDll.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class NTDll
    {
        /// <summary>
        /// Converts the specified NTSTATUS code to its equivalent system error code.
        /// </summary>
        /// <param name="Status">The NTSTATUS code to be converted.</param>
        /// <returns>The function returns the corresponding system error code.</returns>
        /// <remarks>
        /// There is no function that provides the inverse functionality of RtlNtStatusToDosError, which would convert a system error code to its corresponding NTSTATUS code.
        /// ERROR_MR_MID_NOT_FOUND is returned when the specified NTSTATUS code does not have a corresponding system error code.
        /// </remarks>
        [DllImport(nameof(NTDll))]
        public static extern Win32ErrorCode RtlNtStatusToDosError(NTSTATUS Status);

        /// <summary>
        /// The NtOpenSection routine opens a handle for an existing section object.
        /// </summary>
        /// <param name="sectionHandle">Pointer to a HANDLE variable that receives a handle to the section object.</param><param name="desiredAccess">Specifies an ACCESS_MASK value that determines the requested access to the object.</param><param name="objectAttributes">Pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes to initialize this structure.</param>
        /// <returns>
        /// Returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/> on success, or the appropriate <see cref="NTSTATUS"/> error code on failure.
        /// </returns>
        [DllImport(nameof(NTDll), CharSet = CharSet.Unicode)]
        public static extern unsafe NTSTATUS NtOpenSection(
            out SafeNTObjectHandle sectionHandle,
            Kernel32.ACCESS_MASK desiredAccess,
            [Friendly(FriendlyFlags.In)] OBJECT_ATTRIBUTES* objectAttributes);

        /// <summary>
        /// The <see cref="RtlVerifyVersionInfo(Kernel32.OSVERSIONINFOEX*, Kernel32.VER_MASK, long)"/> routine compares a specified set of operating system version requirements to the
        /// corresponding attributes of the currently running version of the operating system.
        /// </summary>
        /// <param name="VersionInfo">Pointer to an <see cref="Kernel32.OSVERSIONINFOEX"/> structure that specifies the
        /// operating system version requirements to compare to the corresponding attributes of the currently running
        /// version of the operating system.</param>
        /// <param name="TypeMask">Specifies which members of VersionInfo to compare with the corresponding attributes of
        /// the currently running version of the operating system.</param>
        /// <param name="ConditionMask">Specifies how to compare each VersionInfo member. To set the value of ConditionMask,
        /// a caller should use the <see cref="Kernel32.VerSetConditionMask(long, Kernel32.VER_MASK, Kernel32.VER_CONDITION)"/> function.</param>
        /// <returns>
        ///     <see cref="NTSTATUS.Code.STATUS_SUCCESS"/> when the specified version matches the currently running version of the operating system.
        ///     <see cref="NTSTATUS.Code.STATUS_INVALID_PARAMETER"/> when the input parameters are not valid.
        ///     <see cref="NTSTATUS.Code.STATUS_REVISION_MISMATCH"/> when the specified version does not match the currently running version of the operating system.
        /// </returns>
        /// <remarks>
        ///     See remarks in <see cref="Kernel32.VerifyVersionInfo(Kernel32.OSVERSIONINFOEX*, Kernel32.VER_MASK, long)"/>.
        ///
        ///     Unmanifested applications that call <see cref="RtlVerifyVersionInfo(Kernel32.OSVERSIONINFOEX*, Kernel32.VER_MASK, long)"/> are not
        ///     suspectible to version-lies by the OS.
        /// </remarks>
        [DllImport(nameof(NTDll))]
        public static unsafe extern NTSTATUS RtlVerifyVersionInfo(
            [Friendly(FriendlyFlags.Bidirectional)] Kernel32.OSVERSIONINFOEX* VersionInfo,
            Kernel32.VER_MASK TypeMask,
            long ConditionMask);

        /// <summary>
        /// Retrieves information about the specified process.
        /// </summary>
        /// <param name="ProcessHandle">
        /// A handle to the process for which information is to be retrieved.
        /// </param>
        /// <param name="ProcessInformationClass">
        /// The type of process information to be retrieved.
        /// </param>
        /// <param name="ProcessInformation">
        /// A pointer to a buffer supplied by the calling application into which the function writes the requested information.
        /// </param>
        /// <param name="ProcessInformationLength">
        /// The size of the buffer pointed to by the <paramref name="ProcessInformation"/> parameter, in bytes.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable in which the function returns the size of the requested information. If the function
        /// was successful, this is the size of the information written to the buffer pointed to by the
        /// ProcessInformation parameter, but if the buffer was too small, this is the minimum size of buffer needed
        /// to receive the information successfully.
        /// </param>
        /// <returns>
        /// The function returns an NTSTATUS success or error code.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms684280(v=vs.85).aspx"/>
        [DllImport(nameof(NTDll))]
        public static unsafe extern NTSTATUS NtQueryInformationProcess(
            Kernel32.SafeObjectHandle ProcessHandle,
            PROCESSINFOCLASS ProcessInformationClass,
            void* ProcessInformation,
            int ProcessInformationLength,
            out int ReturnLength);

        /// <summary>
        /// The <see cref="RtlGetVersion(Kernel32.OSVERSIONINFO*)"/> routine returns version information about the currently running operating system.
        /// </summary>
        /// <param name="versionInformation">
        /// A pointer to an <see cref="Kernel32.OSVERSIONINFO"/> or <see cref="Kernel32.OSVERSIONINFOEX"/> structure that contains the version information about the currently running operating system.
        /// </param>
        /// <returns>
        /// <see cref="RtlGetVersion(Kernel32.OSVERSIONINFO*)"/> returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/>.
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlgetversion"/>
        [DllImport(nameof(NTDll), SetLastError = true)]
        public static unsafe extern NTSTATUS RtlGetVersion(
            [Friendly(FriendlyFlags.Bidirectional)] Kernel32.OSVERSIONINFO* versionInformation);

        /// <summary>
        /// The NtClose routine closes an object handle.
        /// </summary>
        /// <param name="handle">Handle to an object of any type.</param>
        /// <returns>
        /// Returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/> on success, or the appropriate <see cref="NTSTATUS"/> error code on failure.
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(NTDll))]
        private static extern NTSTATUS NtClose(IntPtr handle);
    }
}
