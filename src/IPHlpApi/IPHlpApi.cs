// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the IPHlpApi.dll Windows library.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class IPHlpApi
    {
        /// <summary>
        /// The <see cref="IPHlpApi.GetExtendedTcpTable(void*, ref int, bool, AddressFamily, TCP_TABLE_CLASS, uint)"/> function retrieves a table that contains a list of TCP
        /// endpoints available to the application.
        /// </summary>
        /// <param name="pTcpTable">
        /// A pointer to the table structure that contains the filtered TCP endpoints available to
        /// the application. For information about how to determine the type of table returned
        /// based on specific input parameter combinations, see the Remarks section later in this
        /// document.
        /// </param>
        /// <param name="pdwSize">
        /// The estimated size of the structure returned in <paramref name="pTcpTable"/>, in bytes. If this value is
        /// set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field
        /// will contain the correct size of the structure.
        /// </param>
        /// <param name="bOrder">
        /// A value that specifies whether the TCP connection table should be sorted. If this parameter
        /// is set to <see langword="true"/>, the TCP endpoints in the table are sorted in ascending order, starting
        /// with the lowest local IP address. If this parameter is set to <see langword="false"/>, the TCP endpoints
        /// in the table appear in the order in which they were retrieved.
        /// </param>
        /// <param name="ulAf">
        /// The version of IP used by the TCP endpoints.
        /// </param>
        /// <param name="TableClass">
        /// <para>
        /// The type of the TCP table structure to retrieve. This parameter can be one of the
        /// values from the <see cref="TCP_TABLE_CLASS"/> enumeration.
        /// </para>
        /// <para>
        /// The <see cref="TCP_TABLE_CLASS"/> enumeration value is combined with the value of the <paramref name="ulAf"/> parameter
        /// to determine the extended TCP information to retrieve.
        /// </para>
        /// </param>
        /// <param name="Reserved">
        /// Reserved. This value must be zero.
        /// </param>
        /// <returns>
        /// If the call is successful, the value NO_ERROR is returned.
        /// </returns>
        /// <seealso href="http://msdn2.microsoft.com/en-us/library/aa365928.aspx"/>
        [DllImport(nameof(IPHlpApi), SetLastError = true)]
        public static unsafe extern Win32ErrorCode GetExtendedTcpTable(
            void* pTcpTable,
            ref int pdwSize,
            bool bOrder,
            AddressFamily ulAf,
            TCP_TABLE_CLASS TableClass,
            uint Reserved);
    }
}
