# OpenPackageCreator
Open Package Creator is a tool to easily package an application in an OPK file for OpenDingux, complete with a generated .desktop meta data file.

Primarily for Windows, but also runs just fine for Linux with Mono

## Dependencies

Windows
* .NET Redistributable
* Patched squashfs-tools (included with the release)

Linux
* Mono
* Mono Winforms
* squashfs-tools

## Patched squashfs-tools
In the directory squashfs-tools, there's a patch for a special version. This version will automatically patch executables with the executable flag when packing.
