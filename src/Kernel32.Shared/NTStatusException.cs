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
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        public NTStatusException(NTStatus statusCode)
            : this(statusCode, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="message">The exception message (which may be null to use the default).</param>
        public NTStatusException(NTStatus statusCode, string message)
            : this(statusCode, message, null)
        {
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
        private static string GetMessage(NTStatus status)
        {
            string hexCode = $"0x{(int)status:X8}";
            string namedCode = Enum.GetName(typeof(NTStatus.Code), status.AsUInt32);
            string statusAsString = namedCode != null
                ? $"{namedCode} ({hexCode})"
                : hexCode;
            string insert = $"NT_STATUS {GetSeverityString(status)}: {statusAsString}";
            string message = null;
#if DESKTOP
            message = status.GetMessage();
#endif

            return message != null
                ? $"{message} ({insert})"
                : insert;
        }

        private static string GetSeverityString(NTStatus status)
        {
            switch (status.Severity)
            {
                case NTStatus.SeverityCode.STATUS_SEVERITY_SUCCESS:
                    return "success";
                case NTStatus.SeverityCode.STATUS_SEVERITY_INFORMATIONAL:
                    return "information";
                case NTStatus.SeverityCode.STATUS_SEVERITY_WARNING:
                    return "warning";
                case NTStatus.SeverityCode.STATUS_SEVERITY_ERROR:
                    return "error";
                default:
                    return string.Empty;
            }
        }
    }
}
