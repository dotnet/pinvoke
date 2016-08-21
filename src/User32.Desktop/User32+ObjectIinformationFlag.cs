// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ObjectInformationType"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The information to be retrieved by <see cref="GetUserObjectInformation(System.IntPtr, ObjectInformationType, void*, uint, uint*)"/>
        /// </summary>
        public enum ObjectInformationType : int
        {
            /// <summary>
            /// The handle flags. The pvInfo parameter must point to a <see cref="USEROBJECTFLAGS"/> structure.
            /// </summary>
            UOI_FLAGS = 1,

            /// <summary>
            /// The name of the object, as a string.
            /// </summary>
            UOI_NAME = 2,

            /// <summary>
            /// The type name of the object, as a string
            /// </summary>
            UOI_TYPE = 3,

            /// <summary>
            /// The SID structure that identifies the user that is currently associated with the specified object.
            /// If no user is associated with the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero.
            /// Note that SID is a variable length structure. You will usually make a call to GetUserObjectInformation to determine
            /// the length of the SID before retrieving its value.
            /// </summary>
            UOI_USER_SID = 4,

            /// <summary>
            /// The size of the desktop heap, in KB, as a ULONG value. The hObj parameter must be a handle to a desktop object,
            /// otherwise, the function fails.
            /// </summary>
            /// <remarks>Windows Server 2003 and Windows XP/2000:  This value is not supported.</remarks>
            UOI_HEAPSIZE = 5,

            /// <summary>
            /// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise.
            /// </summary>
            /// <remarks>Windows Server 2003 and Windows XP/2000:  This value is not supported.</remarks>
            UOI_IO = 6
        }
    }
}