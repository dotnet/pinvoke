// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ERF"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// The ERF structure contains error information from FCI/FDI. The caller should not modify this structure.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/fdi_fci_types/ns-fdi_fci_types-erf"/>
        public struct ERF
        {
            /// <summary>
            /// An FCI/FDI error code.
            /// </summary>
            public FdiError Oper;

            /// <summary>
            /// An optional error value filled in by FCI/FDI. For FCI, this is usually the C runtime errno value.
            /// </summary>
            public int Type;

            /// <summary>
            /// A flag that indicates an error. If <see langword="true"/>, an error is present.
            /// </summary>
            public int Error;
        }
    }
}
