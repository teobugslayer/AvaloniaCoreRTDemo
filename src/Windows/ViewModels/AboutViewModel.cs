using System;
using System.Runtime.InteropServices;

using Avalonia.Media.Imaging;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal sealed class AboutViewModel : ReactiveObject
    {
        private readonly IBitmap _computerImage;
        private readonly Boolean _darkTheme;

        public IBitmap ComputerImage => _computerImage;
        public String NCores => Environment.ProcessorCount.ToString();
        public String OS => RuntimeInformation.OSDescription;
        public String OSArch => RuntimeInformation.OSArchitecture.ToString();
        public String OSVersion => Environment.OSVersion.ToString();
        public String ComputerName => Environment.MachineName;
        public String UserName => Environment.UserName;
        public String SystemPath => Environment.SystemDirectory;
        public String CurrentPath => Environment.CurrentDirectory;
        public String ProcessArch => RuntimeInformation.ProcessArchitecture.ToString();
        public String RuntimeName => RuntimeInformation.FrameworkDescription;
        public String RuntimePath => RuntimeEnvironment.GetRuntimeDirectory();
        public String RuntimeVersion => RuntimeEnvironment.GetSystemVersion();
        public String FrameworkVersion => Environment.Version.ToString();

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
