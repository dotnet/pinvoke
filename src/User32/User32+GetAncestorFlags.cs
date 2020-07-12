// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="GetAncestorFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>The ancestor to be retrieved by <see cref="GetAncestor" />.</summary>
        public enum GetAncestorFlags
        {
            /// <summary>Retrieves the parent window. This does not include the owner, as it does with the GetParent function.</summary>
            GA_PARENT = 1,

            /// <summary>Retrieves the root window by walking the chain of parent windows.</summary>
            GA_ROOT = 2,

            /// <summary>Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.</summary>
            GA_ROOTOWNER = 3,
        }
    }
}
