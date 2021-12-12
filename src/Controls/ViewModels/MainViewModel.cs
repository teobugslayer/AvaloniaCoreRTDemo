using System;
using System.IO;
using System.Runtime.CompilerServices;

using Avalonia.Media.Imaging;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Controls.ViewModels
{
    internal sealed class MainViewModel : ReactiveObject
    {
        private readonly IBitmap _dotNetImage;
        private readonly IBitmap _avaloniaImage;

        public IBitmap DotNetImage
        {
            get { return _dotNetImage; }
            set { this.RaiseAndSetIfChanged(ref Unsafe.AsRef(this._dotNetImage), value); }
        }

        public IBitmap AvaloniaImage
        {
            get { return _avaloniaImage; }
            set { this.RaiseAndSetIfChanged(ref Unsafe.AsRef(this._avaloniaImage), value); }
        }

        public MainViewModel()
        {
            this._dotNetImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnet.png"));
            this._avaloniaImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avalonia.png"));
        }
    }
}
