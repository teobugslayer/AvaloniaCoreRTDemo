using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            this.InitializeComponent();
        }

        public AboutWindow(Boolean darkTheme)
        {
            this.InitializeComponent(darkTheme);
        }

        private void InitializeComponent(Boolean darkTheme = default)
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new AboutViewModel(darkTheme);
        }
    }
}
