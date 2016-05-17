// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using static NCrypt;

    /// <summary>
    /// An exception that describes a failure with a <see cref="SECURITY_STATUS"/> code.
    /// </summary>
#if DESKTOP
    [Serializable]
#endif
    public class SecurityStatusException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStatusException"/> class.
        /// </summary>
        /// <param name="status">The error code leading to this exception.</param>
        public SecurityStatusException(SECURITY_STATUS status)
            : this(status, GetMessage(status), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStatusException"/> class.
        /// </summary>
        /// <param name="status">The error code leading to this exception.</param>
        /// <param name="message">The customized message for the exception.</param>
        public SecurityStatusException(SECURITY_STATUS status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStatusException"/> class.
        /// </summary>
        /// <param name="status">The error code leading to this exception.</param>
        /// <param name="message">The customized message for the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public SecurityStatusException(SECURITY_STATUS status, string message, Exception inner)
            : base(message ?? GetMessage(status), inner)
        {
            this.NativeErrorCode = status;
        }

#if DESKTOP
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStatusException"/> class
        /// for deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected SecurityStatusException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
#endif

        /// <summary>
        /// Gets the <see cref="SECURITY_STATUS"/> code that identifies the error condition.
        /// </summary>
        public SECURITY_STATUS NativeErrorCode { get; }

        /// <summary>
        /// Gets the message associated with the given <see cref="SECURITY_STATUS"/>.
        /// </summary>
        /// <param name="status">The <see cref="SECURITY_STATUS"/> for the error.</param>
        /// <returns>The description of the error.</returns>
        private static string GetMessage(SECURITY_STATUS status)
        {
            string hexCode = $"0x{(int)status:X8}";
            string namedCode = Enum.GetName(typeof(SECURITY_STATUS), status);
            string statusAsString = namedCode != null
                ? $"{namedCode} ({hexCode})"
                : hexCode;
            string insert = $"SECURITY_STATUS {GetSeverityString(status)}: {statusAsString}";
            string message = status.GetMessage();

            return message != null
                ? $"{message} ({insert})"
                : insert;
        }

        private static string GetSeverityString(SECURITY_STATUS status)
        {
            return status == SECURITY_STATUS.ERROR_SUCCESS
                ? "success"
                : "error";
        }
    }
}
