// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the <see cref="FdiHandle"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// Represents a handle used by the FDI API.
        /// </summary>
        public class FdiHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FdiHandle"/> class.
            /// </summary>
            public FdiHandle()
                : base(true)
            {
            }

            /// <inheritdoc/>
            protected override bool ReleaseHandle()
            {
                return Cabinet.FDIDestroy(this.handle);
            }
        }
    }
}
