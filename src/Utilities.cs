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
            var assetLoader = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();
            using var assetStream = assetLoader.Open(new Uri($"avares://AvaloniaCoreRTDemo/Images/{fileName}"));
            return new Bitmap(assetStream);
        }

        public static PixelPoint GetWindowPosition(Window window)
        {
            if (!window.FrameSize.HasValue)
                return window.Position;

            if (IsWindows)
            {
                PixelSize borderSize = GetWindowsBorderSize(window.PlatformImpl);
                Int32 xOffset = borderSize.Width + (Int32)(window.FrameSize.Value.Width - window.ClientSize.Width) / 2;
                return new(window.Position.X - xOffset, window.Position.Y);
            }
            else
            {
                Int32 yOffset = (Int32)(window.FrameSize.Value.Height - window.ClientSize.Height);
                return new(window.Position.X, window.Position.Y + yOffset);
            }
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
