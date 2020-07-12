// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the nested <see cref="FileAttribute"/> type.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>Defines the Win32 FileAttributes enum.</summary>
        /// <remarks>
        ///     This is similar to the System.IO.FileAttributes enum, but that enum is not available in the portable profile,
        ///     although it is allowed to call certain file methods via P/Invoke in Windows Store apps, per MSDN docs. A value
        ///     typed as this enum may be safely cast to the System.IO.FileAttributes enum, as all the value names have equal
        ///     ordinal values.
        /// </remarks>
        [Flags]
        public enum FileAttribute
        {
            /// <summary>
            ///     A file or directory that is an archive file or directory. Applications typically use this attribute to mark
            ///     files for backup or removal.
            /// </summary>
            FILE_ATTRIBUTE_ARCHIVE = 0x20,

            /// <summary>
            ///     A file or directory that is compressed. For a file, all of the data in the file is compressed. For a
            ///     directory, compression is the default for newly created files and subdirectories.
            /// </summary>
            FILE_ATTRIBUTE_COMPRESSED = 0x800,

            /// <summary>This value is reserved for system use.</summary>
            FILE_ATTRIBUTE_DEVICE = 0x40,

            /// <summary>The handle that identifies a directory.</summary>
            FILE_ATTRIBUTE_DIRECTORY = 0x10,

            /// <summary>
            ///     A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a
            ///     directory, encryption is the default for newly created files and subdirectories.
            /// </summary>
            FILE_ATTRIBUTE_ENCRYPTED = 0x4000,

            /// <summary>The file or directory is hidden. It is not included in an ordinary directory listing.</summary>
            FILE_ATTRIBUTE_HIDDEN = 0x2,

            /// <summary>
            ///     The directory or user data stream is configured with integrity (only supported on ReFS volumes). It is not
            ///     included in an ordinary directory listing. The integrity setting persists with the file if it's renamed. If a file
            ///     is copied the destination file will have integrity set if either the source file or destination directory have
            ///     integrity set.
            /// </summary>
            FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x8000,

            /// <summary>A file that does not have other attributes set. This attribute is valid only when used alone.</summary>
            FILE_ATTRIBUTE_NORMAL = 0x80,

            /// <summary>The file or directory is not to be indexed by the content indexing service.</summary>
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x2000,

            /// <summary>
            ///     The user data stream not to be read by the background data integrity scanner (AKA scrubber). When set on a
            ///     directory it only provides inheritance. This flag is only supported on Storage Spaces and ReFS volumes. It is not
            ///     included in an ordinary directory listing.
            /// </summary>
            FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x20000,

            /// <summary>
            ///     The data of a file is not available immediately. This attribute indicates that the file data is physically
            ///     moved to offline storage. This attribute is used by Remote Storage, which is the hierarchical storage management
            ///     software. Applications should not arbitrarily change this attribute.
            /// </summary>
            FILE_ATTRIBUTE_OFFLINE = 0x1000,

            /// <summary>
            ///     A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute
            ///     is not honored on directories.
            /// </summary>
            FILE_ATTRIBUTE_READONLY = 0x1,

            /// <summary>A file or directory that has an associated reparse point, or a file that is a symbolic link.</summary>
            FILE_ATTRIBUTE_REPARSE_POINT = 0x400,

            /// <summary>A file that is a sparse file.</summary>
            FILE_ATTRIBUTE_SPARSE_FILE = 0x200,

            /// <summary>A file or directory that the operating system uses a part of, or uses exclusively.</summary>
            FILE_ATTRIBUTE_SYSTEM = 0x4,

            /// <summary>
            ///     A file that is being used for temporary storage. File systems avoid writing data back to mass storage if
            ///     sufficient cache memory is available, because typically, an application deletes a temporary file after the handle
            ///     is closed. In that scenario, the system can entirely avoid writing the data. Otherwise, the data is written after
            ///     the handle is closed.
            /// </summary>
            FILE_ATTRIBUTE_TEMPORARY = 0x100,

            /// <summary>This value is reserved for system use.</summary>
            FILE_ATTRIBUTE_VIRTUAL = 0x10000,
        }
    }
}
