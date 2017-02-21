# Menge's C-Sharp Bindings

This project produces a dll (MengeCS.dll) which can be included in C-Sharp projects to provide
access to the Menge simulation core.  This is a very simple wrapper of the Menge C-API.  The
features in this library will grow as the C-API grows, exposing more Menge features to C#. As it
is, this is sufficient to initialize the Menge simulator, step through simulation, and query minimum
agent state.

## How to Use 

The project depends on the MengeCore.dll.  You'll want to modify the build settings to match your
local build of Menge.  Do the following:

1. Open the file `$MengeCS$\MengeCS\MengeCS.csproj` in a text editor.
2. Line 5 defines the property: `MengeDir`.  Change the path shown there to match the path to
	   the Menge library build on your system.
	   
This will allow the project to automatically pull over the most recent version of the MengeCore.dll
into your project.  This is particularly important because we don't want include the MengeCore.dll
_in_ this repository.

This includes a Visual Studio 2013 solution with two projects:

- `MengeCS` - an interop-services based wrapper for the Menge C-API
- `MengeCSExe` - a simple command-line program illustrating simple execution of the `MengeCS`
	   library.

	   
## 32-bit vs 64-bit MengeCore.dll

The `MengeCS` project doesn't care whether the `MengeCore.dll` is built in 32- or 64-bit mode. 
However, the executable _does_ care.  In creating your own exectuable, make sure the "Platform 
target" is set appropriately for the build of `MengeCore.dll`: `x86` for 32-bit and `x64` for
64-bit.  Otherwise, there _will_ be an error loading the dll.