// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using static Kernel32;

    /// <summary>
    /// An exception thrown for a failure described by a <see cref="Win32ErrorCode"/>.
    /// </summary>
#if DESKTOP
    [Serializable]
#endif
    public class Win32Exception
#if DESKTOP
        : System.ComponentModel.Win32Exception
#else
        : Exception
#endif
    {
#if !DESKTOP
        /// <summary>
        /// The original Win32 error code that resulted in this exception.
        /// </summary>
        private readonly Win32ErrorCode nativeErrorCode;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        public Win32Exception()
#if DESKTOP
            : base()
#else
            : this(Marshal.GetLastWin32Error())
#endif
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        public Win32Exception(Win32ErrorCode error)
#if DESKTOP
            : base((int)error)
#else
            : this(error, error.GetMessage() ?? $"Unknown error (0x{(int)error:x8})")
#endif
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        public Win32Exception(int error)
            : this((Win32ErrorCode)error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        /// <param name="message">The message for this exception.</param>
        public Win32Exception(Win32ErrorCode error, string message)
#if DESKTOP
            : base((int)error, message)
#else
            : base(message)
#endif
        {
#if !DESKTOP
            this.nativeErrorCode = error;
#endif
        }

#if DESKTOP
        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class
        /// for deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected Win32Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        /// <summary>
        /// Gets the Win32 error code associated with this exception.
        /// </summary>
        /// <devremarks>
        /// We must define this so that our own assembly on desktop is not a subset
        /// of what portable offers (lest runtime errors in our users occur).
        /// </devremarks>
#if DESKTOP
        public new Win32ErrorCode NativeErrorCode => (Win32ErrorCode)base.NativeErrorCode;
#else
        public Win32ErrorCode NativeErrorCode => this.nativeErrorCode;
#endif
    }
}
