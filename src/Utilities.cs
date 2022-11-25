using System;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaCoreRTDemo
{
    internal static class Utilities
    {
        public static readonly Boolean IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static readonly Boolean IsOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static Bitmap GetImageFromResources(String fileName)
        {
            var assetLoader = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();
            using var assetStream = assetLoader.Open(new Uri($"avares://AvaloniaCoreRTDemo/Images/{fileName}"));
            return new Bitmap(assetStream);
        }

        public static Bitmap GetImageFromFile(String path)
        {
            try
            {
                return new Bitmap(GetImageFullPath(path));
            }
            catch (Exception)
            {
                return GetImageFromResources("broken-link.png");
            }
        }
        
        private static String GetImageFullPath(String fileName)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
    }
}
