// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	public interface IAdvApi32Mockable {
        /// <summary>
        /// Changes the optional configuration parameters of a service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the OpenService or CreateService function and
        /// must have the <see cref="ServiceAccess.SERVICE_CHANGE_CONFIG"/> access right.
        /// </param>
        /// <param name="dwInfoLevel">
        /// The configuration information to be changed.
        /// This parameter can be one value from <see cref="ServiceStartType"/>.
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to the new value to be set for the configuration information.
        /// The format of this data depends on the value of the dwInfoLevel parameter.
        /// If this value is NULL, the information remains unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero
        /// </returns>
        bool InvokeChangeServiceConfig2(SafeServiceHandle hService, ServiceInfoLevel dwInfoLevel, IntPtr lpInfo);
	}
}
