P/Invoke
=======

[![Build status](https://ci.appveyor.com/api/projects/status/idu56hy4jwytxd3x?branch=master&svg=true)](https://ci.appveyor.com/project/AArnott/pinvoke)
[![Join the chat at https://gitter.im/AArnott/pinvoke](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AArnott/pinvoke?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

A library intended to contain all P/Invoke method signatures for popular operating systems.
Think of it as http://pinvoke.net, but proven to compile and work properly, and often
with sample usage in the form of unit tests.

## Usage

Install the NuGet package(s) for the DLLs you want to P/Invoke into.
For example, if you want to P/Invoke into Win32's BCrypt.dll, install this package:

```powershell
Install-Package PInvoke.BCrypt
```

Then import the following namespaces, as demonstrated below (if using C# 6):

```csharp
using PInvoke;
using static PInvoke.BCrypt; // Supported in C# 6 (VS2015) and later.
```

This will allow you to conveniently call these methods directly by method name:

```csharp
var error = BCryptOpenAlgorithm(AlgorithmIdentifiers.BCRYPT_SHA256_ALGORITHM); // C# 6 syntax
var error = BCrypt.BCryptOpenAlgorithm(BCrypt.AlgorithmIdentifiers.BCRYPT_SHA256_ALGORITHM); // C# 5 syntax
```

## Design goals

Provide a slightly higher than lowest level API for P/Invoke signatures.
For example, instead of `IntPtr` parameters and `uint` flags, you'll see `SafeHandle`-derived
types as parameters and flags `enum` types. API documentation will be provided via XML doc comments
for easy reading with Intellisense, along with links to the describing pages on MSDN
or elsewhere as applicable.

This is a portable library so you can use it anywhere.

## Distribution

This library should be available on NuGet for easy consumption by your projects.
You may also copy and paste the P/Invoke signatures you need directly into your projects if desired. 

Packages:

Library      | Package name     | NuGet       | Description
-------------|------------------|-------------|-------------
advapi32.dll |`PInvoke.AdvApi32`| [![NuGet](https://img.shields.io/nuget/dt/PInvoke.AdvApi32.svg)](https://www.nuget.org/packages/PInvoke.AdvApi32)|Windows Advanced Services
bcrypt.dll   |`PInvoke.BCrypt`  | [![NuGet](https://img.shields.io/nuget/dt/PInvoke.BCrypt.svg)](https://www.nuget.org/packages/PInvoke.BCrypt)|[Windows Cryptography API: Next Generation][CNG]
gdi32.dll    |`PInvoke.Gdi32`   | [![NuGet](https://img.shields.io/nuget/dt/PInvoke.Gdi32.svg)](https://www.nuget.org/packages/PInvoke.Gdi32)|[Windows Graphics Device Interface][Gdi]
hid.dll      |`PInvoke.Hid`     | [![NuGet](https://img.shields.io/nuget/dt/PInvoke.Hid.svg)](https://www.nuget.org/packages/PInvoke.Hid)|[Windows Human Interface Devices][Hid]
kernel32.dll |`PInvoke.Kernel32`| [![NuGet](https://img.shields.io/nuget/dt/PInvoke.Kernel32.svg)](https://www.nuget.org/packages/PInvoke.Kernel32)|Windows Kernel API
ncrypt.dll   |`PInvoke.NCrypt`  | [![NuGet](https://img.shields.io/nuget/dt/PInvoke.NCrypt.svg)](https://www.nuget.org/packages/PInvoke.NCrypt)|[Windows Cryptography API: Next Generation][CNG]
setupapi.dll |`PInvoke.SetupApi`| [![NuGet](https://img.shields.io/nuget/dt/PInvoke.SetupApi.svg)](https://www.nuget.org/packages/PInvoke.SetupApi)|[Windows setup API][SetupApi]
user32.dll   |`PInvoke.User32`  | [![NuGet](https://img.shields.io/nuget/dt/PInvoke.User32.svg)](https://www.nuget.org/packages/PInvoke.User32)|Windows User Interface

Check out the [P/Invoke coverage](coverage.md) we have for each library.

## Contribution

Please consider [contributing](CONTRIB.md) more P/Invoke method signatures to this project.
Once you contribute, you can immediately consume your additions without waiting for another
public release of the library.

[CNG]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376210
[Hid]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff538865
[SetupApi]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff550855
[Gdi]: https://msdn.microsoft.com/en-us/library/dd145203
