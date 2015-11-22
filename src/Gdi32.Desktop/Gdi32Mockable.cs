// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	public partial class Gdi32 : IGdi32Mockable {        public bool InvokeDeleteObject(IntPtr hObject)
			=> DeleteObject(hObject);
	}
}
