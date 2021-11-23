using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaCoreRTDemo
{
    public class AboutWindow : Window
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
            this.DataContext = new AboutWindowViewModel(darkTheme);
        }
    }
}
