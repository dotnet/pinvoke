// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.Serialization;
    using static PInvoke.Kernel32;

    /// <summary>
    /// An exception thrown for a failure described by a <see cref="NTSTATUS"/>.
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
        public NTStatusException(NTSTATUS statusCode)
            : this(statusCode, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="message">The exception message (which may be null to use the default).</param>
        public NTStatusException(NTSTATUS statusCode, string message)
            : this(statusCode, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatusException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="message">The exception message (which may be null to use the default).</param>
        /// <param name="inner">The inner exception.</param>
        public NTStatusException(NTSTATUS statusCode, string message, Exception inner)
            : base(message ?? GetMessage(statusCode), inner)
        {
            this.NativeErrorCode = statusCode;
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
            this.NativeErrorCode = info.GetUInt32(nameof(this.NativeErrorCode));
        }
#endif

        /// <summary>
        /// Gets the <see cref="NTSTATUS"/> code that identifies the error condition.
        /// </summary>
        public NTSTATUS NativeErrorCode { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="NTStatusException"/> class with localized message.
        /// </summary>
        /// <param name="statusCode">The status code identifying the error.</param>
        /// <param name="localize">Indicates wether the message should be localized</param>
        /// <returns>The localized NTStatusException</returns>
        public static NTStatusException Create(NTSTATUS statusCode, bool localize)
        {
            NTStatusException result;

            if (localize)
            {
#if DESKTOP
                result = new NTStatusException(statusCode, $"{statusCode.GetMessage()} (NT_STATUS error: {statusCode.Value:G} (0x{statusCode.AsInt32:X8}))");
#else
                result = new NTStatusException(statusCode);
#endif
            }
            else
            {
                result = new NTStatusException(statusCode);
            }

            return result;
        }

#if DESKTOP
        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.NativeErrorCode), this.NativeErrorCode.AsUInt32);
            base.GetObjectData(info, context);
        }
#endif

        /// <summary>
        /// Gets the message associated with the given <see cref="NTSTATUS"/>.
        /// </summary>
        /// <param name="status">The <see cref="NTSTATUS"/> for the error.</param>
        /// <returns>The description of the error.</returns>
        private static string GetMessage(NTSTATUS status)
        {
            string hexCode = $"0x{(int)status:X8}";
            string namedCode = Enum.GetName(typeof(NTSTATUS.Code), status.AsUInt32);
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

        private static string GetSeverityString(NTSTATUS status)
        {
            switch (status.Severity)
            {
                case NTSTATUS.SeverityCode.STATUS_SEVERITY_SUCCESS:
                    return "success";
                case NTSTATUS.SeverityCode.STATUS_SEVERITY_INFORMATIONAL:
                    return "information";
                case NTSTATUS.SeverityCode.STATUS_SEVERITY_WARNING:
                    return "warning";
                case NTSTATUS.SeverityCode.STATUS_SEVERITY_ERROR:
                    return "error";
                default:
                    return string.Empty;
            }
        }
    }
}
