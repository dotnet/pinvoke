// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProgressBarWindowStyles"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Specifies a combination of button styles. If you create a button using the BUTTON class with the CreateWindow or CreateWindowEx function, you can specify any of the button styles listed below.
        /// </summary>
        [Flags]
        public enum ProgressBarWindowStyles : uint
        {
            /// <summary>
            /// Version 4.70 or later. The progress bar displays progress status vertically, from bottom to top.
            /// </summary>
            PBS_VERTICAL = 0x04,

            /// <summary>
            /// Version 6.0 or later. The progress indicator does not grow in size but instead moves repeatedly along the length of the bar, indicating activity without specifying what proportion of the progress is complete.
            /// </summary>
            PBS_MARQUEE = 0x08,

            /// <summary>
            /// Version 4.70 or later. The progress bar displays progress status in a smooth scrolling bar instead of the default segmented bar.
            /// </summary>
            PBS_SMOOTH = 0x01,

            /// <summary>
            /// Version 6.0 or later and Windows Vista. Determines the animation behavior that the progress bar should use when moving backward (from a higher value to a lower value). If this is set, then a "smooth" transition will occur, otherwise the control will "jump" to the lower value.
            /// </summary>
            PBS_SMOOTHREVERSE = 0x10,
        }
    }
}
