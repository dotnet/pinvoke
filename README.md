P/Invoke
=======

[![Build status](https://ci.appveyor.com/api/projects/status/idu56hy4jwytxd3x?svg=true)](https://ci.appveyor.com/project/AArnott/pinvoke)

A library intended to contain all P/Invoke method signatures for popular operating systems.
Think of it as http://pinvoke.net, but proven to compile, work properly

## Usage

Install the NuGet package(s) for the DLLs you want to P/Invoke into.
For example, if you want to P/Invoke into Win32's BCrypt.dll, install this package:

    Install-Package PInvoke.BCrypt

Then import the following namespaces, as demonstrated below (if using C# 6):

    using PInvoke;
    using static PInvoke.BCrypt; // Supported in C# 6 (VS2015) and later.

This will allow you to conveniently call these methods either 

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

## Contribution
Please consider [contributing](CONTRIB.txt) more P/Invoke method signatures to this project.
