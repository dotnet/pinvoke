Contributing
============

There are many thousands of Win32 APIs and this library is not complete.
Please send pull requests to add what you've come up with.

## Guidelines

### Project structure

 * One class library and NuGet package per P/Invoke'd DLL.
 * Types and enums in common Windows header files should be defined in the PInvoke.Windows.Core project.

### File structure

 * Nested classes and structs go into their own files.
 * P/Invoke methods go into the *binary*.cs file. While higher level helper methods go in *binary*.Helpers.cs.

### Naming

 * All method names should match exactly their names as found in the native DLL.
   Do not remove a common prefix even if it is redundant with the class name.
   This is for predictability across the entire family of libraries and so
   searches for method names as they are found in the native libraries' documentation
   will always turn up results if they are defined by these packages.

### Method parameters

 * Prefer `SafeHandle`-derived types to `IntPtr`.
 * Prefer `enum` types over `int` or `uint` flags.
