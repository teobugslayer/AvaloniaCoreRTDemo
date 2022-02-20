using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Avalonia.Media.Imaging;

namespace AvaloniaCoreRTDemo
{
    internal static class Utilities
    {
        public static readonly Boolean IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static readonly Boolean IsOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static Bitmap GetImageFromResources(String fileName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            String resourceName = asm.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(fileName));
            if (resourceName != null)
                using (Stream bitmapStream = asm.GetManifestResourceStream(resourceName))
                    return new Bitmap(bitmapStream);
            else
                return default;
        }

        public static Bitmap GetImageFromFile(String path)
        {
            try
            {
                return new Bitmap(path);
            }
            catch (Exception)
            {
                return GetImageFromResources("broken-link.png");
            }
        }
    }
}
