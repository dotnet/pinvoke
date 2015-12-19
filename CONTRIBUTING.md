Contributing
============

There are many thousands of Win32 APIs and this library is not complete.
Please send pull requests to add what you've come up with.

## Guidelines

### Learn how to write P/Invoke signatures

The [sigimp tool][SigImp] will automatically generate P/Invoke signatures for most Win32 functions
and interop types. Use it to save time and improve accuracy as we collect these signatures into these
reusable libraries. But try to cut down the verbose output that may be produced by a tool.
And always double-check the generated code because these tools are known to sometimes misinterpret
parameter types.

Remember whether you write the signatures yourself or use a tool, to follow the rest of the guidelines
in this document.

### Project structure

 * One class library (or two, with a Shared Project between them, when portable and desktop are targets)
   and NuGet package per P/Invoke'd DLL.
 * Types, enums, and constants defined in common Windows header files should be defined
   in the PInvoke.Windows.Core project.

When introducing support for a new native DLL to this project, use the templates\AddNewLibrary.ps1
Powershell cmdlet to create the projects necessary to support it and follow the instructions from that script.
The library should also be added to the list on the [readme](README.md).

### Win32 API Sets

When developing a library for Win32, be aware of [API Sets][APISets] and follow the pattern in
[Kernel32.cs](src/Kernel32.Shared/Kernel32.cs) to use them in the portable project but not for the
"desktop" targeted project. 

Be sure to use the *lowest* version of the API Sets facade that includes your function.
For example, `FormatMessage` appears in `api-ms-win-core-localization-l1-2-1.dll` according to
[Windows API Sets][APISets] but appears under `api-ms-win-core-localization-l1-2-0.dll`
under the older [Windows 8 API Sets][APISets8] page. So we use the older so it works as well on
Windows 8 as it does on newer Windows versions.

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
 * Preserve the original parameter names.

There is a tension between keeping names consistent between native and managed code,
and conforming to common .NET naming patterns such as camelCase and PascalCase.
For this project, we preserve names of methods, parameter values, constants, and
anything else found in native header files for these reasons:

1. A predictable API tends to be more useful and appreciated by its users. While we
   can make some names look more .NET-like, we cannot do it for all of them. This
   leads to inconsistencies and thus unpredictability for our users.
1. Keeping the names the same empowers users to share code more freely between native
   and managed code. They can more confidently share code snippets on forums
   where those more familiar with the native library will recognize the names used.
1. Discoverability of APIs by consistency with documentation. When someone is searching
   for the definition of a method, an enum value or struct in this project based on
   the name from native code or documentation, they'll find it if it's there.
1. Documentation of methods and parameter usage will match with the P/Invoke methods'
   signatures, leading to quicker understanding of how to use these APIs properly.
1. Changing names from their native definitions requires some judgment calls be made,
   which can lead to potentially long discussions during pull requests while folks
   debate the merits of various options. We prefer to spend time adding more APIs
   over ever-repeating discussions on code reviews.

### Method parameter types

 * Prefer `SafeHandle`-derived types to `IntPtr` when dealing with handles.
   Mark P/Invoke methods that destroy handles private because they will necessarily take `IntPtr`
   and the pattern for users should be to `Dispose` of your `SafeHandle`.
 * Prefer native pointers over `IntPtr`. We have automatic code generation in place during the build
   to create `IntPtr` overloads of these methods.
 * When a native method accepts a pointer to a byte array, consider creating two P/Invoke overloads:
   one that takes `byte[]` and one that takes `byte*`. The former being more convenient for most callers,
   while the latter is more efficient when callers may want to point to some offset into the array.
 * Prefer `enum` types over `int` or `uint` flags. Generally, name flags enums as `METHODNAMEFlags`, for example
   `CreateFileFlags` for the flags that are passed to `CreateFile`.

### Helper methods

Helper methods should be kept at a minimum. The scope of this P/Invoke library is primarily
to make native methods accessible from managed code -- not to create a high-level API that
uses the native binary as an implementation detail. Think of helper methods as filling in
where .NET interop marshaling falls short.

Helper methods should usually appear as overloads of the P/Invoke methods by sharing their
method name with the method they wrap. The "raw" P/Invoke method should also be `public`
so callers who may have very particular requirements can skip the helper method.

Helper methods are an excellent addition when one or more of these conditions are true
of the P/Invoke method they wrap:

1. The method requires special memory allocations and deallocations of the caller,
   or requires multiple calls to determine the size of the buffer then fill it.
1. The method has a single out parameter that in a naturally managed API would typically
   serve as the return value, and the P/Invoke method's return value is void or an error code.
1. A set of methods for enumeration can be wrapped with a helper that exposes an IEnumerable.
1. Exposing asynchrony as a .NET Task via an async method.

Helper methods should *not*:

1. Merely translate an error code to an exception.
   But if a helper method exists for other reasons, it is appropriate to throw instead of return
   an error code when the helper method uses its return value for something else.
1. Cater to specific use cases. This purpose should be reserved for an external project that focuses
   on raising the abstraction layer for the native library.

When a helper method does not exactly match the name of a P/Invoke method (e.g. enumerator
or async helpers) the name should blend the method naming patterns of the native library
with .NET conventions. For example, `EnumerateFiles` or `CreateFileAsync`.

### Xml documentation

We do not require it, but we encourage xml doc comments for all P/Invoke and helper methods
because it shows up in Intellisense and can aid users in coding against these APIs.
This documentation may be copied (where licensing allows) from the native library's own
documentation. We consider MSDN an allowable source of documentation.

Consider touching up the docs you copy or author by adding `<see cref="..." />` around
references to other methods and `<paramref name="..." />` for references to parameters.

#### Practical advice for copying documentation

When copying and pasting multiple paragraphs of documentation into an
xml doc comment you might start with this:

```csharp
    /// <summary>
    /// [PASTEHERE]
    /// </summary>
```

The C# language service will often paste something like this:

```csharp
    /// <summary>
    /// First line of documentation
    Second line of documentation.With missing space after sentences.
    Third line.With more missing spaces
    /// </summary>
```

Notice not only the missing `///` but that sentences are missing a space between each other
on subsequent lines. The easiest way to fix this is to get in the habit of pasting by:
Ctrl+V, Ctrl+Z. The Undo command will not revert the paste, but it will revert the formatting
that the language service applied. Which turns the above paste to this:
 
```csharp
    /// <summary>
    /// First line of documentation
Second line of documentation. With missing space after sentences.
Third line. With more missing spaces
    /// </summary>
```

Which you can then use block selection (alt+shift) followed by `///` to add the missing
slashes to every line at once, saving time. Once the commenting slashes are in place,
press Ctrl+K, Ctrl+D to execute the Format Document command to fix up the indentation
and anything else that can be automatically fixed.

### StyleCop

We have StyleCop.Analyzers installed to all our projects with the set of rules that we
generally want to follow. They appear as build warnings, so please check for those
before submitting pull requests and clear up any warnings you've introduced.

In some cases, such as when we use a class instead of a struct,
we will have public fields for interop marshaling reasons. The StyleCop rule that dislikes
this can be suppressed by adding this near the top of your file:

```csharp
#pragma warning disable SA1401 // Fields must be private
```

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

```powershell
Install-Package PInvoke.BCrypt -Pre -Version 0.1.41-beta-g02f355c05d
```

Take care to set the package version such that it exactly matches the AppVeyor build
for your pull request. You can get the version number by reviewing the result of the
validation build for your pull request, clicking ARTIFACTS, and noting the version
of the produced packages.

[SigImp]: http://blogs.msdn.com/b/vbteam/archive/2008/03/14/making-pinvoke-easy.aspx
[APISets]: https://msdn.microsoft.com/en-us/library/windows/desktop/hh802935(v=vs.85).aspx
[APISets8]: https://msdn.microsoft.com/en-us/library/windows/desktop/dn505783(v=vs.85).aspx
