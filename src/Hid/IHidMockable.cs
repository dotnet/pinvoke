// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32;
	public interface IHidMockable {        /// <summary>
        /// The HidD_GetHidGuid routine returns the device interfaceGUID for HIDClass devices.
        /// </summary>
        /// <param name="hidGuid">
        /// Pointer to a caller-allocated GUID buffer that the routine uses to return the device interface GUID
        /// for HIDClass devices.
        /// </param>
        void InvokeHidD_GetHidGuid(out Guid hidGuid);
	}
}