// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SYSTEMTIME"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies a date and time, using individual members for the month, day, year, weekday, hour, minute, second, and millisecond.
        /// The time is either in coordinated universal time (UTC) or local time, depending on the function that is being called.
        /// </summary>
        /// <remarks>
        /// It is not recommended that you add and subtract values from the <see cref="SYSTEMTIME"/> structure to obtain relative times.
        /// Instead, you should
        /// Convert the <see cref="SYSTEMTIME"/> structure to a <see cref="FILETIME"/> structure.
        /// <list type="bullet">
        /// <item>
        /// <desccription>Copy the resulting <see cref="FILETIME"/> structure to a ULARGE_INTEGER structure.</desccription>
        /// </item>
        /// <item>
        /// <desccription>Use normal 64-bit arithmetic on the ULARGE_INTEGER value.</desccription>
        /// </item>
        /// <item>
        /// <description>The system can periodically refresh the time by synchronizing with a time source.</description>
        /// </item>
        /// </list>
        /// Because the system time can be adjusted either forward or backward, do not compare system time readings to determine elapsed time.
        /// Instead, use one of the methods described in Windows Time.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            /// <summary>
            /// The year. The valid values for this member are 1601 through 30827.
            /// </summary>
            public short wYear;

            /// <summary>
            /// The month. This member can be one of the following values.
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <term>Meaning</term>
            /// </listheader>
            /// <item>
            /// <term>1</term>
            /// <term>January</term>
            /// </item>
            /// <item>
            /// <term>2</term>
            /// <term>February</term>
            /// </item>
            /// <item>
            /// <term>3</term>
            /// <term>March</term>
            /// </item>
            /// <item>
            /// <term>4</term>
            /// <term>April</term>
            /// </item>
            /// <item>
            /// <term>5</term>
            /// <term>May</term>
            /// </item>
            /// <item>
            /// <term>6</term>
            /// <term>June</term>
            /// </item>
            /// <item>
            /// <term>7</term>
            /// <term>July</term>
            /// </item>
            /// <item>
            /// <term>8</term>
            /// <term>August</term>
            /// </item>
            /// <item>
            /// <term>9</term>
            /// <term>September</term>
            /// </item>
            /// <item>
            /// <term>10</term>
            /// <term>October</term>
            /// </item>
            /// <item>
            /// <term>11</term>
            /// <term>November</term>
            /// </item>
            /// <item>
            /// <term>12</term>
            /// <term>December</term>
            /// </item>
            /// </list>
            /// </summary>
            public short wMonth;

            /// <summary>
            /// The day of the week. This member can be one of the following values.
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <term>Meaning</term>
            /// </listheader>
            /// <item>
            /// <term>0</term>
            /// <term>Sunday</term>
            /// </item>
            /// <item>
            /// <term>1</term>
            /// <term>Monday</term>
            /// </item>
            /// <item>
            /// <term>2</term>
            /// <term>Tuesday</term>
            /// </item>
            /// <item>
            /// <term>3</term>
            /// <term>Wednesday</term>
            /// </item>
            /// <item>
            /// <term>4</term>
            /// <term>Thursday</term>
            /// </item>
            /// <item>
            /// <term>5</term>
            /// <term>Friday</term>
            /// </item>
            /// <item>
            /// <term>6</term>
            /// <term>Saturday</term>
            /// </item>
            /// </list>
            /// </summary>
            public short wDayOfWeek;

            /// <summary>
            /// The day of the month. The valid values for this member are 1 through 31.
            /// </summary>
            public short wDay;

            /// <summary>
            /// The hour. The valid values for this member are 0 through 23.
            /// </summary>
            public short wHour;

            /// <summary>
            /// The minute. The valid values for this member are 0 through 59.
            /// </summary>
            public short wMinute;

            /// <summary>
            /// The second. The valid values for this member are 0 through 59.
            /// </summary>
            public short wSecond;

            /// <summary>
            /// The millisecond. The valid values for this member are 0 through 999.
            /// </summary>
            public short wMilliseconds;
        }
    }
}
