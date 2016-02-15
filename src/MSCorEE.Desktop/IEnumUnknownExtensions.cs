// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Collections.Generic;

    public static class IEnumUnknownExtensions
    {
        public static IEnumerable<T> OfType<T>(this IEnumUnknown enumerator)
        {
            if (enumerator != null)
            {
                object[] elements = new object[1];
                int hr;
                while (true)
                {
                    uint count;
                    hr = enumerator.Next(1, elements, out count);
                    if (hr == 0 && (int)count == 1)
                    {
                        yield return (T)elements[0];
                    }
                    else
                    {
                        break;
                    }
                }

                new HResult(hr).ThrowOnFailure();
            }
        }
    }
}