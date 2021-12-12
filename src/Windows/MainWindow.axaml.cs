using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainViewModel<MainWindow>(this);
        }

        IThemeSwitch IMainWindow.ThemeSwitch => App.Current as IThemeSwitch;
    }
}
