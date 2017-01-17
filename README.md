P/Invoke
=======

[![Build status](https://ci.appveyor.com/api/projects/status/idu56hy4jwytxd3x?branch=master&svg=true)](https://ci.appveyor.com/project/AArnott/pinvoke)
[![Join the chat at https://gitter.im/AArnott/pinvoke](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AArnott/pinvoke?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![Issue Stats][pull-requests-img]][pull-requests-url] [![Issue Stats][issues-closed-img]][issues-closed-url]

A collection of libraries intended to contain all P/Invoke method signatures for popular operating systems.
Think of it as http://pinvoke.net, but proven to compile and work properly, and often
with sample usage in the form of unit tests.

Each library is exposed as its own NuGet package, and may include .NET Portable libraries as applicable,
exposing those APIs that are available only on Desktop, or Store, or both as appropriate.

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

Sometimes a PInvoke method may have multiple overloads. For example every method that accepts
`struct*` parameters has an overload that accepts `IntPtr` in its place. In other cases there
may be overloads that accept `struct*` and `struct?`. In some of these cases that can lead to
compiler errors if you pass in `null` because both `struct*` and `struct?` overloads can match.
To resolve the issue, add a cast to your null: `(struct?)null` to resolve the ambiguity.

## Design goals

Provide a slightly higher than lowest level API for P/Invoke signatures.
For example, instead of `IntPtr` parameters and `uint` flags, you'll see `SafeHandle`-derived
types as parameters and flags `enum` types. API documentation will be provided via XML doc comments
for easy reading with Intellisense, along with links to the describing pages on MSDN
or elsewhere as applicable.

## Distribution

This library should be available on NuGet for easy consumption by your projects.
You may also copy and paste the P/Invoke signatures you need directly into your projects if desired. 

Packages:

Library      | Package name     | NuGet       | Description
-------------|------------------|-------------|-------------
advapi32.dll |`PInvoke.AdvApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.AdvApi32)](https://www.nuget.org/packages/PInvoke.AdvApi32)|Windows Advanced Services
bcrypt.dll   |`PInvoke.BCrypt`  | [![NuGet](https://buildstats.info/nuget/PInvoke.BCrypt)](https://www.nuget.org/packages/PInvoke.BCrypt)|[Windows Cryptography API: Next Generation][CNG]
crypt32.dll  |`PInvoke.Crypt32` | [![NuGet](https://buildstats.info/nuget/PInvoke.Crypt32)](https://www.nuget.org/packages/PInvoke.Crypt32)|[Windows Cryptography API][Crypt32]
DwmApi.dll   |`PInvoke.DwmApi`  | [![NuGet](https://buildstats.info/nuget/PInvoke.DwmApi)](https://www.nuget.org/packages/PInvoke.DwmApi)|[Desktop Window Manager][DwmApi]
gdi32.dll    |`PInvoke.Gdi32`   | [![NuGet](https://buildstats.info/nuget/PInvoke.Gdi32)](https://www.nuget.org/packages/PInvoke.Gdi32)|[Windows Graphics Device Interface][Gdi]
hid.dll      |`PInvoke.Hid`     | [![NuGet](https://buildstats.info/nuget/PInvoke.Hid)](https://www.nuget.org/packages/PInvoke.Hid)|[Windows Human Interface Devices][Hid]
kernel32.dll |`PInvoke.Kernel32`| [![NuGet](https://buildstats.info/nuget/PInvoke.Kernel32)](https://www.nuget.org/packages/PInvoke.Kernel32)|Windows Kernel API
mscoree.dll  |`PInvoke.MSCorEE` | [![NuGet](https://buildstats.info/nuget/PInvoke.MSCorEE)](https://www.nuget.org/packages/PInvoke.MSCorEE)|.NET Framework CLR host
msi.dll      |`PInvoke.Msi`     | [![NuGet](https://buildstats.info/nuget/PInvoke.Msi)](https://www.nuget.org/packages/PInvoke.Msi)|[Microsoft Installer][Msi]
fusion.dll   |`PInvoke.Fusion`  | [![NuGet](https://buildstats.info/nuget/PInvoke.Fusion)](https://www.nuget.org/packages/PInvoke.Fusion)|.NET Framework Fusion
ncrypt.dll   |`PInvoke.NCrypt`  | [![NuGet](https://buildstats.info/nuget/PInvoke.NCrypt)](https://www.nuget.org/packages/PInvoke.NCrypt)|[Windows Cryptography API: Next Generation][CNG]
netapi32.dll |`PInvoke.NetApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.NetApi32)](https://www.nuget.org/packages/PInvoke.NetApi32)|[Network Management][NetApi32]
ntdll.dll    |`PInvoke.NTDll`   | [![NuGet](https://buildstats.info/nuget/PInvoke.NTDll)](https://www.nuget.org/packages/PInvoke.NTDll)|Windows NTDll
psapi.dll    |`PInvoke.Psapi`   | [![NuGet](https://buildstats.info/nuget/PInvoke.Psapi)](https://www.nuget.org/packages/PInvoke.Psapi)|[Windows Process Status API][Psapi]
setupapi.dll |`PInvoke.SetupApi`| [![NuGet](https://buildstats.info/nuget/PInvoke.SetupApi)](https://www.nuget.org/packages/PInvoke.SetupApi)|[Windows setup API][SetupApi]
shell32.dll  |`PInvoke.Shell32` | [![NuGet](https://buildstats.info/nuget/PInvoke.Shell32)](https://www.nuget.org/packages/PInvoke.Shell32)|[Windows Shell][Shell32]
SHCore.dll   |`PInvoke.SHCore`  | [![NuGet](https://buildstats.info/nuget/PInvoke.SHCore)](https://www.nuget.org/packages/PInvoke.SHCore)|[Windows Shell][Shell32]
user32.dll   |`PInvoke.User32`  | [![NuGet](https://buildstats.info/nuget/PInvoke.User32)](https://www.nuget.org/packages/PInvoke.User32)|Windows User Interface
userenv.dll  |`PInvoke.Userenv` | [![NuGet](https://buildstats.info/nuget/PInvoke.Userenv)](https://www.nuget.org/packages/PInvoke.Userenv)|Windows User Environment
uxtheme.dll  |`PInvoke.UxTheme` | [![NuGet](https://buildstats.info/nuget/PInvoke.UxTheme)](https://www.nuget.org/packages/PInvoke.UxTheme)|[Windows Visual Styles][UxTheme]
WtsApi32.dll |`PInvoke.WtsApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.WtsApi32)](https://www.nuget.org/packages/PInvoke.WtsApi32)|[Windows Remote Desktop Services][Wtsapi32]

Check out the [P/Invoke coverage](coverage.md) we have for each library.

## Contribution

Please consider [contributing](CONTRIBUTING.md) more P/Invoke method signatures to this project.
Once you contribute, you can immediately consume your additions without waiting for another
public release of the library.

[CNG]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376210
[Crypt32]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa380256
[DwmApi]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa969540.aspx
[Hid]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff538865
[Msi]: https://msdn.microsoft.com/en-us/library/aa372860.aspx
[SetupApi]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff550855
[Gdi]: https://msdn.microsoft.com/en-us/library/dd145203
[Psapi]: https://msdn.microsoft.com/en-us/library/windows/desktop/ms684884.aspx
[UxTheme]: https://msdn.microsoft.com/en-us/library/windows/desktop/bb773187.aspx
[NetApi32]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa370680.aspx
[Shell32]: https://msdn.microsoft.com/en-us/library/windows/desktop/bb773177.aspx
[Wtsapi32]: https://msdn.microsoft.com/en-us/library/aa383468(v=vs.85).aspx

[pull-requests-img]: http://www.issuestats.com/github/aarnott/pinvoke/badge/pr
[pull-requests-url]: http://www.issuestats.com/github/aarnott/pinvoke

[issues-closed-img]: http://www.issuestats.com/github/aarnott/pinvoke/badge/issue
[issues-closed-url]: http://www.issuestats.com/github/aarnott/pinvoke
