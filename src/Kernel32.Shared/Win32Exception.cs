// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32;

    public class Win32Exception
#if DESKTOP
        : System.ComponentModel.Win32Exception
#else
        : Exception
#endif
    {
#if !DESKTOP
        /// <summary>
        /// The maximum memory we are willing to allocate for the exception message.
        /// </summary>
        private const int MaxAllowedBufferSize = 65 * 1024;

        /// <summary>
        /// The original Win32 error code that resulted in this exception.
        /// </summary>
        private readonly int nativeErrorCode;
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
            : this((int)error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        public Win32Exception(int error)
#if DESKTOP
            : base(error)
#else
            : this(error, GetErrorMessage(error))
#endif
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32Exception"/> class.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        /// <param name="message">The message for this exception.</param>
        public Win32Exception(int error, string message)
#if DESKTOP
            : base(error, message)
#else
            : base(message)
#endif
        {
#if !DESKTOP
            this.nativeErrorCode = error;
#endif
        }

        /// <summary>
        /// Gets the Win32 error code associated with this exception.
        /// </summary>
        /// <devremarks>
        /// We must define this so that our own assembly on desktop is not a subset
        /// of what portable offers (lest runtime errors in our users occur).
        /// </devremarks>
#if DESKTOP
        public new int NativeErrorCode => base.NativeErrorCode;
#else
        public int NativeErrorCode => this.nativeErrorCode;
#endif

#if !DESKTOP
        private static string GetErrorMessage(int error)
        {
            string errorMsg;

            StringBuilder sb = new StringBuilder(256);
            do
            {
                if (TryGetErrorMessage(error, sb, out errorMsg))
                {
                    return errorMsg;
                }
                else
                {
                    // increase the capacity of the StringBuilder by 4 times.
                    sb.Capacity *= 4;
                }
            }
            while (sb.Capacity < MaxAllowedBufferSize);

            // If you come here then a size as large as 65K is also not sufficient and so we give the generic errorMsg.
            return "Unknown error (0x" + Convert.ToString(error, 16) + ")";
        }

        /// <summary>
        /// Tries to get the error message text using the supplied buffer.
        /// </summary>
        /// <param name="error">The error number to get text for.</param>
        /// <param name="sb">The buffer to use for acquiring the message.</param>
        /// <param name="errorMsg">Receives the resulting error message.</param>
        /// <returns><c>true</c> if the attempt is successful; <c>false</c> otherwise.</returns>
        private static bool TryGetErrorMessage(int error, StringBuilder sb, out string errorMsg)
        {
            errorMsg = string.Empty;
            int result = FormatMessage(
                FormatMessageFlags.IgnoreInserts | FormatMessageFlags.FromSystem | FormatMessageFlags.ArgumentArray,
                IntPtr.Zero,
                (uint)error,
                0,
                sb,
                sb.Capacity + 1,
                null);
            if (result > 0)
            {
                int i = sb.Length;
                while (i > 0)
                {
                    char ch = sb[i - 1];
                    if (ch > 32 && ch != '.')
                    {
                        break;
                    }

                    i--;
                }

                errorMsg = sb.ToString(0, i);
            }
            else if (Marshal.GetLastWin32Error() == (int)Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
            {
                return false;
            }
            else
            {
                errorMsg = "Unknown error (0x" + Convert.ToString(error, 16) + ")";
            }

            return true;
        }
#endif
    }
}
