namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    public partial class Crypt32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CRYPT_KEY_PROV_INFO
        {
            [MarshalAs(UnmanagedType.LPWStr)] public string pwszContainerName;
            [MarshalAs(UnmanagedType.LPWStr)] public string pwszProvName;
            public CRYPT_PROV_TYPE dwProvType;
            public uint dwFlags;
            public uint cProvParam;
            public IntPtr rgProvParam;
            public uint dwKeySpec;
        }
    }
}
