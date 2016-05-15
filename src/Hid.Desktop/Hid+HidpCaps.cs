// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="HidpCaps"/> nested type.
    /// </content>
    public static partial class Hid
    {
        /// <summary>
        /// The HIDP_CAPS structure contains information about a top-level collection's capability.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct HidpCaps
        {
            /// <summary>
            /// Specifies a top-level collection's usage ID.
            /// </summary>
            public ushort Usage;

            /// <summary>
            /// Specifies the top-level collection's usage page.
            /// </summary>
            public ushort UsagePage;

            /// <summary>
            /// Specifies the maximum size, in bytes, of all the input reports (including the report ID, if report IDs are used, which
            /// is prepended to the report data).
            /// </summary>
            public ushort InputReportByteLength;

            /// <summary>
            /// Specifies the maximum size, in bytes, of all the output reports (including the report ID, if report IDs are used, which
            /// is prepended to the report data).
            /// </summary>
            public ushort OutputReportByteLength;

            /// <summary>
            /// Specifies the maximum length, in bytes, of all the feature reports (including the report ID, if report IDs are used,
            /// which is prepended to the report data).
            /// </summary>
            public ushort FeatureReportByteLength;

            /// <summary>
            /// Reserved for internal system use.
            /// </summary>
            public fixed ushort Reserved[17];

            /// <summary>
            /// Specifies the number of HIDP_LINK_COLLECTION_NODE structures that are returned for this top-level collection by
            /// HidP_GetLinkCollectionNodes.
            /// </summary>
            public ushort NumberLinkCollectionNodes;

            /// <summary>
            /// Specifies the number of input HIDP_BUTTON_CAPS structures that HidP_GetButtonCaps returns.
            /// </summary>
            public ushort NumberInputButtonCaps;

            /// <summary>
            /// Specifies the number of input HIDP_VALUE_CAPS structures that HidP_GetValueCaps returns.
            /// </summary>
            public ushort NumberInputValueCaps;

            /// <summary>
            /// Specifies the number of data indices assigned to buttons and values in all input reports.
            /// </summary>
            public ushort NumberInputDataIndices;

            /// <summary>
            /// Specifies the number of output HIDP_BUTTON_CAPS structures that HidP_GetButtonCaps returns.
            /// </summary>
            public ushort NumberOutputButtonCaps;

            /// <summary>
            /// Specifies the number of output HIDP_VALUE_CAPS structures that HidP_GetValueCaps returns.
            /// </summary>
            public ushort NumberOutputValueCaps;

            /// <summary>
            /// Specifies the number of data indices assigned to buttons and values in all output reports.
            /// </summary>
            public ushort NumberOutputDataIndices;

            /// <summary>
            /// Specifies the total number of feature HIDP_BUTTONS_CAPS structures that HidP_GetButtonCaps returns.
            /// </summary>
            public ushort NumberFeatureButtonCaps;

            /// <summary>
            /// Specifies the total number of feature HIDP_VALUE_CAPS structures that HidP_GetValueCaps returns.
            /// </summary>
            public ushort NumberFeatureValueCaps;

            /// <summary>
            /// Specifies the number of data indices assigned to buttons and values in all feature reports.
            /// </summary>
            public ushort NumberFeatureDataIndices;
        }
    }
}