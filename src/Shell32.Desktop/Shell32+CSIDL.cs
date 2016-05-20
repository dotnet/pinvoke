// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CSIDL"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>
        /// CSIDL (constant special item ID list) values provide a unique system-independent way to identify special folders used frequently by applications,
        /// but which may not have the same name or location on any given system. For example, the system folder may be "C:\Windows" on one system and "C:\Winnt" on another.
        /// These constants are defined in Shlobj.h.
        /// </summary>
        /// <remarks>Used by <see cref="SHGetFolderPath(IntPtr, CSIDL, IntPtr, SHGetFolderPathFlags, char*)"/></remarks>
        [Flags]
        public enum CSIDL
        {
            /// <summary>Administrative Tools</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</remarks>
            CSIDL_ADMINTOOLS = 0x0030,

            /// <summary>Temporary Burn Folder</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Burn\Burn</remarks>
            CSIDL_CDBURN_AREA = 0x003b,

            /// <summary>Administrative Tools</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</remarks>
            CSIDL_COMMON_ADMINTOOLS = 0x002f,

            /// <summary>OEM Links</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\OEM Links</remarks>
            CSIDL_COMMON_OEM_LINKS = 0x003a,

            /// <summary>Programs</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs</remarks>
            CSIDL_COMMON_PROGRAMS = 0x0017,

            /// <summary>Start Menu</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu</remarks>
            CSIDL_COMMON_STARTMENU = 0x0016,

            /// <summary>Startup</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            CSIDL_COMMON_STARTUP = 0x0018,

            /// <summary>Startup</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            CSIDL_COMMON_ALTSTARTUP = 0x001e,

            /// <summary>Templates</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Templates</remarks>
            CSIDL_COMMON_TEMPLATES = 0x002d,

            /// <summary>Computer</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_DRIVES = 0x0011,

            /// <summary>Network Connections</summary>
            /// <remarks>Maps to virtual folder</remarks>
            CSIDL_CONNECTIONS = 0x0031,

            /// <summary>Account Pictures</summary>
            /// <remarks>Maps to virtual folder</remarks>
            CSIDL_CONTROLS = 0x0003,

            /// <summary>Cookies</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Cookies</remarks>
            CSIDL_COOKIES = 0x0021,

            /// <summary>Desktop</summary>
            /// <remarks>Maps to %USERPROFILE%\Desktop</remarks>
            CSIDL_DESKTOP = 0x0000,

            /// <summary>Desktop</summary>
            /// <remarks>Maps to %USERPROFILE%\Desktop</remarks>
            CSIDL_DESKTOPDIRECTORY = 0x0010,

            /// <summary>Documents</summary>
            /// <remarks>Maps to %USERPROFILE%\Documents</remarks>
            CSIDL_MYDOCUMENTS = CSIDL_PERSONAL,

            /// <summary>Documents</summary>
            /// <remarks>Maps to %USERPROFILE%\Documents</remarks>
            CSIDL_PERSONAL = 0x0005,

            /// <summary>Favorites</summary>
            /// <remarks>Maps to %USERPROFILE%\Favorites</remarks>
            CSIDL_FAVORITES = 0x0006,

            /// <summary>Favorites</summary>
            /// <remarks>Maps to %USERPROFILE%\Favorites</remarks>
            CSIDL_COMMON_FAVORITES = 0x001f,

            /// <summary>Fonts</summary>
            /// <remarks>Maps to %windir%\Fonts</remarks>
            CSIDL_FONTS = 0x0014,

            /// <summary>History</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\History</remarks>
            CSIDL_HISTORY = 0x0022,

            /// <summary>Temporary Internet Files</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files</remarks>
            CSIDL_INTERNET_CACHE = 0x0020,

            /// <summary>The Internet</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_INTERNET = 0x0001,

            /// <summary>Local</summary>
            /// <remarks>Maps to %LOCALAPPDATA% (%USERPROFILE%\AppData\Local)</remarks>
            CSIDL_LOCAL_APPDATA = 0x001c,

            /// <summary>None</summary>
            /// <remarks>Maps to %windir%\resources\0409 (code page)</remarks>
            CSIDL_RESOURCES_LOCALIZED = 0x0039,

            /// <summary>Music</summary>
            /// <remarks>Maps to %USERPROFILE%\Music</remarks>
            CSIDL_MYMUSIC = 0x000d,

            /// <summary>Network Shortcuts</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Network Shortcuts</remarks>
            CSIDL_NETHOOD = 0x0013,

            /// <summary>Network</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_NETWORK = 0x0012,

            /// <summary>Network</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_COMPUTERSNEARME = 0x003d,

            /// <summary>Pictures</summary>
            /// <remarks>Maps to %USERPROFILE%\Pictures</remarks>
            CSIDL_MYPICTURES = 0x0027,

            /// <summary>Printers</summary>
            /// <remarks>Maps to %USERPROFILE%\Music\Playlists</remarks>
            CSIDL_PRINTERS = 0x0004,

            /// <summary>Printer Shortcuts</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_PRINTHOOD = 0x001b,

            /// <summary>The user's username (%USERNAME%)</summary>
            /// <remarks>Maps to %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)</remarks>
            CSIDL_PROFILE = 0x0028,

            /// <summary>ProgramData</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)</remarks>
            CSIDL_COMMON_APPDATA = 0x0023,

            /// <summary>Program Files</summary>
            /// <remarks>Maps to %ProgramFiles% (%SystemDrive%\Program Files)</remarks>
            CSIDL_PROGRAM_FILES = 0x0026,

            /// <summary>Program Files</summary>
            /// <remarks>Maps to %ProgramFiles% (%SystemDrive%\Program Files)</remarks>
            CSIDL_PROGRAM_FILESX86 = 0x002a,

            /// <summary>Common Files</summary>
            /// <remarks>Maps to %ProgramFiles%\Common Files</remarks>
            CSIDL_PROGRAM_FILES_COMMON = 0x002b,

            /// <summary>Common Files</summary>
            /// <remarks>Maps to %ProgramFiles%\Common Files</remarks>
            CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,

            /// <summary>Programs</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs</remarks>
            CSIDL_PROGRAMS = 0x0002,

            /// <summary>Public Desktop</summary>
            /// <remarks>Maps to %PUBLIC%\Desktop</remarks>
            CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,

            /// <summary>Public Documents</summary>
            /// <remarks>Maps to %PUBLIC%\Documents</remarks>
            CSIDL_COMMON_DOCUMENTS = 0x002e,

            /// <summary>Public Music</summary>
            /// <remarks>Maps to %PUBLIC%\Music</remarks>
            CSIDL_COMMON_MUSIC = 0x0035,

            /// <summary>Public Pictures</summary>
            /// <remarks>Maps to %PUBLIC%\Pictures</remarks>
            CSIDL_COMMON_PICTURES = 0x0036,

            /// <summary>Public Videos</summary>
            /// <remarks>Maps to %%PUBLIC%\Videos</remarks>
            CSIDL_COMMON_VIDEO = 0x0037,

            /// <summary>Recent Items</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Recent</remarks>
            CSIDL_RECENT = 0x0008,

            /// <summary>Recycle Bin</summary>
            /// <remarks>virtual folder</remarks>
            CSIDL_BITBUCKET = 0x000a,

            /// <summary>Resources</summary>
            /// <remarks>Maps to %windir%\Resources</remarks>
            CSIDL_RESOURCES = 0x0038,

            /// <summary>Roaming</summary>
            /// <remarks>Maps to %APPDATA% (%USERPROFILE%\AppData\Roaming)</remarks>
            CSIDL_APPDATA = 0x001a,

            /// <summary>SendTo</summary>
            /// <remarks>Maps to %%APPDATA%\Microsoft\Windows\SendTo</remarks>
            CSIDL_SENDTO = 0x0009,

            /// <summary>Start Menu</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu</remarks>
            CSIDL_STARTMENU = 0x000b,

            /// <summary>Startup</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            CSIDL_STARTUP = 0x0007,

            /// <summary>Startup</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            CSIDL_ALTSTARTUP = 0x001d,

            /// <summary>System32</summary>
            /// <remarks>Maps to %windir%\system32</remarks>
            CSIDL_SYSTEM = 0x0025,

            /// <summary>System32</summary>
            /// <remarks>Maps to %windir%\system32</remarks>
            CSIDL_SYSTEMX86 = 0x0029,

            /// <summary>Templates</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Templates</remarks>
            CSIDL_TEMPLATES = 0x0015,

            /// <summary>Videos</summary>
            /// <remarks>Maps to %USERPROFILE%\Videos</remarks>
            CSIDL_MYVIDEO = 0x000e,

            /// <summary>Windows</summary>
            /// <remarks>Maps to %windir%</remarks>
            CSIDL_WINDOWS = 0x0024,

            /// <summary>
            /// Combine with another CSIDL to force the creation of the associated folder if it does not exist.
            /// </summary>
            CSIDL_FLAG_CREATE = 0x8000,

            /// <summary>
            /// Combine with another CSIDL constant to ensure the expansion of environment variables.
            /// </summary>
            CSIDL_FLAG_DONT_UNEXPAND = 0x2000,

            /// <summary>
            /// Combine with another CSIDL constant, except for <see cref="CSIDL_FLAG_CREATE"/>, to return an unverified folder path with no attempt to create or initialize the folder.
            /// </summary>
            CSIDL_FLAG_DONT_VERIFY = 0x4000,

            /// <summary>
            /// Combine with another CSIDL constant to ensure the retrieval of the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%,
            /// returned by <see cref="SHGetFolderLocation(IntPtr, CSIDL, IntPtr, int, out ITEMIDLIST*)"/>. This flag has no effect on paths returned by <see cref="SHGetFolderPath(IntPtr, CSIDL, IntPtr, SHGetFolderPathFlags, char*)"/>.
            /// </summary>
            CSIDL_FLAG_NO_ALIAS = 0x1000,

            /// <summary>
            /// Combine with another CSIDL to force the creation of the associated folder if it does not exist.
            /// </summary>
            CSIDL_FLAG_PER_USER_INIT = 0x0800,

            /// <summary>
            /// A mask for any valid CSIDL flag value.
            /// </summary>
            CSIDL_FLAG_MASK = 0xff00
        }
    }
}