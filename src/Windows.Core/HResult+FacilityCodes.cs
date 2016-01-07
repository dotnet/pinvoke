// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="FacilityCodes"/> nested type.
    /// </content>
    public partial struct HResult
    {
        /// <summary>
        /// HRESULT facility codes defined by winerror.h
        /// </summary>
        internal static class FacilityCodes
        {
            public const int FACILITY_XPS = 82;
            public const int FACILITY_XAML = 43;
            public const int FACILITY_USN = 129;
            public const int FACILITY_BLBUI = 128;
            public const int FACILITY_SPP = 256;
            public const int FACILITY_WSB_ONLINE = 133;
            public const int FACILITY_DLS = 153;
            public const int FACILITY_BLB_CLI = 121;
            public const int FACILITY_BLB = 120;
            public const int FACILITY_WSBAPP = 122;
            public const int FACILITY_WPN = 62;
            public const int FACILITY_WMAAECMA = 1996;
            public const int FACILITY_WINRM = 51;
            public const int FACILITY_WINPE = 61;
            public const int FACILITY_WINDOWSUPDATE = 36;
            public const int FACILITY_WINDOWS_STORE = 63;
            public const int FACILITY_WINDOWS_SETUP = 48;
            public const int FACILITY_WINDOWS_DEFENDER = 80;
            public const int FACILITY_WINDOWS_CE = 24;
            public const int FACILITY_WINDOWS = 8;
            public const int FACILITY_WINCODEC_DWRITE_DWM = 2200;
            public const int FACILITY_WIA = 33;
            public const int FACILITY_WER = 27;
            public const int FACILITY_WEP = 2049;
            public const int FACILITY_WEB_SOCKET = 886;
            public const int FACILITY_WEB = 885;
            public const int FACILITY_USERMODE_VOLSNAP = 130;
            public const int FACILITY_USERMODE_VOLMGR = 56;
            public const int FACILITY_VISUALCPP = 109;
            public const int FACILITY_USERMODE_VIRTUALIZATION = 55;
            public const int FACILITY_USERMODE_VHD = 58;
            public const int FACILITY_URT = 19;
            public const int FACILITY_UMI = 22;
            public const int FACILITY_UI = 42;
            public const int FACILITY_TPM_SOFTWARE = 41;
            public const int FACILITY_TPM_SERVICES = 40;
            public const int FACILITY_TIERING = 131;
            public const int FACILITY_SYNCENGINE = 2050;
            public const int FACILITY_SXS = 23;
            public const int FACILITY_STORAGE = 3;
            public const int FACILITY_STATE_MANAGEMENT = 34;
            public const int FACILITY_SSPI = 9;
            public const int FACILITY_USERMODE_SPACES = 231;
            public const int FACILITY_SOS = 160;
            public const int FACILITY_SCARD = 16;
            public const int FACILITY_SHELL = 39;
            public const int FACILITY_SETUPAPI = 15;
            public const int FACILITY_SECURITY = 9;
            public const int FACILITY_SDIAG = 60;
            public const int FACILITY_USERMODE_SDBUS = 2305;
            public const int FACILITY_RPC = 1;
            public const int FACILITY_RESTORE = 256;
            public const int FACILITY_SCRIPT = 112;
            public const int FACILITY_PARSE = 113;
            public const int FACILITY_RAS = 83;
            public const int FACILITY_POWERSHELL = 84;
            public const int FACILITY_PLA = 48;
            public const int FACILITY_PIDGENX = 2561;
            public const int FACILITY_P2P_INT = 98;
            public const int FACILITY_P2P = 99;
            public const int FACILITY_OPC = 81;
            public const int FACILITY_ONLINE_ID = 134;
            public const int FACILITY_WIN32 = 7;
            public const int FACILITY_CONTROL = 10;
            public const int FACILITY_WEBSERVICES = 61;
            public const int FACILITY_NULL = 0;
            public const int FACILITY_NDIS = 52;
            public const int FACILITY_NAP = 39;
            public const int FACILITY_MOBILE = 1793;
            public const int FACILITY_METADIRECTORY = 35;
            public const int FACILITY_MSMQ = 14;
            public const int FACILITY_MEDIASERVER = 13;
            public const int FACILITY_MBN = 84;
            public const int FACILITY_LINGUISTIC_SERVICES = 305;
            public const int FACILITY_LEAP = 2184;
            public const int FACILITY_JSCRIPT = 2306;
            public const int FACILITY_INTERNET = 12;
            public const int FACILITY_ITF = 4;
            public const int FACILITY_INPUT = 64;
            public const int FACILITY_USERMODE_HYPERVISOR = 53;
            public const int FACILITY_ACCELERATOR = 1536;
            public const int FACILITY_HTTP = 25;
            public const int FACILITY_GRAPHICS = 38;
            public const int FACILITY_FWP = 50;
            public const int FACILITY_FVE = 49;
            public const int FACILITY_USERMODE_FILTER_MANAGER = 31;
            public const int FACILITY_EAS = 85;
            public const int FACILITY_EAP = 66;
            public const int FACILITY_DXGI_DDI = 2171;
            public const int FACILITY_DXGI = 2170;
            public const int FACILITY_DPLAY = 21;
            public const int FACILITY_DMSERVER = 256;
            public const int FACILITY_DISPATCH = 2;
            public const int FACILITY_DIRECTORYSERVICE = 37;
            public const int FACILITY_DIRECTMUSIC = 2168;
            public const int FACILITY_DIRECT3D11 = 2172;
            public const int FACILITY_DIRECT3D10 = 2169;
            public const int FACILITY_DIRECT2D = 2201;
            public const int FACILITY_DAF = 100;
            public const int FACILITY_DEPLOYMENT_SERVICES_UTIL = 260;
            public const int FACILITY_DEPLOYMENT_SERVICES_TRANSPORT_MANAGEMENT = 272;
            public const int FACILITY_DEPLOYMENT_SERVICES_TFTP = 264;
            public const int FACILITY_DEPLOYMENT_SERVICES_PXE = 263;
            public const int FACILITY_DEPLOYMENT_SERVICES_MULTICAST_SERVER = 289;
            public const int FACILITY_DEPLOYMENT_SERVICES_MULTICAST_CLIENT = 290;
            public const int FACILITY_DEPLOYMENT_SERVICES_MANAGEMENT = 259;
            public const int FACILITY_DEPLOYMENT_SERVICES_IMAGING = 258;
            public const int FACILITY_DEPLOYMENT_SERVICES_DRIVER_PROVISIONING = 278;
            public const int FACILITY_DEPLOYMENT_SERVICES_SERVER = 257;
            public const int FACILITY_DEPLOYMENT_SERVICES_CONTENT_PROVIDER = 293;
            public const int FACILITY_DEPLOYMENT_SERVICES_BINLSVC = 261;
            public const int FACILITY_DEFRAG = 2304;
            public const int FACILITY_DEBUGGERS = 176;
            public const int FACILITY_CONFIGURATION = 33;
            public const int FACILITY_COMPLUS = 17;
            public const int FACILITY_USERMODE_COMMONLOG = 26;
            public const int FACILITY_CMI = 54;
            public const int FACILITY_CERT = 11;
            public const int FACILITY_BLUETOOTH_ATT = 101;
            public const int FACILITY_BCD = 57;
            public const int FACILITY_BACKGROUNDCOPY = 32;
            public const int FACILITY_AUDIOSTREAMING = 1094;
            public const int FACILITY_AUDCLNT = 2185;
            public const int FACILITY_AUDIO = 102;
            public const int FACILITY_ACTION_QUEUE = 44;
            public const int FACILITY_ACS = 20;
            public const int FACILITY_AAF = 18;
        }
    }
}
