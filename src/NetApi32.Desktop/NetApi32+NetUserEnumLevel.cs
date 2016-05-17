// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="NetUserEnumLevel"/> nested type.
    /// </content>
    public partial class NetApi32
    {
        /// <summary>
        /// Allowed values for the level parameter of the <see cref="NetUserEnum(string, NetUserEnumLevel, NetUserEnumFilter, byte*, uint, out uint, out uint, ref uint)"/> function.
        /// </summary>
        public enum NetUserEnumLevel : uint
        {
            /// <summary>
            /// Return user account names. The bufptr parameter points to an array of <see cref="USER_INFO_0"/> structures.
            /// </summary>
            Level_0 = 0,

            /// <summary>
            /// Return detailed information about user accounts. The bufptr parameter points to an array of <see cref="USER_INFO_1"/> structures.
            /// </summary>
            Level_1 = 1,

            /// <summary>
            /// Return detailed information about user accounts, including authorization levels and logon information. The bufptr parameter points to an array of USER_INFO_2 structures.
            /// </summary>
            Level_2 = 2,

            /// <summary>
            /// Return detailed information about user accounts, including authorization levels, logon information, RIDs for the user and the primary group, and profile information. The bufptr parameter points to an array of USER_INFO_3 structures.
            /// </summary>
            Level_3 = 3,

            /// <summary>
            /// Return user and account names and comments. The bufptr parameter points to an array of USER_INFO_10 structures.
            /// </summary>
            Level_10 = 10,

            /// <summary>
            /// Return detailed information about user accounts. The bufptr parameter points to an array of USER_INFO_11 structures.
            /// </summary>
            Level_11 = 11,

            /// <summary>
            /// Return the user's name and identifier and various account attributes. The bufptr parameter points to an array of USER_INFO_20 structures. Note that on Windows XP and later, it is recommended that you use USER_INFO_23 instead.
            /// </summary>
            Level_20 = 20,
        }
    }
}
