// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.Serialization;
    using static PInvoke.Kernel32;

    /// <summary>
    /// An exception thrown for a failure described by a <see cref="NTStatus"/>.
    /// </summary>
#if DESKTOP
    [Serializable]
#endif
    public class NTStatusException : Exception
    {
        /// <summary>
        /// The maximum memory we are willing to allocate for the exception message.
        /// </summary>
        private const int MaxAllowedBufferSize = 65 * 1024;

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        public NTStatusException(NTStatus statusCode)
            : this(statusCode, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="message">The exception message (which may be null to use the default).</param>
        public NTStatusException(NTStatus statusCode, string message)
            : base(message ?? GetMessage(statusCode))
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="message">The exception message (which may be null to use the default).</param>
        /// <param name="inner">The inner exception.</param>
        public NTStatusException(NTStatus statusCode, string message, Exception inner)
            : base(message ?? GetMessage(statusCode), inner)
        {
            this.StatusCode = statusCode;
        }

#if DESKTOP
        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class
        /// for deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected NTStatusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.StatusCode = info.GetUInt32(nameof(this.StatusCode));
        }
#endif

        /// <summary>
        /// Gets the <see cref="NTStatus"/> code that identifies the error condition.
        /// </summary>
        public NTStatus StatusCode { get; }

#if DESKTOP
        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.StatusCode), this.StatusCode.AsUInt32);
            base.GetObjectData(info, context);
        }
#endif

        /// <summary>
        /// Gets the message associated with the given <see cref="NTStatus"/>.
        /// </summary>
        /// <param name="status">The <see cref="NTStatus"/> for the error.</param>
        /// <returns>The description of the error.</returns>
        private static unsafe string GetMessage(NTStatus status)
        {
#if DESKTOP
            using (var ntdll = LoadLibrary("ntdll.dll"))
            {
                string formattedMessage = FormatMessage(
                    FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE,
                    ntdll.DangerousGetHandle(),
                    (int)status,
                    0,
                    null,
                    MaxAllowedBufferSize);
                if (formattedMessage != null)
                {
                    return formattedMessage;
                }
            }
#endif

            return $"Unknown NT_STATUS error (0x{status:x8})";
        }
    }
}
