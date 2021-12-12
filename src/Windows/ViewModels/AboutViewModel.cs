using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return !_darkTheme ? "windows.png" : "windows_d.png";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return !_darkTheme ? "macos.png" : "macos_d.png";
                else
                    return !_darkTheme ? "linux.png" : "linux_d.png";
            }
        }

        public AboutViewModel(Boolean darkTheme)
        {
            this._darkTheme = darkTheme;
            this._computerImage = GetImageFromResources(this.ComputerImageName);
        }

        ~AboutViewModel()
        {
            this._computerImage.Dispose();
        }

        private static Bitmap GetImageFromResources(String fileName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            String resourceName = asm.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(fileName));
            if (resourceName != null)
                using (Stream bitmapStream = asm.GetManifestResourceStream(resourceName))
                    return new Bitmap(bitmapStream);
            else
                return default;
        }
    }
}
