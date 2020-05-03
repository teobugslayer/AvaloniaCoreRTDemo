using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Avalonia.Media.Imaging;
using ReactiveUI;
namespace AvaloniaCoreRTDemo
{
    public class AboutWindowViewModel : ReactiveObject
    {
        private readonly IBitmap computerImage;

        public IBitmap ComputerImage => computerImage;
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
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return "windows.png";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return "macos.png";
                else
                    return "linux.png";
            }
        }

        public AboutWindowViewModel()
        {
            this.computerImage = GetImageFromResources(this.ComputerImageName);
        }

        ~AboutWindowViewModel()
        {
            this.computerImage.Dispose();
        }

        private static Bitmap GetImageFromResources(String fileName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            String resourceName = asm.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(fileName));
            if (resourceName != null)
                using (Stream a = asm.GetManifestResourceStream(resourceName))
                    return new Bitmap(a);
            else
                return null;
        }
    }
}
