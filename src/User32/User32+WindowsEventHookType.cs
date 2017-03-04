// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="WindowsEventHookType" /> nested type.</content>
    public partial class User32
    {
        /// <summary>
        ///     The type of hook procedure to be installed by <see cref="SetWinEventHook(WindowsEventHookType, WindowsEventHookType, IntPtr, IntPtr, int, int, WindowsEventHookFlags)" />.
        /// </summary>
        public enum WindowsEventHookType
        {
            /// <summary>
            ///     The range of WinEvent constant values specified by the Accessibility Interoperability Alliance (AIA) for use across the industry.
            /// </summary>
            EVENT_AIA_START = 0xA000,
            EVENT_AIA_END = 0xAFFF,

            /// <summary>
            ///     The lowest possible event values.
            /// </summary>
            EVENT_MIN = 0x00000001,

            /// <summary>
            ///     The highest possible event values.
            /// </summary>
            EVENT_MAX = 0x7FFFFFFF,

            /// <summary>
            ///     An object's KeyboardShortcut property has changed. Server applications send this event
            ///     for their accessible objects.
            /// </summary>
            EVENT_OBJECT_ACCELERATORCHANGE = 0x8012,

            /// <summary>
            ///     A window object's scrolling has ended. Unlike <see cref="EVENT_SYSTEM_SCROLLINGEND"/>, this event is
            ///     associated with the scrolling window. Whether the scrolling is horizontal or vertical scrolling,
            ///     this event should be sent whenever the scroll action is completed.
            ///     The hwnd parameter of the WinEventProc callback function describes the scrolling window;
            ///     the idObject parameter is OBJID_CLIENT, and the idChild parameter is CHILDID_SELF.
            /// </summary>
            EVENT_OBJECT_CONTENTSCROLLED = 0x8015,

            /// <summary>
            ///     An object has been created. The system sends this event for the following user interface elements: caret,
            ///     header control, list-view control, tab control, toolbar control, tree view control, and window object.
            ///     Server applications send this event for their accessible objects.
            ///     Before sending the event for the parent object, servers must send it for all of an object's child objects.
            ///     Servers must ensure that all child objects are fully created and ready to accept IAccessible calls from
            ///     clients before the parent object sends this event.
            ///     Because a parent object is created after its child objects, clients must make sure that an object's parent
            ///     has been created before calling IAccessible::get_accParent, particularly if in-context hook functions are
            ///     used.
            /// </summary>
            EVENT_OBJECT_CREATE = 0x8000,
            EVENT_OBJECT_DEFACTIONCHANGE = 0x8011,
            EVENT_OBJECT_DESCRIPTIONCHANGE = 0x800D,
            EVENT_OBJECT_DESTROY = 0x8001,
            EVENT_OBJECT_DRAGSTART = 0x8021,
            EVENT_OBJECT_DRAGCANCEL = 0x8022,
            EVENT_OBJECT_DRAGCOMPLETE = 0x8023,
            EVENT_OBJECT_DRAGENTER = 0x8024,
            EVENT_OBJECT_DRAGLEAVE = 0x8025,
            EVENT_OBJECT_DRAGDROPPED = 0x8026,
            EVENT_OBJECT_END = 0x80FF,
            EVENT_OBJECT_FOCUS = 0x8005,
            EVENT_OBJECT_HELPCHANGE = 0x8010,
            EVENT_OBJECT_HIDE = 0x8003,
            EVENT_OBJECT_HOSTEDOBJECTSINVALIDATED = 0x8020,
            EVENT_OBJECT_IME_HIDE = 0x8028,
            EVENT_OBJECT_IME_SHOW = 0x8027,
            EVENT_OBJECT_IME_CHANGE = 0x8029,
            EVENT_OBJECT_INVOKED = 0x8013,
            EVENT_OBJECT_LIVEREGIONCHANGED = 0x8019,
            EVENT_OBJECT_LOCATIONCHANGE = 0x800B,
            EVENT_OBJECT_NAMECHANGE = 0x800C,
            EVENT_OBJECT_PARENTCHANGE = 0x800F,
            EVENT_OBJECT_REORDER = 0x8004,
            EVENT_OBJECT_SELECTION = 0x8006,
            EVENT_OBJECT_SELECTIONADD = 0x8007,
            EVENT_OBJECT_SELECTIONREMOVE = 0x8008,
            EVENT_OBJECT_SELECTIONWITHIN = 0x8009,
            EVENT_OBJECT_SHOW = 0x8002,
            EVENT_OBJECT_STATECHANGE = 0x800A,
            EVENT_OBJECT_TEXTEDIT_CONVERSIONTARGETCHANGED = 0x8030,
            EVENT_OBJECT_TEXTSELECTIONCHANGED = 0x8014,
            EVENT_OBJECT_VALUECHANGE = 0x800E,
            EVENT_SYSTEM_ALERT = 0x0002,
            EVENT_SYSTEM_ARRANGMENTPREVIEW = 0x8016,
            EVENT_SYSTEM_CAPTUREEND = 0x0009,
            EVENT_SYSTEM_CAPTURESTART = 0x0008,
            EVENT_SYSTEM_CONTEXTHELPEND = 0x000D,
            EVENT_SYSTEM_CONTEXTHELPSTART = 0x000C,
            EVENT_SYSTEM_DESKTOPSWITCH = 0x0020,
            EVENT_SYSTEM_DIALOGEND = 0x0011,
            EVENT_SYSTEM_DIALOGSTART = 0x0010,
            EVENT_SYSTEM_DRAGDROPEND = 0x000F,
            EVENT_SYSTEM_DRAGDROPSTART = 0x000E,
            EVENT_SYSTEM_END = 0x00FF,
            EVENT_SYSTEM_FOREGROUND = 0x0003,
            EVENT_SYSTEM_MENUPOPUPEND = 0x0007,
            EVENT_SYSTEM_MENUPOPUPSTART = 0x0006,
            EVENT_SYSTEM_MENUEND = 0x0005,
            EVENT_SYSTEM_MENUSTART = 0x0004,
            EVENT_SYSTEM_MINIMIZEEND = 0x0017,
            EVENT_SYSTEM_MINIMIZESTART = 0x0016,
            EVENT_SYSTEM_MOVESIZEEND = 0x000B,
            EVENT_SYSTEM_MOVESIZESTART = 0x000A,
            EVENT_SYSTEM_SCROLLINGEND = 0x0013,
            EVENT_SYSTEM_SCROLLINGSTART = 0x0012,
            EVENT_SYSTEM_SOUND = 0x0001,
            EVENT_SYSTEM_SWITCHEND = 0x0015,
            EVENT_SYSTEM_SWITCHSTART = 0x0014,
            EVENT_OEM_DEFINED_START = 0x0101,
            EVENT_OEM_DEFINED_END = 0x01FF,
            EVENT_UIA_EVENTID_START = 0x4E00,
            EVENT_UIA_EVENTID_END = 0x4EFF,
            EVENT_UIA_PROPID_START = 0x7500,
            EVENT_UIA_PROPID_END = 0x75FF
        }
    }
}