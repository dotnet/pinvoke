P/Invoke
=======

[![Build status](https://ci.appveyor.com/api/projects/status/idu56hy4jwytxd3x?svg=true)](https://ci.appveyor.com/project/AArnott/pinvoke)

A library intended to contain all P/Invoke method signatures for popular operating systems. Think of it as http://pinvoke.net, but proven to compile, work properly

## Design goals

Provide a slightly higher than lowest level API for P/Invoke signatures. For example, instead of `IntPtr` parameters and `uint` flags, you'll see `SafeHandle`-derived types as parameters and flags `enum` types. API documentation will be provided via XML doc comments for easy reading with Intellisense, along with links to the describing pages on MSDN or elsewhere as applicable.

This is a portable library so you can use it anywhere.

## Testing
In as many cases as possible, these P/Invoke method signatures will be tested via unit testing in this project.

## Distribution
This library should be available on NuGet for easy consumption by your projects. You may also copy and paste the P/Invoke signatures you need directly into your projects if desired. 

## Contribution
There are many thousands of Win32 APIs and this library is not complete. Please send pull requests to add what you've come up with.
