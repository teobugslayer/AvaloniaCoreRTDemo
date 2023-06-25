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

        public static Bitmap GetImageFromResources(String fileName)
        {
            Uri resourceUri = new($"avares://AvaloniaCoreRTDemo/Images/{fileName}");
            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        public static PixelPoint GetWindowPosition(Window window)
        {
            PixelPoint result = window.Position;
            Size frameSize = window.FrameSize ?? default;
            if (IsWindows)
            {
                PixelSize borderSize = GetWindowsBorderSize(window.PlatformImpl);
                Int32 xOffset = borderSize.Width + (Int32)(frameSize.Width - window.ClientSize.Width) / 2;
                result = new(result.X - xOffset, result.Y);
            }
            else if (IsOSX)
            {
                Int32 yOffset = (Int32)(frameSize.Height - window.ClientSize.Height);
                result = new(window.Position.X, window.Position.Y + yOffset);
            }
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

        private static PixelSize GetWindowsBorderSize(IWindowImpl? imp)
        {
            if (imp?.GetType()?.GetProperty("HiddenBorderSize", bindingFlags) is PropertyInfo prop)
                return (PixelSize)prop.GetValue(imp)!;
            return default;
        }
    }
}
