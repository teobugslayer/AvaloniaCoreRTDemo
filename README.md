This project shows how to integrate [Avalonia UI](https://avaloniaui.net) and [NativeAOT](https://github.com/dotnet/runtimelab/tree/feature/NativeAOT) (previously CoreRT). Both frameworks are under heavy development, have sparce documentation, and require subtle knowledge spread across multiple sources.
Using this project, you will learn how to develop using both frameworks. You may also use it as a starting point for your projects.

## System requirements
This project is tested only under Windows, and this readme assumes you are using Windows. To build this project, you need:

* Any supported 64-bit edition of Windows. CoreRT requires 64-bit Windows and produces only 64-bit Windows apps.
* Visual Studio. VS 20019 Community is free for personal use. Get if from [here](https://visualstudio.microsoft.com).
When installing Visual Studio, select *.NET desktop development* and *Desktop development with C++* workloads. To generate native code, NativeAOT requires the native C++ toolchain and Windows SDK. This configuration ensures you have them.
* .Net 5.0 SDK. Download it from [here](https://dotnet.microsoft.com/download/dotnet/5.0). Note: Make sure that you download and install the *SDK*. The runtime is not enough for building apps.
* Git. Install [Git for Windows](https://git-scm.com/download/win).

## Getting started

### Get the source code
After you have installed the prerequisites, your first step is to get the source code:
1. From the Windows Start menu, start *x64 Native Tools Command Prompt for VS 2019*. This configures the development environment with 64-bit dev tools, which CoreRT requires to build your apps.
1. Get the sample project. Go to your terminal, and clone it:

```bash
git clone git@github.com:teobugslayer/AvaloniaCoreRTDemo.git
cd AvaloniaCoreRTDemo
```
Then, build the sample:

```bash
dotnet publish -r win-x64 -c release
```
**Note**: Avalonia and NativeAOT are huge and downloading their NuGet packages may take some time. During this period, which happens on the first build, and when NativeAOT releases a new version, it will look like nothing happens. Just be patient.

We are ready - In your terminal, navigate to `src\bin\Release\net5.0\win-x64\publish`, and start AvaloniaCoreRTDemo.exe - it should work!

## Further development

Feel free to use this sample as a base for your projects.

When developing, keep in mind that Avalonia uses Reflection extensively. CoreRT, being an AOT compiler, needs your help to get reflection right. Refer to `rd.xml` file in the solution. In it, you describe all assemblies and types which your app would potentially reflect over. For more information, see [Reflection in AOT mode](https://github.com/dotnet/corert/blob/master/Documentation/using-corert/reflection-in-aot-mode.md)

This project is configured to help you debug issues with publishing. Before publishing, check the CSPROJ file and modify the various Ilc* properties according to [Optimizing CoreRT](https://github.com/dotnet/corert/blob/master/Documentation/using-corert/optimizing-corert.md) document.
