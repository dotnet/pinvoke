// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Identifies the type of UI component that is needed in the shell
    /// </summary>
    public enum SHELL_UI_COMPONENT
    {
        /// <summary>
        /// This UI component is a taskbar icon
        /// </summary>
        SHELL_UI_COMPONENT_TASKBARS = 0,

        /// <summary>
        /// This UI component is an icon in the notification area
        /// </summary>
        SHELL_UI_COMPONENT_NOTIFICATIONAREA = 1,

        /// <summary>
        /// This UI component is a deskband icon
        /// </summary>
        SHELL_UI_COMPONENT_DESKBAND = 2,
    }
}
