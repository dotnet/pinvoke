// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Indicates a spoofed device scale factor, as a percent.
    /// </summary>
    public enum DEVICE_SCALE_FACTOR
    {
        DEVICE_SCALE_FACTOR_INVALID = 0,

        /// <summary>
        /// 100%. The scale factor for the device is 1x.
        /// </summary>
        SCALE_100_PERCENT = 100,

        /// <summary>
        /// 120%. The scale factor for the device is 1.2x.
        /// </summary>
        SCALE_120_PERCENT = 120,
        SCALE_125_PERCENT = 125,
        SCALE_140_PERCENT = 140,
        SCALE_150_PERCENT = 150,
        SCALE_160_PERCENT = 160,
        SCALE_175_PERCENT = 175,
        SCALE_180_PERCENT = 180,
        SCALE_200_PERCENT = 200,
        SCALE_225_PERCENT = 225,
        SCALE_250_PERCENT = 250,
        SCALE_300_PERCENT = 300,
        SCALE_350_PERCENT = 350,
        SCALE_400_PERCENT = 400,
        SCALE_450_PERCENT = 450,
        SCALE_500_PERCENT = 500,
    }
}
