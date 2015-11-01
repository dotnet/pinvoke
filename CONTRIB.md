Contributing
============

There are many thousands of Win32 APIs and this library is not complete.
Please send pull requests to add what you've come up with.

## Guidelines

### Learn how to write P/Invoke signatures

The [sigimp tool][SigImp] will automatically generate P/Invoke signatures for most Win32 functions
and interop types. Use it to save time and improve accuracy as we collect these signatures into these
reusable libraries. But try to cut down the verbose output that may be produced by a tool.

Remember whether you write the signatures yourself or use a tool, to follow the rest of the guidelines
in this document.

### Project structure

 * One class library and NuGet package per P/Invoke'd DLL.
 * Types and enums in common Windows header files should be defined in the PInvoke.Windows.Core project.

When introducing support for a new native DLL to this project, use the templates\AddNewLibrary.ps1
Powershell cmdlet to create the projects necessary to support it and follow the instructions from that script.

### File structure

 * Nested classes and structs go into their own files.
 * P/Invoke methods go into the *binary*.cs file. While higher level helper methods go in *binary*.Helpers.cs.

### Naming

 * Name the class with the P/Invokes after the DLL. The namespace should be `PInvoke`
   and should not be appended with the DLL name.
 * Types introduced to support the P/Invoke methods (e.g. enums, structs, etc.)
   should be nested types within the class named after the DLL.
 * All method names should match exactly their names as found in the native DLL.
   Do not remove a common prefix even if it is redundant with the class name.
   This is for predictability across the entire family of libraries and so
   searches for method names as they are found in the native libraries' documentation
   will always turn up results if they are defined by these packages.

### Method parameters

 * Prefer `SafeHandle`-derived types to `IntPtr` when dealing with handles.
   Mark P/Invoke methods that destroy handles private because they will necessarily take `IntPtr`
   and the pattern for users should be to `Dispose` of your `SafeHandle`.
 * Prefer `IntPtr` over unsafe pointers. But be sure the xml doc comments for the parameter specify the expected type.
 * Prefer `enum` types over `int` or `uint` flags. Generally, name flags enums as `METHODNAMEFlags`, for example
   `CreateFileFlags` for the flags that are passed to `CreateFile`.

### Helper methods

Helper methods should be kept at a minimum. The scope of this P/Invoke library is primarily
to make native methods accessible from managed code -- not to create a high-level API that
uses the native binary as an implementation detail.

Helper methods are an excellent addition when one or more of these conditions are true
of the P/Invoke method they wrap:

1. The method requires special memory allocations and deallocations of the caller,
   or requires multiple calls to determine the size of the buffer then fill it.
1. The method has a single out parameter that in a naturally managed API would typically
   serve as the return value, and the P/Invoke method's return value is void or an error code.
1. A set of methods for enumeration can be wrapped with a helper that exposes an IEnumerable.



Helper methods should *not* be created merely for purposes of translating an error code to an exception.
But if a helper method exists for other reasons, it is appropriate to throw instead of return
an error code when the helper method uses its return value for something else.

## Self-service releases for contributors

As soon as you send a pull request, a build is executed and updated NuGet packages
are published to this Package Feed:

    https://ci.appveyor.com/nuget/pinvoke

By adding this URL to your package sources you can immediately install your version
of the NuGet packages to your project. This can be done by adding a nuget.config file
with the following content to the root of your project's repo:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <add key="PInvoke CI" value="https://ci.appveyor.com/nuget/pinvoke" />
    </packageSources>
</configuration>
```

You can then install the package(s) while you have your new "PInvoke CI" package source selected:

    Install-Package PInvoke.BCrypt -Pre -Version 0.1.41-beta-g02f355c05d

Take care to set the package version such that it exactly matches the AppVeyor build
for your pull request. You can get the version number by reviewing the result of the
validation build for your pull request, clicking ARTIFACTS, and noting the version
of the produced packages.

[SigImp]: http://blogs.msdn.com/b/vbteam/archive/2008/03/14/making-pinvoke-easy.aspx
