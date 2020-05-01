using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaCoreRTDemo
{
    public class AboutWindow : Window
    {
        public AboutWindow()
        {
            this.InitializeComponent();
            this.DataContext = new AboutWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
