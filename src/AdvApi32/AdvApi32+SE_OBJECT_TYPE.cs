// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SE_OBJECT_TYPE"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// The SE_OBJECT_TYPE enumeration contains values that correspond to the types of Windows objects that support security.
        /// The functions, such as <see cref="GetSecurityInfo(System.IntPtr, SE_OBJECT_TYPE, SECURITY_INFORMATION, ref void*, ref void*, Kernel32.ACL*, Kernel32.ACL*, Kernel32.SECURITY_DESCRIPTOR*)"/> and <see cref="SetSecurityInfo(System.IntPtr, SE_OBJECT_TYPE, SECURITY_INFORMATION, void*, void*, Kernel32.ACL*, Kernel32.ACL*)"/>, that set and retrieve the security information of an object,
        /// use these values to indicate the type of object.
        /// </summary>
        public enum SE_OBJECT_TYPE
        {
            /// <summary>
            /// Unknown object type.
            /// </summary>
            SE_UNKNOWN_OBJECT_TYPE = 0,

            /// <summary>
            /// Indicates a file or directory. The name string that identifies a file or directory object can be in one of the following formats:
            /// <list>
            /// <item>A relative path, such as FileName.dat or ..\FileName</item>
            /// <item>An absolute path, such as FileName.dat, C:\DirectoryName\FileName.dat, or G:\RemoteDirectoryName\FileName.dat.</item>
            /// <item>A UNC name, such as \\ComputerName\ShareName\FileName.dat.</item>
            /// </list>
            /// </summary>
            SE_FILE_OBJECT,

            /// <summary>
            /// Indicates a Windows service. A service object can be a local service, such as ServiceName, or a remote service, such as \\ComputerName\ServiceName.
            /// </summary>
            SE_SERVICE,

            /// <summary>
            /// Indicates a printer. A printer object can be a local printer, such as PrinterName, or a remote printer, such as \\ComputerName\PrinterName.
            /// </summary>
            SE_PRINTER,

            /// <summary>
            /// Indicates a registry key. A registry key object can be in the local registry, such as CLASSES_ROOT\SomePath or in a remote registry, such as \\ComputerName\CLASSES_ROOT\SomePath.
            /// The names of registry keys must use the following literal strings to identify the predefined registry keys: "CLASSES_ROOT", "CURRENT_USER", "MACHINE", and "USERS".
            /// </summary>
            SE_REGISTRY_KEY,

            /// <summary>
            /// Indicates a network share. A share object can be local, such as ShareName, or remote, such as \\ComputerName\ShareName.
            /// </summary>
            SE_LMSHARE,

            /// <summary>
            /// Indicates a local kernel object.
            /// The <see cref="GetSecurityInfo(System.IntPtr, SE_OBJECT_TYPE, SECURITY_INFORMATION, ref void*, ref void*, Kernel32.ACL*, Kernel32.ACL*, Kernel32.SECURITY_DESCRIPTOR*)"/> and <see cref="SetSecurityInfo(System.IntPtr, SE_OBJECT_TYPE, SECURITY_INFORMATION, void*, void*, Kernel32.ACL*, Kernel32.ACL*)"/> functions support all types of kernel objects.
            /// The <see cref="GetNamedSecurityInfo(string, SE_OBJECT_TYPE, SECURITY_INFORMATION, ref void*, ref void*, Kernel32.ACL*, Kernel32.ACL*, Kernel32.SECURITY_DESCRIPTOR*)"/> and <see cref="SetNamedSecurityInfo(string, SE_OBJECT_TYPE, SECURITY_INFORMATION, void*, void*, Kernel32.ACL*, Kernel32.ACL*)"/> functions work only with the following kernel objects:
            /// <list>
            /// <item>semaphore</item>
            /// <item>event</item>
            /// <item>mutex</item>
            /// <item>waitable timer</item>
            /// <item>file mapping</item>
            /// </list>
            /// </summary>
            SE_KERNEL_OBJECT,

            /// <summary>
            /// Indicates a window station or desktop object on the local computer.
            /// You cannot use <see cref="GetNamedSecurityInfo(string, SE_OBJECT_TYPE, SECURITY_INFORMATION, ref void*, ref void*, Kernel32.ACL*, Kernel32.ACL*, Kernel32.SECURITY_DESCRIPTOR*)"/> and <see cref="SetNamedSecurityInfo(string, SE_OBJECT_TYPE, SECURITY_INFORMATION, void*, void*, Kernel32.ACL*, Kernel32.ACL*)"/> with these objects because the names of window stations or desktops are not unique.
            /// </summary>
            SE_WINDOW_OBJECT,

            /// <summary>
            /// Indicates a directory service object or a property set or property of a directory service object. The name string for a directory service object must be in X.500 form, for example:
            ///  CN = SomeObject, OU = ou2, OU = ou1, DC = DomainName, DC = CompanyName, DC = com, O = internet
            /// </summary>
            SE_DS_OBJECT,

            /// <summary>
            /// Indicates a directory service object and all of its property sets and properties.
            /// </summary>
            SE_DS_OBJECT_ALL,

            /// <summary>
            /// Indicates a provider-defined object.
            /// </summary>
            SE_PROVIDER_DEFINED_OBJECT,

            /// <summary>
            /// Indicates a WMI object.
            /// </summary>
            SE_WMIGUID_OBJECT,

            /// <summary>
            /// Indicates an object for a registry entry under WOW64.
            /// </summary>
            SE_REGISTRY_WOW64_32KEY,
        }
    }
}