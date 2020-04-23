This project shows how to integrate [Avalonia UI](https://avaloniaui.net) and [CoreRT](https://github.com/dotnet/corert). Both frameworks are incredible from a technical standpoint. However, they are under constant, heavy development, are not well documented, and require subtle knowledge spread across multiple sources.
Using this project, you will learn how to develop using both frameworks. You may also use it as a skeleton for your projects.

## System requirements
This project was tested only under Windows, and this readme assumes you are using Windows. To build this project, you need:

* Any supported 64-bit edition of Windows. CoreRT produces only 64-bit Windows apps.
* Visual Studio. VS 20019 Community is free for personal use. Get if from [here](https://visualstudio.microsoft.com).
When installing Visual Studio, select *.NET desktop development* and *Desktop development with C++* workloads. To generate native code, CoreRT requires the native C++ toolchain and Windows SDK. This configuration ensures you have them.
* .Net Core SDK. At the time of writing, .Net Core 5.0 is in a preview state. Download it from [here](https://dotnet.microsoft.com/download/dotnet/5.0). Note: Make sure that you download and install the *SDK*. The runtime is not enough for building apps.
* Git. Install [Git for Windows](https://git-scm.com/download/win).

## Getting started

### Get the source code
After you have installed the prerequisites, your first step is to get the source code:
1. From the Windows Start menu, start *x64 Native Tools Command Prompt for VS 2019*. This configures the development environment with 64-bit dev tools, which CoreRT requires to build your apps.
1. Get the sample project. In your terminal, and clone it:

```bash
git clone git@github.com:teobugslayer/AvaloniaCoreRTDemo.git
cd AvaloniaCoreRTDemo
```

### Build the project
At the time of writing, there's an incompatibility between the current version of Avalonia (0.9.9) and CoreRT, which we need to solve. To give you context, CoreRT is an ahead-of-time compiler, and specific code patterns cannot be used with it, while JIT compilers handle them easily. One such pattern is the infinite generic type expansions, and one of Avalonia dependencies uses it, as discussed in [this issue](https://github.com/dotnet/corert/issues/7920#issuecomment-568536702). The library which uses this code has released a fixed version. However, Avalonia still depends on an older version of the library and thus does not have the fix. We need to force the new version. To do this, the sample project explicitly refers to the new version of this sub-dependency:

```XML
<PackageReference Include="System.Reactive" Version="4.4.1" />
```

Also, the project uses the [NuGet restore with a lock file](https://devblogs.microsoft.com/nuget/enable-repeatable-package-restores-using-a-lock-file/) feature to ensure that our version of the dependency takes precedence:

```XML
<RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
```

Therefore, to build the sample, you perform the following:

1. Open the solution file in Visual Studio. You may use `start .\AvaloniaCoreRTDemo.sln` from your terminal.
1. Build the solution using `Release` and `x64` configuration. 
You need this step because it produces some files which you will need later.
1. Go back to your terminal.
1. Delete the existing Nuget version lock file (this step is not needed when you build the code for the first time): `del src\packages.lock.json`
1. Build the source code: `dotnet publish -r win-x64 -c release /p:RestoreLockedMode=true`

**Note**: Avalonia and CoreRT are huge. Downloading them might take some time. During this period, which happens on the first build, and when CoreRT releases a new version, it will look like nothing happens. Just be patient.

We are almost ready - just one more step! CoreRT creates a single executable containing all your *managed* code. However, Avalonia depends on a few unmanaged DLLs. Let's supply them! To do this:

1. In your terminal open Explorer - invoke the command `start .`
1. Navigate to `src\bin\x64\Release\net5.0` and copy the entire `runtimes` directory. This directory has been created by the build you performed earlier. 
1. Navigate to `src\bin\Release\net5.0\win-x64\publish` and paste it.
1. Double-click AvaloniaCoreRTDemo.exe - it should start!

## Further development

Feel free to use this sample as a base for your projects. 

When developing, keep in mind that Avalonia uses Reflection extensively. CoreRT, being an AOT compiler, needs your help to get reflection right. Refer to `rd.xml` file in the solution. In it, you describe all assemblies and types which your app would potentially reflect over. For more information, see [Reflection in AOT mode](https://github.com/dotnet/corert/blob/master/Documentation/using-corert/reflection-in-aot-mode.md)

This project is configured to help you debug issues with publishing. Before publishing, check the CSPROJ file and modify the various Ilc* properties according to [Optimizing CoreRT](https://github.com/dotnet/corert/blob/master/Documentation/using-corert/optimizing-corert.md) document.
