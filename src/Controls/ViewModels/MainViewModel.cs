using System;
using System.IO;

using Avalonia.Media.Imaging;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Controls.ViewModels
{
    internal sealed class MainViewModel : ReactiveObject
    {
        private readonly IBitmap _dotNetImage;
        private readonly IBitmap _avaloniaImage;

        public IBitmap DotNetImage => this._dotNetImage;

        public IBitmap AvaloniaImage => this._avaloniaImage;

        public MainViewModel()
        {
            this._dotNetImage = Utilities.GetImageFromFile(GetImageFullPath("dotnet.png"));
            this._avaloniaImage = Utilities.GetImageFromFile(GetImageFullPath("avalonia.png"));
        }

        private static String GetImageFullPath(String fileName)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

        ~MainViewModel()
        {
            this._dotNetImage.Dispose();
            this._avaloniaImage.Dispose();
        }
    }
}
