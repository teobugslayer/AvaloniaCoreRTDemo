using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class AboutWindow : Window
    {
        private readonly Boolean _darkTheme;

        public AboutWindow() : this(false) { }

        public AboutWindow(Boolean darkTheme)
        {
            this._darkTheme = darkTheme;
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new AboutViewModel(this._darkTheme);
        }
    }
}
