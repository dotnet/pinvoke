// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="USER_INFO_1"/> nested type.
    /// </content>
    public partial class NetApi32
    {
        /// <summary>
        /// The USER_INFO_1 structure contains information about a user account, including account name, password data, privilege level, and the path to the user's home directory.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        [StructLayout(LayoutKind.Sequential)]
        public unsafe partial struct USER_INFO_1
        {
            /// <summary>
            /// Pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member specifies the name of the user.
            /// </summary>
            /// <remarks>
            /// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot be terminated by a period and they cannot include commas or any of the following printable characters: ", /, \, [, ], :, |, &lt;, &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are nonprintable.
            /// </remarks>
            public char* usri1_name;

            /// <summary>
            /// A pointer to a Unicode string that specifies the password of the user indicated by the <see cref="usri1_name"/> member. The length cannot exceed PWLEN bytes. The NetUserEnum and NetUserGetInfo functions return a NULL pointer to maintain password security.
            /// By convention, the length of passwords is limited to LM20_PWLEN characters.
            /// </summary>
            public char* usri1_password;

            /// <summary>
            /// The number of seconds that have elapsed since the usri1_password member was last changed. The NetUserAdd and NetUserSetInfo functions ignore this member.
            /// </summary>
            public uint usri1_password_age;

            /// <summary>
            /// The level of privilege assigned to the usri1_name member. When you call the NetUserAdd function, this member must be USER_PRIV_USER. When you call the NetUserSetInfo function, this member must be the value returned by the NetUserGetInfo function or the NetUserEnum function. This member can be one of the following values. For more information about user and group account rights, see Privileges.
            /// </summary>
            public Privilege usri1_priv;

            /// <summary>
            /// A pointer to a Unicode string specifying the path of the home directory for the user specified in the usri1_name member. The string can be NULL.
            /// </summary>
            public char* usri1_home_dir;

            /// <summary>
            /// A pointer to a Unicode string that contains a comment to associate with the user account. This string can be a NULL string, or it can have any number of characters before the terminating null character.
            /// </summary>
            public char* usri1_comment;

            /// <summary>
            /// This member can be one or more of the following values. Note that setting user account control flags may require certain privileges and control access rights. For more information, see the Remarks section of the NetUserSetInfo function.
            /// </summary>
            public Flags usri1_flags;

            /// <summary>
            /// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an .EXE file, or a .BAT file. The string can also be NULL.
            /// </summary>
            public char* usri1_script_path;

            /// <summary>
            /// Possible values for the <see cref="usri1_priv"/> field.
            /// </summary>
            public enum Privilege
            {
                /// <summary>
                /// Guest
                /// </summary>
                USER_PRIV_GUEST = 0,

                /// <summary>
                /// User
                /// </summary>
                USER_PRIV_USER = 1,

                /// <summary>
                /// Administrator
                /// </summary>
                USER_PRIV_ADMIN = 2,
            }

            /// <summary>
            /// Possible values for the <see cref="usri1_flags"/> field.
            /// </summary>
            [Flags]
            public enum Flags : uint
            {
                /// <summary>
                /// The logon script executed. This value must be set.
                /// </summary>
                UF_SCRIPT = 0x0001,

                /// <summary>
                /// The user's account is disabled.
                /// </summary>
                UF_ACCOUNTDISABLE = 0x0002,

                /// <summary>
                /// The home directory is required. This value is ignored.
                /// </summary>
                UF_HOMEDIR_REQUIRED = 0x0008,

                /// <summary>
                /// The account is currently locked out. You can call the NetUserSetInfo function and clear this value to unlock a previously locked account. You cannot use this value to lock a previously unlocked account.
                /// </summary>
                UF_LOCKOUT = 0x0010,

                /// <summary>
                /// No password is required.
                /// </summary>
                UF_PASSWD_NOTREQD = 0x0020,

                /// <summary>
                /// The user cannot change the password.
                /// </summary>
                UF_PASSWD_CANT_CHANGE = 0x0040,

                /// <summary>
                /// The user's password is stored under reversible encryption in the Active Directory.
                /// </summary>
                UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x0080,

                /// <summary>
                /// The password should never expire on the account.
                /// </summary>
                UF_DONT_EXPIRE_PASSWD = 0x10000,

                /// <summary>
                /// Marks the account as "sensitive"; other users cannot act as delegates of this user account.
                /// </summary>
                UF_NOT_DELEGATED = 0x100000,

                /// <summary>
                /// Requires the user to log on to the user account with a smart card.
                /// </summary>
                UF_SMARTCARD_REQUIRED = 0x40000,

                /// <summary>
                /// Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.
                /// </summary>
                UF_USE_DES_KEY_ONLY = 0x200000,

                /// <summary>
                /// This account does not require Kerberos preauthentication for logon.
                /// </summary>
                UF_DONT_REQUIRE_PREAUTH = 0x400000,

                /// <summary>
                /// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as that user to other remote servers on the network.
                /// </summary>
                UF_TRUSTED_FOR_DELEGATION = 0x80000,

                /// <summary>
                /// The user's password has expired.
                /// </summary>
                UF_PASSWORD_EXPIRED = 0x800000,

                /// <summary>
                /// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled. This setting allows a service running under the account to assert a client's identity and authenticate as that user to specifically configured services on the network.
                /// </summary>
                UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x1000000,

                /// <summary>
                /// This is an account for users whose primary account is in another domain. This account provides user access to this domain, but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
                /// </summary>
                UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,

                /// <summary>
                /// This is a default account type that represents a typical user.
                /// </summary>
                UF_NORMAL_ACCOUNT = 0x0200,

                /// <summary>
                /// This is a permit to trust account for a domain that trusts other domains.
                /// </summary>
                UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,

                /// <summary>
                /// This is a computer account for a computer that is a member of this domain.
                /// </summary>
                UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,

                /// <summary>
                /// This is a computer account for a backup domain controller that is a member of this domain.
                /// </summary>
                UF_SERVER_TRUST_ACCOUNT = 0x2000,
            }
        }
    }
}
