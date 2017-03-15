// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>Identifies the dots per inch (dpi) setting for a monitor</summary>
    /// <remarks>All of these settings are affected by the value of <see cref="PROCESS_DPI_AWARENESS"/> on your application</remarks>
    public enum MONITOR_DPI_TYPE
    {
        /// <summary>
        /// The effective DPI. This value should be used when determining the correct scale factor for scaling UI elements.
        /// This incorporates the scale factor set by the user for this specific display
        /// </summary>
        MDT_EFFECTIVE_DPI = 0,

        /// <summary>
        /// The angular DPI. This DPI ensures rendering at a compliant angular resolution on the screen.
        /// This does not include the scale factor set by the user for this specific display
        /// </summary>
        MDT_ANGULAR_DPI = 1,

        /// <summary>
        /// The raw DPI. This value is the linear DPI of the screen as measured on the screen itself.
        /// Use this value when you want to read the pixel density and not the recommended scaling setting.
        /// This does not include the scale factor set by the user for this specific display and is not guaranteed to be a supported DPI value
        /// </summary>
        MDT_RAW_DPI = 2,

        /// <summary>
        /// The default is the same as <see cref="MDT_EFFECTIVE_DPI"/>
        /// </summary>
        MDT_DEFAULT = MDT_EFFECTIVE_DPI
    }
}
