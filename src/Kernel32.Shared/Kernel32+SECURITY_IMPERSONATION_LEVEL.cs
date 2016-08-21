// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SECURITY_IMPERSONATION_LEVEL"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains values that specify security impersonation levels. Security impersonation levels govern the degree to which a server process can act on behalf of a client process.
        /// </summary>
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            /// <summary>
            /// The server process cannot obtain identification information about the client, and it cannot impersonate the client. It is defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
            /// </summary>
            SecurityAnonymous,

            /// <summary>
            /// The server process can obtain information about the client, such as security identifiers and privileges, but it cannot impersonate the client. This is useful for servers that export their own objects, for example, database products that export tables and views. Using the retrieved client-security information, the server can make access-validation decisions without being able to use other services that are using the client's security context.
            /// </summary>
            SecurityIdentification,

            /// <summary>
            /// The server process can impersonate the client's security context on its local system. The server cannot impersonate the client on remote systems.
            /// </summary>
            SecurityImpersonation,

            /// <summary>
            /// The server process can impersonate the client's security context on remote systems.
            /// </summary>
            SecurityDelegation,
        }
    }
}
