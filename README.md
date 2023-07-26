# P/Invoke

**⚠ NOTICE: [Check out CsWin32](https://github.com/dotnet/pinvoke/issues/565): A new, preferred approach for Win32 p/invokes now exists for C# developers.**

This repo is no longer maintained.

---

A collection of libraries intended to contain all P/Invoke method signatures for popular operating systems.
Think of it as https://pinvoke.net, but proven to compile and work properly, and often
with sample usage in the form of unit tests.

A unique C# project wraps each native library.
The C# project may multi-target in order to support many versions of .NET Framework, .NET Core and .NET Standard.

Win32 APIs for all Windows versions are welcome.
Special Windows Store targeted assemblies omit p/invoke signatures to banned APIs so your Store apps can depend on these libraries without getting rejected by the Store certification process.

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).

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

### What if I need custom `uint` value not provided in `enum`?

Cast any `uint` to specific `enum` type and pass as parameter.

## Design goals

Provide a slightly higher than lowest level API for P/Invoke signatures.
For example, instead of `IntPtr` parameters and `uint` flags, you'll see `SafeHandle`-derived
types as parameters and flags `enum` types. API documentation will be provided via XML doc comments
for easy reading with Intellisense, along with links to the describing pages on MSDN
or elsewhere as applicable.

In some cases we offer several overloads of a given native method to offer native pointer and
`IntPtr` access. We encourage folks to try writing C# `unsafe` code before using `IntPtr` because
it (ironically) can often be easier to write correct and efficient code using native pointers than
all the casting and `Marshal` call overhead that `IntPtr` requires.
Note that when a method's only use of a native pointer is its return type, the `IntPtr` returning
variant must be given a different method name by CLR overloading rules, so look for the same method
but with an `_IntPtr` suffix.

## Distribution

This library should be available on NuGet for easy consumption by your projects.
You may also copy and paste the P/Invoke signatures you need directly into your projects if desired.

Packages:

Library      | Package name     | NuGet       | Description
-------------|------------------|-------------|-------------
advapi32.dll |`PInvoke.AdvApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.AdvApi32)](https://www.nuget.org/packages/PInvoke.AdvApi32)|Windows Advanced Services
bcrypt.dll   |`PInvoke.BCrypt`  | [![NuGet](https://buildstats.info/nuget/PInvoke.BCrypt)](https://www.nuget.org/packages/PInvoke.BCrypt)|[Windows Cryptography API: Next Generation][CNG]
cabinet.dll  |`PInvoke.Cabinet` | [![NuGet](https://buildstats.info/nuget/PInvoke.Cabinet)](https://www.nuget.org/packages/PInvoke.Cabinet)|[Cabinet API Functions][Cabinet]
cfgmgr32.dll |`PInvoke.CfgMgr32`| [![NuGet](https://buildstats.info/nuget/PInvoke.CfgMgr32)](https://www.nuget.org/packages/PInvoke.CfgMgr32)|[Device and Driver Installation][CfgMgr32]
crypt32.dll  |`PInvoke.Crypt32` | [![NuGet](https://buildstats.info/nuget/PInvoke.Crypt32)](https://www.nuget.org/packages/PInvoke.Crypt32)|[Windows Cryptography API][Crypt32]
DwmApi.dll   |`PInvoke.DwmApi`  | [![NuGet](https://buildstats.info/nuget/PInvoke.DwmApi)](https://www.nuget.org/packages/PInvoke.DwmApi)|[Desktop Window Manager][DwmApi]
fusion.dll   |`PInvoke.Fusion`  | [![NuGet](https://buildstats.info/nuget/PInvoke.Fusion)](https://www.nuget.org/packages/PInvoke.Fusion)|.NET Framework Fusion
gdi32.dll    |`PInvoke.Gdi32`   | [![NuGet](https://buildstats.info/nuget/PInvoke.Gdi32)](https://www.nuget.org/packages/PInvoke.Gdi32)|[Windows Graphics Device Interface][Gdi]
hid.dll      |`PInvoke.Hid`     | [![NuGet](https://buildstats.info/nuget/PInvoke.Hid)](https://www.nuget.org/packages/PInvoke.Hid)|[Windows Human Interface Devices][Hid]
iphlpapi.dll |`PInvoke.IPHlpApi`| [![NuGet](https://buildstats.info/nuget/PInvoke.IPHlpApi)](https://www.nuget.org/packages/PInvoke.IPHlpApi)|[IP Helper](IPHlpApi)
kernel32.dll |`PInvoke.Kernel32`| [![NuGet](https://buildstats.info/nuget/PInvoke.Kernel32)](https://www.nuget.org/packages/PInvoke.Kernel32)|Windows Kernel API
magnification.dll |`PInvoke.Magnification`| [![NuGet](https://buildstats.info/nuget/PInvoke.Magnification)](https://www.nuget.org/packages/PInvoke.Magnification)|[Windows Magnification API][Magnification]
mscoree.dll  |`PInvoke.MSCorEE` | [![NuGet](https://buildstats.info/nuget/PInvoke.MSCorEE)](https://www.nuget.org/packages/PInvoke.MSCorEE)|.NET Framework CLR host
msi.dll      |`PInvoke.Msi`     | [![NuGet](https://buildstats.info/nuget/PInvoke.Msi)](https://www.nuget.org/packages/PInvoke.Msi)|[Microsoft Installer][Msi]
ncrypt.dll   |`PInvoke.NCrypt`  | [![NuGet](https://buildstats.info/nuget/PInvoke.NCrypt)](https://www.nuget.org/packages/PInvoke.NCrypt)|[Windows Cryptography API: Next Generation][CNG]
netapi32.dll |`PInvoke.NetApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.NetApi32)](https://www.nuget.org/packages/PInvoke.NetApi32)|[Network Management][NetApi32]
newdev.dll   |`PInvoke.NewDev`  | [![NuGet](https://buildstats.info/nuget/PInvoke.NewDev)](https://www.nuget.org/packages/PInvoke.NewDev)|[Device and Driver Installation][NewDev]
ntdll.dll    |`PInvoke.NTDll`   | [![NuGet](https://buildstats.info/nuget/PInvoke.NTDll)](https://www.nuget.org/packages/PInvoke.NTDll)|Windows NTDll
psapi.dll    |`PInvoke.Psapi`   | [![NuGet](https://buildstats.info/nuget/PInvoke.Psapi)](https://www.nuget.org/packages/PInvoke.Psapi)|[Windows Process Status API][Psapi]
setupapi.dll |`PInvoke.SetupApi`| [![NuGet](https://buildstats.info/nuget/PInvoke.SetupApi)](https://www.nuget.org/packages/PInvoke.SetupApi)|[Windows setup API][SetupApi]
SHCore.dll   |`PInvoke.SHCore`  | [![NuGet](https://buildstats.info/nuget/PInvoke.SHCore)](https://www.nuget.org/packages/PInvoke.SHCore)|[Windows Shell][Shell32]
shell32.dll  |`PInvoke.Shell32` | [![NuGet](https://buildstats.info/nuget/PInvoke.Shell32)](https://www.nuget.org/packages/PInvoke.Shell32)|[Windows Shell][Shell32]
user32.dll   |`PInvoke.User32`  | [![NuGet](https://buildstats.info/nuget/PInvoke.User32)](https://www.nuget.org/packages/PInvoke.User32)|[Windows User Interface][User32]
userenv.dll  |`PInvoke.Userenv` | [![NuGet](https://buildstats.info/nuget/PInvoke.Userenv)](https://www.nuget.org/packages/PInvoke.Userenv)|Windows User Environment
uxtheme.dll  |`PInvoke.UxTheme` | [![NuGet](https://buildstats.info/nuget/PInvoke.UxTheme)](https://www.nuget.org/packages/PInvoke.UxTheme)|[Windows Visual Styles][UxTheme]
winusb.dll   |`PInvoke.WinUsb`  | [![NuGet](https://buildstats.info/nuget/PInvoke.WinUsb)](https://www.nuget.org/packages/PInvoke.WinUsb)|[USB Driver][WinUsb]
WtsApi32.dll |`PInvoke.WtsApi32`| [![NuGet](https://buildstats.info/nuget/PInvoke.WtsApi32)](https://www.nuget.org/packages/PInvoke.WtsApi32)|[Windows Remote Desktop Services][WtsApi32]

Check out the [P/Invoke coverage][PInvokeCoverageReport] we have for each library.

If you need a P/Invoke that is in our source code but not yet released to nuget.org, you can consume the packages directly from our CI feed by adding this package source to your nuget.config file

```xml
<add key="PInvoke" value="https://pkgs.dev.azure.com/andrewarnott/OSS/_packaging/PublicCI/nuget/v3/index.json" />
```

## Contribution

Please consider [contributing](CONTRIBUTING.md) more P/Invoke method signatures to this project.
Once you contribute, you can immediately consume your additions without waiting for another
public release of the library.

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

[CfgMgr32]: https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/
[CNG]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376210
[Crypt32]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa380256
[DwmApi]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa969540.aspx
[Hid]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff538865
[IPHlpApi]: https://docs.microsoft.com/en-us/windows/win32/api/_iphlp/
[Magnification]: https://msdn.microsoft.com/en-us/library/windows/desktop/ms692162
[Msi]: https://msdn.microsoft.com/en-us/library/aa372860.aspx
[SetupApi]: https://msdn.microsoft.com/en-us/library/windows/hardware/ff550855
[Gdi]: https://msdn.microsoft.com/en-us/library/dd145203
[Psapi]: https://msdn.microsoft.com/en-us/library/windows/desktop/ms684884.aspx
[UxTheme]: https://msdn.microsoft.com/en-us/library/windows/desktop/bb773187.aspx
[NetApi32]: https://msdn.microsoft.com/en-us/library/windows/desktop/aa370680.aspx
[NewDev]: https://docs.microsoft.com/en-us/windows/win32/api/newdev/
[Shell32]: https://msdn.microsoft.com/en-us/library/windows/desktop/bb773177.aspx
[WinUsb]: https://docs.microsoft.com/en-us/windows/win32/api/winusb/
[WtsApi32]: https://msdn.microsoft.com/en-us/library/aa383468(v=vs.85).aspx
[Cabinet]: https://docs.microsoft.com/en-us/windows/win32/devnotes/cabinet-api-functions
[User32]: https://docs.microsoft.com/en-us/windows/win32/api/winuser

[PInvokeCoverageReport]: https://github.com/dotnet/pinvoke/wiki/coverage
