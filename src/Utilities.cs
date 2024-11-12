using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaCoreRTDemo
{
    internal static class Utilities
    {
        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        public static readonly Boolean IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static readonly Boolean IsOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static readonly Boolean IsLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static Bitmap GetImageFromResources(String fileName)
        {
            Uri resourceUri = new($"avares://AvaloniaCoreRTDemo/Images/{fileName}");
            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        public static PixelPoint GetWindowPosition(Window window)
        {
            PixelPoint result = window.Position;
            return result;
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
