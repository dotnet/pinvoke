// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="KNOWNFOLDERID"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>
        /// The KNOWNFOLDERID constants represent GUIDs that identify standard folders registered with the system as Known Folders.
        /// These folders are installed with Windows Vista and later operating systems, and a computer will have only folders appropriate to it installed.
        /// For more information see the <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd378457.aspx">MSDN</a> value table.
        /// </summary>
        /// <remarks>Used by <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/></remarks>
        public static class KNOWNFOLDERID
        {
            /// <summary>Account Pictures</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\AccountPictures</remarks>
            public static readonly Guid FOLDERID_AccountPictures = new Guid("008ca0b1-55b4-4c56-b8a8-4de4b299d3be");

            /// <summary>Get Programs</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_AddNewPrograms = new Guid("de61d971-5ebc-4f02-a3a9-6c82895e5c04");

            /// <summary>Administrative Tools</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</remarks>
            public static readonly Guid FOLDERID_AdminTools = new Guid("724EF170-A42D-4FEF-9F26-B60E846FBA4F");

            /// <summary>Application Shortcuts</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Application Shortcuts</remarks>
            public static readonly Guid FOLDERID_ApplicationShortcuts = new Guid("A3918781-E5F2-4890-B3D9-A7E54332328C");

            /// <summary>Applications</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_AppsFolder = new Guid("1e87508d-89c2-42f0-8a7e-645a0f50ca58");

            /// <summary>Installed Updates</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_AppUpdates = new Guid("a305ce99-f527-492b-8b1a-7e76fa98d6e4");

            /// <summary>Camera Roll</summary>
            /// <remarks>Maps to %USERPROFILE%\Pictures\Camera Roll</remarks>
            public static readonly Guid FOLDERID_CameraRoll = new Guid("AB5FB87B-7CE2-4F83-915D-550846C9537B");

            /// <summary>Camera Roll Library</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_CameraRollLibrary = new Guid("2b20df75-1eda-4039-8097-38798227d5b7");

            /// <summary>Temporary Burn Folder</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Burn\Burn</remarks>
            public static readonly Guid FOLDERID_CDBurning = new Guid("9E52AB10-F80D-49DF-ACB8-4330F5687855");

            /// <summary>Programs and Features</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_ChangeRemovePrograms = new Guid("df7266ac-9274-4867-8d55-3bd661de872d");

            /// <summary>Administrative Tools</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</remarks>
            public static readonly Guid FOLDERID_CommonAdminTools = new Guid("D0384E7D-BAC3-4797-8F14-CBA229B392B5");

            /// <summary>OEM Links</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\OEM Links</remarks>
            public static readonly Guid FOLDERID_CommonOEMLinks = new Guid("C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D");

            /// <summary>Programs</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs</remarks>
            public static readonly Guid FOLDERID_CommonPrograms = new Guid("0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8");

            /// <summary>Start Menu</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu</remarks>
            public static readonly Guid FOLDERID_CommonStartMenu = new Guid("A4115719-D62E-491D-AA7C-E74B8BE3B067");

            /// <summary>Startup</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            public static readonly Guid FOLDERID_CommonStartup = new Guid("82A5EA35-D9CD-47C5-9629-E15D2F714E6E");

            /// <summary>Templates</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Templates</remarks>
            public static readonly Guid FOLDERID_CommonTemplates = new Guid("B94237E7-57AC-4347-9151-B08C6C32D1F7");

            /// <summary>Computer</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_ComputerFolder = new Guid("0AC0837C-BBF8-452A-850D-79D08E667CA7");

            /// <summary>Conflicts</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_ConflictFolder = new Guid("4bfefb45-347d-4006-a5be-ac0cb0567192");

            /// <summary>Network Connections</summary>
            /// <remarks>Maps to virtual folder</remarks>
            public static readonly Guid FOLDERID_ConnectionsFolder = new Guid("6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD");

            /// <summary>Contacts</summary>
            /// <remarks>Maps to %USERPROFILE%\Contacts</remarks>
            public static readonly Guid FOLDERID_Contacts = new Guid("56784854-C6CB-462b-8169-88E350ACB882");

            /// <summary>Account Pictures</summary>
            /// <remarks>Maps to virtual folder</remarks>
            public static readonly Guid FOLDERID_ControlPanelFolder = new Guid("82A74AEB-AEB4-465C-A014-D097EE346D63");

            /// <summary>Cookies</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Cookies</remarks>
            public static readonly Guid FOLDERID_Cookies = new Guid("2B0F765D-C0E9-4171-908E-08A611B84FF6");

            /// <summary>Desktop</summary>
            /// <remarks>Maps to %USERPROFILE%\Desktop</remarks>
            public static readonly Guid FOLDERID_Desktop = new Guid("B4BFCC3A-DB2C-424C-B029-7FE99A87C641");

            /// <summary>DeviceMetadataStore</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\DeviceMetadataStore</remarks>
            public static readonly Guid FOLDERID_DeviceMetadataStore = new Guid("5CE4A5E9-E4EB-479D-B89F-130C02886155");

            /// <summary>Documents</summary>
            /// <remarks>Maps to %USERPROFILE%\Documents</remarks>
            public static readonly Guid FOLDERID_Documents = new Guid("FDD39AD0-238F-46AF-ADB4-6C85480369C7");

            /// <summary>Documents</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Libraries\Documents.library-ms</remarks>
            public static readonly Guid FOLDERID_DocumentsLibrary = new Guid("FDD39AD0-238F-46AF-ADB4-6C85480369C7");

            /// <summary>Account Pictures</summary>
            /// <remarks>Maps to %USERPROFILE%\Downloads</remarks>
            public static readonly Guid FOLDERID_Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

            /// <summary>Favorites</summary>
            /// <remarks>Maps to %USERPROFILE%\Favorites</remarks>
            public static readonly Guid FOLDERID_Favorites = new Guid("1777F761-68AD-4D8A-87BD-30B759FA33DD");

            /// <summary>Fonts</summary>
            /// <remarks>Maps to %windir%\Fonts</remarks>
            public static readonly Guid FOLDERID_Fonts = new Guid("FD228CB7-AE11-4AE3-864C-16F3910AB8FE");

            /// <summary>Games</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_Games = new Guid("CAC52C1A-B53D-4edc-92D7-6B2E8AC19434");

            /// <summary>GameExplorer</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\GameExplorer</remarks>
            public static readonly Guid FOLDERID_GameTasks = new Guid("054FAE61-4DD8-4787-80B6-090220C4B700");

            /// <summary>History</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\History</remarks>
            public static readonly Guid FOLDERID_History = new Guid("D9DC8A3B-B784-432E-A781-5A1130A75963");

            /// <summary>Homegroup</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_HomeGroup = new Guid("52528A6B-B9E3-4ADD-B60D-588C2DBA842D");

            /// <summary>The user's username (%USERNAME%)</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_HomeGroupCurrentUser = new Guid("9B74B6A3-0DFD-4f11-9E78-5F7800F2E772");

            /// <summary>ImplicitAppShortcuts</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned\ImplicitAppShortcuts</remarks>
            public static readonly Guid FOLDERID_ImplicitAppShortcuts = new Guid("BCB5256F-79F6-4CEE-B725-DC34E402FD46");

            /// <summary>Temporary Internet Files</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files</remarks>
            public static readonly Guid FOLDERID_InternetCache = new Guid("352481E8-33BE-4251-BA85-6007CAEDCF9D");

            /// <summary>The Internet</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_InternetFolder = new Guid("4D9F7874-4E0C-4904-967B-40B0D20C3E4B");

            /// <summary>Libraries</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Libraries</remarks>
            public static readonly Guid FOLDERID_Libraries = new Guid("1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE");

            /// <summary>Links</summary>
            /// <remarks>Maps to %USERPROFILE%\Links</remarks>
            public static readonly Guid FOLDERID_Links = new Guid("bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968");

            /// <summary>Local</summary>
            /// <remarks>Maps to %LOCALAPPDATA% (%USERPROFILE%\AppData\Local)</remarks>
            public static readonly Guid FOLDERID_LocalAppData = new Guid("F1B32785-6FBA-4FCF-9D55-7B8E7F157091");

            /// <summary>LocalLow</summary>
            /// <remarks>Maps to %USERPROFILE%\AppData\LocalLow</remarks>
            public static readonly Guid FOLDERID_LocalAppDataLow = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");

            /// <summary>None</summary>
            /// <remarks>Maps to %windir%\resources\0409 (code page)</remarks>
            public static readonly Guid FOLDERID_LocalizedResourcesDir = new Guid("2A00375E-224C-49DE-B8D1-440DF7EF3DDC");

            /// <summary>Music</summary>
            /// <remarks>Maps to %USERPROFILE%\Music</remarks>
            public static readonly Guid FOLDERID_Music = new Guid("4BD8D571-6D19-48D3-BE97-422220080E43");

            /// <summary>Music</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Libraries\Music.library-ms</remarks>
            public static readonly Guid FOLDERID_MusicLibrary = new Guid("4BD8D571-6D19-48D3-BE97-422220080E43");

            /// <summary>Network Shortcuts</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Network Shortcuts</remarks>
            public static readonly Guid FOLDERID_NetHood = new Guid("C5ABBF53-E17F-4121-8900-86626FC2C973");

            /// <summary>Network</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_NetworkFolder = new Guid("D20BEEC4-5CA8-4905-AE3B-BF251EA09B53");

            /// <summary>Original Images</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows Photo Gallery\Original Images</remarks>
            public static readonly Guid FOLDERID_OriginalImages = new Guid("2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39");

            /// <summary>Slide Shows</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\AccountPictures</remarks>
            public static readonly Guid FOLDERID_PhotoAlbums = new Guid("69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C");

            /// <summary>Pictures</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Libraries\Pictures.library-ms</remarks>
            public static readonly Guid FOLDERID_PicturesLibrary = new Guid("A990AE9F-A03B-4E80-94BC-9912D7504104");

            /// <summary>Pictures</summary>
            /// <remarks>Maps to %USERPROFILE%\Pictures</remarks>
            public static readonly Guid FOLDERID_Pictures = new Guid("33E28130-4E1E-4676-835A-98395C3BC3BB");

            /// <summary>Playlists</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\AccountPictures</remarks>
            public static readonly Guid FOLDERID_Playlists = new Guid("DE92C1C7-837F-4F69-A3BB-86E631204A23");

            /// <summary>Printers</summary>
            /// <remarks>Maps to %USERPROFILE%\Music\Playlists</remarks>
            public static readonly Guid FOLDERID_PrintersFolder = new Guid("76FC4E2D-D6AD-4519-A663-37BD56068185");

            /// <summary>Printer Shortcuts</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_PrintHood = new Guid("9274BD8D-CFD1-41C3-B35E-B13F55A758F4");

            /// <summary>The user's username (%USERNAME%)</summary>
            /// <remarks>Maps to %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)</remarks>
            public static readonly Guid FOLDERID_Profile = new Guid("5E6C858F-0E22-4760-9AFE-EA3317B67173");

            /// <summary>ProgramData</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)</remarks>
            public static readonly Guid FOLDERID_ProgramData = new Guid("62AB5D82-FDC1-4DC3-A9DD-070D1D495D97");

            /// <summary>Program Files</summary>
            /// <remarks>Maps to %ProgramFiles% (%SystemDrive%\Program Files)</remarks>
            public static readonly Guid FOLDERID_ProgramFiles = new Guid("905e63b6-c1bf-494e-b29c-65b732d3d21a");

            /// <summary>Program Files</summary>
            /// <remarks>Maps to %ProgramFiles% (%SystemDrive%\Program Files)</remarks>
            public static readonly Guid FOLDERID_ProgramFilesX64 = new Guid("6D809377-6AF0-444b-8957-A3773F02200E");

            /// <summary>Program Files</summary>
            /// <remarks>Maps to %ProgramFiles% (%SystemDrive%\Program Files)</remarks>
            public static readonly Guid FOLDERID_ProgramFilesX86 = new Guid("7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E");

            /// <summary>Common Files</summary>
            /// <remarks>Maps to %ProgramFiles%\Common Files</remarks>
            public static readonly Guid FOLDERID_ProgramFilesCommon = new Guid("F7F1ED05-9F6D-47A2-AAAE-29D317C6F066");

            /// <summary>Common Files</summary>
            /// <remarks>Maps to %ProgramFiles%\Common Files</remarks>
            public static readonly Guid FOLDERID_ProgramFilesCommonX64 = new Guid("6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D");

            /// <summary>Common Files</summary>
            /// <remarks>Maps to %ProgramFiles%\Common Files</remarks>
            public static readonly Guid FOLDERID_ProgramFilesCommonX86 = new Guid("DE974D24-D9C6-4D3E-BF91-F4455120B917");

            /// <summary>Programs</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs</remarks>
            public static readonly Guid FOLDERID_Programs = new Guid("A77F5D77-2E2B-44C3-A6A2-ABA601054A51");

            /// <summary>Public</summary>
            /// <remarks>Maps to %PUBLIC% (%SystemDrive%\Users\Public)</remarks>
            public static readonly Guid FOLDERID_Public = new Guid("DFDF76A2-C82A-4D63-906A-5644AC457385");

            /// <summary>Public Desktop</summary>
            /// <remarks>Maps to %PUBLIC%\Desktop</remarks>
            public static readonly Guid FOLDERID_PublicDesktop = new Guid("C4AA340D-F20F-4863-AFEF-F87EF2E6BA25");

            /// <summary>Public Documents</summary>
            /// <remarks>Maps to %PUBLIC%\Documents</remarks>
            public static readonly Guid FOLDERID_PublicDocuments = new Guid("ED4824AF-DCE4-45A8-81E2-FC7965083634");

            /// <summary>Public Downloads</summary>
            /// <remarks>Maps to %PUBLIC%\Downloads</remarks>
            public static readonly Guid FOLDERID_PublicDownloads = new Guid("3D644C9B-1FB8-4f30-9B45-F670235F79C0");

            /// <summary>GameExplorer</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\GameExplorer</remarks>
            public static readonly Guid FOLDERID_PublicGameTasks = new Guid("DEBF2536-E1A8-4c59-B6A2-414586476AEA");

            /// <summary>Libraries</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Libraries</remarks>
            public static readonly Guid FOLDERID_PublicLibraries = new Guid("48DAF80B-E6CF-4F4E-B800-0E69D84EE384");

            /// <summary>Public Music</summary>
            /// <remarks>Maps to %PUBLIC%\Music</remarks>
            public static readonly Guid FOLDERID_PublicMusic = new Guid("3214FAB5-9757-4298-BB61-92A9DEAA44FF");

            /// <summary>Public Pictures</summary>
            /// <remarks>Maps to %PUBLIC%\Pictures</remarks>
            public static readonly Guid FOLDERID_PublicPictures = new Guid("B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5");

            /// <summary>Ringtones</summary>
            /// <remarks>Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Ringtones</remarks>
            public static readonly Guid FOLDERID_PublicRingtones = new Guid("2400183A-6185-49FB-A2D8-4A392A602BA3");

            /// <summary>Public Account Pictures</summary>
            /// <remarks>Maps to %PUBLIC%\AccountPictures</remarks>
            public static readonly Guid FOLDERID_PublicUserTiles = new Guid("0482af6c-08f1-4c34-8c90-e17ec98b1e17");

            /// <summary>Public Videos</summary>
            /// <remarks>Maps to %%PUBLIC%\Videos</remarks>
            public static readonly Guid FOLDERID_PublicVideos = new Guid("2400183A-6185-49FB-A2D8-4A392A602BA3");

            /// <summary>Quick Launch</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Internet Explorer\Quick Launch</remarks>
            public static readonly Guid FOLDERID_QuickLaunch = new Guid("52a4f021-7b75-48a9-9f6b-4b87a210bc8f");

            /// <summary>Recent Items</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Recent</remarks>
            public static readonly Guid FOLDERID_Recent = new Guid("AE50C081-EBD2-438A-8655-8A092E34987A");

            /// <summary>Not used</summary>
            /// <remarks>This value is undefined as of Windows 7</remarks>
            public static readonly Guid FOLDERID_RecordedTV = new Guid("bd85e001-112e-431e-983b-7b15ac09fff1");

            /// <summary>Recorded TV</summary>
            /// <remarks>Maps to %PUBLIC%\RecordedTV.library-ms</remarks>
            public static readonly Guid FOLDERID_RecordedTVLibrary = new Guid("1A6FDBA2-F42D-4358-A798-B74D745926C5");

            /// <summary>Recycle Bin</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_RecycleBinFolder = new Guid("B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC");

            /// <summary>Resources</summary>
            /// <remarks>Maps to %windir%\Resources</remarks>
            public static readonly Guid FOLDERID_ResourceDir = new Guid("8AD10C31-2ADB-4296-A8F7-E4701232C972");

            /// <summary>Retail Demo</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_RetailDemo = new Guid("12d4c69e-24ad-4923-be19-31321c43a767");

            /// <summary>Development Files</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_DevelopmentFiles = new Guid("dbe8e08e-3053-4bbc-b183-2a7b2b191e59");

            /// <summary>3D Objects</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_Objects3D = new Guid("31c0dd25-9439-4f12-bf41-7ff4eda38722");

            /// <summary>Ringtones</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\Ringtones</remarks>
            public static readonly Guid FOLDERID_Ringtones = new Guid("C870044B-F49E-4126-A9C3-B52A1FF411E8");

            /// <summary>Roaming</summary>
            /// <remarks>Maps to %APPDATA% (%USERPROFILE%\AppData\Roaming)</remarks>
            public static readonly Guid FOLDERID_RoamingAppData = new Guid("3EB685DB-65F9-4CF6-A03A-E3EF65729F3D");

            /// <summary>RoamedTileImages</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\RoamedTileImages</remarks>
            public static readonly Guid FOLDERID_RoamedTileImages = new Guid("AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E");

            /// <summary>RoamingTiles</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\RoamingTiles</remarks>
            public static readonly Guid FOLDERID_RoamingTiles = new Guid("00BCFC5A-ED94-4e48-96A1-3F6217F21990");

            /// <summary>Sample Music</summary>
            /// <remarks>Maps to %PUBLIC%\Music\Sample Music</remarks>
            public static readonly Guid FOLDERID_SampleMusic = new Guid("B250C668-F57D-4EE1-A63C-290EE7D1AA1F");

            /// <summary>Sample Pictures</summary>
            /// <remarks>Maps to %PUBLIC%\Pictures\Sample Pictures</remarks>
            public static readonly Guid FOLDERID_SamplePictures = new Guid("C4900540-2379-4C75-844B-64E6FAF8716B");

            /// <summary>Sample Playlists</summary>
            /// <remarks>Maps to %PUBLIC%\Music\Sample Playlists</remarks>
            public static readonly Guid FOLDERID_SamplePlaylists = new Guid("15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5");

            /// <summary>Sample Videos</summary>
            /// <remarks>Maps to %PUBLIC%\Videos\Sample Videos</remarks>
            public static readonly Guid FOLDERID_SampleVideos = new Guid("859EAD94-2E85-48AD-A71A-0969CB56A6CD");

            /// <summary>Saved Games</summary>
            /// <remarks>Maps to %USERPROFILE%\Saved Games</remarks>
            public static readonly Guid FOLDERID_SavedGames = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");

            /// <summary>Saved Pictures</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_SavedPictures = new Guid("3b193882-d3ad-4eab-965a-69829d1fb59f");

            /// <summary>Saved Pictures Library</summary>
            /// <remarks>Maps to %APPDATE%\Microsoft\Windows\Libraries\SavedPictures.library-ms</remarks>
            public static readonly Guid FOLDERID_SavedPicturesLibrary = new Guid("E25B5812-BE88-4bd9-94B0-29233477B6C3");

            /// <summary>Saved Pictures</summary>
            /// <remarks>Maps to %USERPROFILE%\Pictures\Saved Pictures</remarks>
            public static readonly Guid FOLDERID_SavedSearches = new Guid("7d1d3a04-debb-4115-95cf-2f29da2920da");

            /// <summary>Screenshots</summary>
            /// <remarks>Maps to %USERPROFILE%\Pictures\Screenshots</remarks>
            public static readonly Guid FOLDERID_Screenshots = new Guid("b7bede81-df94-4682-a7d8-57a52620b86f");

            /// <summary>Offline Files</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SEARCH_CSC = new Guid("ee32e446-31ca-4aba-814f-a5ebd2fd6d5e");

            /// <summary>History</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\History</remarks>
            public static readonly Guid FOLDERID_SearchHistory = new Guid("0D4C3DB6-03A3-462F-A0E6-08924C41B5D4");

            /// <summary>Search Results</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SearchHome = new Guid("190337d1-b8ca-4121-a639-6d472d16972a");

            /// <summary>Microsoft Office Outlook</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SEARCH_MAPI = new Guid("98ec0e18-2098-4d44-8644-66979315a281");

            /// <summary>Templates</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\Templates</remarks>
            public static readonly Guid FOLDERID_SearchTemplates = new Guid("7E636BFE-DFA9-4D5E-B456-D7B39851D8A9");

            /// <summary>SendTo</summary>
            /// <remarks>Maps to %%APPDATA%\Microsoft\Windows\SendTo</remarks>
            public static readonly Guid FOLDERID_SendTo = new Guid("8983036C-27C0-404B-8F08-102D10DCFD74");

            /// <summary>Gadgets</summary>
            /// <remarks>Maps to %ProgramFiles%\Windows Sidebar\Gadgets</remarks>
            public static readonly Guid FOLDERID_SidebarDefaultParts = new Guid("7B396E54-9EC5-4300-BE0A-2482EBAE1A26");

            /// <summary>Gadgets</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Microsoft\Windows Sidebar\Gadgets</remarks>
            public static readonly Guid FOLDERID_SidebarParts = new Guid("A75D362E-50FC-4fb7-AC2C-A8BEAA314493");

            /// <summary>OneDrive</summary>
            /// <remarks>Maps to %USERPROFILE%\OneDrive</remarks>
            public static readonly Guid FOLDERID_SkyDrive = new Guid("A52BBA46-E9E1-435f-B3D9-28DAA648C0F6");

            /// <summary>OneDrive</summary>
            /// <remarks>Defined in Windows 10</remarks>
            public static readonly Guid FOLDERID_OneDrive = new Guid("A52BBA46-E9E1-435f-B3D9-28DAA648C0F6");

            /// <summary>Camera Roll</summary>
            /// <remarks>Maps to %USERPROFILE%\OneDrive\Pictures\Camera Roll</remarks>
            public static readonly Guid FOLDERID_SkyDriveCameraRoll = new Guid("767E6811-49CB-4273-87C2-20F355E1085B");

            /// <summary>Documents</summary>
            /// <remarks>Maps to %USERPROFILE%\OneDrive\Documents</remarks>
            public static readonly Guid FOLDERID_SkyDriveDocuments = new Guid("24D89E24-2F19-4534-9DDE-6A6671FBB8FE");

            /// <summary>Pictures</summary>
            /// <remarks>Maps to %USERPROFILE%\OneDrive\Pictures</remarks>
            public static readonly Guid FOLDERID_SkyDrivePictures = new Guid("339719B5-8C47-4894-94C2-D8F77ADD44A6");

            /// <summary>Start Menu</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu</remarks>
            public static readonly Guid FOLDERID_StartMenu = new Guid("625B53C3-AB48-4EC1-BA1F-A1EF4146FC19");

            /// <summary>Startup</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp</remarks>
            public static readonly Guid FOLDERID_Startup = new Guid("B97D20BB-F46A-4C97-BA10-5E3608430854");

            /// <summary>Sync Center</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SyncManagerFolder = new Guid("43668BF8-C14E-49B2-97C9-747784D784B7");

            /// <summary>Sync Results</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SyncResultsFolder = new Guid("289a9a43-be44-4057-a41b-587a76d7e7f9");

            /// <summary>Sync Setup</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_SyncSetupFolder = new Guid("0F214138-B1D3-4a90-BBA9-27CBC0C5389A");

            /// <summary>System32</summary>
            /// <remarks>Maps to %windir%\system32</remarks>
            public static readonly Guid FOLDERID_System = new Guid("1AC14E77-02E7-4E5D-B744-2EB1AE5198B7");

            /// <summary>System32</summary>
            /// <remarks>Maps to %windir%\system32</remarks>
            public static readonly Guid FOLDERID_SystemX86 = new Guid("D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27");

            /// <summary>Templates</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Templates</remarks>
            public static readonly Guid FOLDERID_Templates = new Guid("A63293E8-664E-48DB-A079-DF759E0509F7");

            /// <summary>Not used</summary>
            /// <remarks>Not used in Windows Vista. Unsupported as of Windows 7.</remarks>
            public static readonly Guid FOLDERID_TreeProperties = new Guid("5b3749ad-b49f-49c1-83eb-15370fbd4882");

            /// <summary>User Pinned</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned</remarks>
            public static readonly Guid FOLDERID_UserPinned = new Guid("9E3995AB-1F9C-4F13-B827-48B24B6C7174");

            /// <summary>Users</summary>
            /// <remarks>Maps to %SystemDrive%\Users</remarks>
            public static readonly Guid FOLDERID_UserProfiles = new Guid("0762D272-C50A-4BB0-A382-697DCD729B80");

            /// <summary>Programs</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Programs</remarks>
            public static readonly Guid FOLDERID_UserProgramFiles = new Guid("5CD7AEE2-2219-4A67-B85D-6C9CE15660CB");

            /// <summary>Programs</summary>
            /// <remarks>Maps to %LOCALAPPDATA%\Programs\Common</remarks>
            public static readonly Guid FOLDERID_UserProgramFilesCommon = new Guid("BCBD3057-CA5C-4622-B42D-BC56DB0AE516");

            /// <summary>The user's full name entered when the user account was created.</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_UsersFiles = new Guid("f3ce0f7c-4901-4acc-8648-d5d44b04ef8f");

            /// <summary>Libraries</summary>
            /// <remarks>virtual folder</remarks>
            public static readonly Guid FOLDERID_UsersLibraries = new Guid("A302545D-DEFF-464b-ABE8-61C8648D939B");

            /// <summary>Videos</summary>
            /// <remarks>Maps to %USERPROFILE%\Videos</remarks>
            public static readonly Guid FOLDERID_Videos = new Guid("18989B1D-99B5-455B-841C-AB7C74E4DDFC");

            /// <summary>Videos</summary>
            /// <remarks>Maps to %APPDATA%\Microsoft\Windows\Libraries\Videos.library-ms</remarks>
            public static readonly Guid FOLDERID_VideosLibrary = new Guid("491E922F-5643-4AF4-A7EB-4E7A138D8174");

            /// <summary>Windows</summary>
            /// <remarks>Maps to %windir%</remarks>
            public static readonly Guid FOLDERID_Windows = new Guid("F38BF404-1D43-42F2-9305-67DE0B28FC23");
        }
    }
}