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
        public static String NCores => Environment.ProcessorCount.ToString();
        public static String OS => RuntimeInformation.OSDescription;
        public static String OSArch => RuntimeInformation.OSArchitecture.ToString();
        public static String OSVersion => Environment.OSVersion.ToString();
        public static String ComputerName => Environment.MachineName;
        public static String UserName => Environment.UserName;
        public static String SystemPath => Environment.SystemDirectory;
        public static String CurrentPath => Environment.CurrentDirectory;
        public static String ProcessArch => RuntimeInformation.ProcessArchitecture.ToString();
        public static String RuntimeName => RuntimeInformation.FrameworkDescription;
        public static String RuntimePath => RuntimeEnvironment.GetRuntimeDirectory();
        public static String RuntimeVersion => RuntimeEnvironment.GetSystemVersion();
        public static String FrameworkVersion => Environment.Version.ToString();

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
