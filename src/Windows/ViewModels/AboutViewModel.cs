using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Avalonia.Media.Imaging;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal record SystemDetail(string Key, string Value);

    internal sealed class AboutViewModel : ReactiveObject
    {

        private readonly IBitmap _computerImage;
        private readonly Boolean _darkTheme;

        public IBitmap ComputerImage => _computerImage;

        public IReadOnlyList<SystemDetail> SystemDetails { get; } = new[]
        {
            new SystemDetail("Number of Cores", Environment.ProcessorCount.ToString()),
            new SystemDetail("OS", RuntimeInformation.OSDescription),
            new SystemDetail("OS Arch", RuntimeInformation.OSArchitecture.ToString()),
            new SystemDetail("OS Version", Environment.OSVersion.ToString()),
            new SystemDetail("Computer", Environment.MachineName),
            new SystemDetail("User", Environment.UserName),
            new SystemDetail("System Path", Environment.SystemDirectory),
            new SystemDetail("Current Path", Environment.CurrentDirectory),
            new SystemDetail("Process Arch", RuntimeInformation.ProcessArchitecture.ToString()),
            new SystemDetail("Runtime Name", RuntimeInformation.FrameworkDescription),
            new SystemDetail("Runtime Path", RuntimeEnvironment.GetRuntimeDirectory()),
            new SystemDetail("Runtime Version", RuntimeEnvironment.GetSystemVersion()),
            new SystemDetail("Framework Version", Environment.Version.ToString()),
        };

        private String ComputerImageName
        {
            get
            {
                if (Utilities.IsWindows)
                    return !this._darkTheme ? "windows.png" : "windows_d.png";
                else if (Utilities.IsOSX)
                    return !this._darkTheme ? "macos.png" : "macos_d.png";
                else
                    return !this._darkTheme ? "linux.png" : "linux_d.png";
            }
        }

        public AboutViewModel(Boolean darkTheme)
        {
            this._darkTheme = darkTheme;
            this._computerImage = Utilities.GetImageFromResources(this.ComputerImageName);
        }

        ~AboutViewModel()
        {
            this._computerImage.Dispose();
        }
    }
}
