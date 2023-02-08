using System;

using Avalonia.Media.Imaging;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Controls.ViewModels
{
    internal sealed class MainControlViewModel : ReactiveObject, IMainWindowState
    {
        private readonly IBitmap _dotNetImage;
        private readonly IBitmap _avaloniaImage;

        private Boolean _unloadable = false;

        public IBitmap DotNetImage => this._dotNetImage;
        public IBitmap AvaloniaImage => this._avaloniaImage;
        public String? Text { get; set; }

        public MainControlViewModel()
        {
            this._dotNetImage = Utilities.GetImageFromFile("dotnet.png");
            this._avaloniaImage = Utilities.GetImageFromFile("avalonia.png");
        }

        public MainControlViewModel(IMainWindowState state)
        {
            this._avaloniaImage = state.AvaloniaImage;
            this._dotNetImage = state.DotNetImage;
            this.Text = state.Text;
            state.SetUnloadable();
        }

        ~MainControlViewModel()
        {
            if (!this._unloadable)
            {
                this._dotNetImage.Dispose();
                this._avaloniaImage.Dispose();
            }
        }

        void IMainWindowState.SetUnloadable()
        {
            this._unloadable = true;
        }
    }
}
