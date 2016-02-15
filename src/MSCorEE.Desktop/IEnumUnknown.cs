// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enumerates objects with the IUnknown interface. It can be used to enumerate through the objects in a component containing multiple objects.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000100-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IEnumUnknown
    {
        /// <summary>
        /// Retrieves the specified number of items in the enumeration sequence.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult Next([In] uint elementArrayLength, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown), Out] object[] elementArray, out uint fetchedElementCount);

        /// <summary>
        /// Skips over the specified number of items in the enumeration sequence.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult Skip([In] uint count);

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult Reset();

        /// <summary>
        /// Creates a new enumerator that contains the same enumeration state as the current one.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// <remarks>
        /// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later time. The caller must release this new enumerator separately from the first enumerator.
        /// </remarks>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult Clone([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown enumerator);
    }
}