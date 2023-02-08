using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class AboutWindow : Window
    {
        public AboutWindow() : this(false) { }

        public AboutWindow(Boolean darkTheme)
        {
            this.InitializeComponent(darkTheme);
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent(Boolean darkTheme = default)
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new AboutViewModel(darkTheme);
        }
    }
}
