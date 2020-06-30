// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FileSystemFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags associated with a file system.
        /// </summary>
        [Flags]
        public enum FileSystemFlags : uint
        {
            /// <summary>
            /// The file system supports case-sensitive file names.
            /// </summary>
            FILE_CASE_SENSITIVE_SEARCH = 1,

            /// <summary>
            /// The file system preserves the case of file names when it places a name on disk.
            /// </summary>
            FILE_CASE_PRESERVED_NAMES = 2,

            /// <summary>
            /// The file system supports Unicode in file names as they appear on disk.
            /// </summary>
            FILE_UNICODE_ON_DISK = 4,

            /// <summary>
            /// The file system preserves and enforces access control lists (ACL).
            /// </summary>
            FILE_PERSISTENT_ACLS = 8,

            /// <summary>
            /// The file system supports file-based compression.
            /// </summary>
            FILE_FILE_COMPRESSION = 0x10,

            /// <summary>
            /// The file system supports disk quotas.
            /// </summary>
            FILE_VOLUME_QUOTAS = 0x20,

            /// <summary>
            /// The file system supports sparse files.
            /// </summary>
            FILE_SUPPORTS_SPARSE_FILES = 0x40,

            /// <summary>
            /// The file system supports re-parse points.
            /// </summary>
            FILE_SUPPORTS_REPARSE_POINTS = 0x80,

            /// <summary>
            /// The specified volume is a compressed volume, for example, a DoubleSpace volume.
            /// </summary>
            FILE_VOLUME_IS_COMPRESSED = 0x8000,

            /// <summary>
            /// The file system supports object identifiers.
            /// </summary>
            FILE_SUPPORTS_OBJECT_IDS = 0x10000,

            /// <summary>
            /// The file system supports the Encrypted File System (EFS).
            /// </summary>
            FILE_SUPPORTS_ENCRYPTION = 0x20000,

            /// <summary>
            /// The file system supports named streams.
            /// </summary>
            FILE_NAMED_STREAMS = 0x40000,

            /// <summary>
            /// The specified volume is read-only.
            /// </summary>
            FILE_READ_ONLY_VOLUME = 0x80000,

            /// <summary>
            /// The volume supports a single sequential write.
            /// </summary>
            FILE_SEQUENTIAL_WRITE_ONCE = 0x100000,

            /// <summary>
            /// The volume supports transactions.
            /// </summary>
            FILE_SUPPORTS_TRANSACTIONS = 0x200000,

            /// <summary>
            /// The specified volume supports hard links.
            /// </summary>
            FILE_SUPPORTS_HARD_LINKS = 0x00400000,

            /// <summary>
            /// The specified volume supports extended attributes.
            /// An extended attribute is a piece of application-specific metadata that an application can associate
            /// with a file and is not part of the file's data.
            /// </summary>
            FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000,

            /// <summary>
            /// The file system supports open by FileID.
            /// </summary>
            FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000,

            /// <summary>
            /// The specified volume supports update sequence number (USN) journals.
            /// </summary>
            FILE_SUPPORTS_USN_JOURNAL = 0x02000000,

            /// <summary>
            /// The specified volume is a direct access (DAX) volume.
            /// </summary>
            FILE_DAX_VOLUME = 0x20000000,
        }
    }
}
