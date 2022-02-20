using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public partial class MainWindowMacOS : Window, IMainWindow
    {
        public MainWindowMacOS()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainViewModel<MainWindowMacOS>(this);
        }

        IThemeSwitch IMainWindow.ThemeSwitch => App.Current as IThemeSwitch;
    }
}
