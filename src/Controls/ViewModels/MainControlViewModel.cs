using System;

using Avalonia.Media;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Controls.ViewModels
{
    internal sealed class MainControlViewModel : ReactiveObject, IMainWindowState
    {
        private readonly IImage _dotNetImage;
        private readonly IImage _avaloniaImage;

        private Boolean _unloadable = false;

        public IImage DotNetImage => this._dotNetImage;
        public IImage AvaloniaImage => this._avaloniaImage;
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
                (this._dotNetImage as IDisposable)?.Dispose();
                (this._avaloniaImage as IDisposable)?.Dispose();
            }
        }

        void IMainWindowState.SetUnloadable()
        {
            this._unloadable = true;
        }
    }
}
