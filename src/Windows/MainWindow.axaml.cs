using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Controls;
using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        private readonly Application? _app = App.Current;

        public MainWindow() : this(default) { }
        public MainWindow(IMainWindow? window)
        {
            this.InitializeComponent(window);
#if DEBUG
            this.AttachDevTools();
#endif
        }

        IThemeSwitch IMainWindow.ThemeSwitch => (this._app as IThemeSwitch)!;
        IMainWindowState IMainWindow.Model => (this.GetControl<MainControl>("mainControl")!.DataContext as IMainWindowState)!;

        private void InitializeComponent(IMainWindow? window)
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainViewModel<MainWindow>(this);
            this.GetControl<MainControl>("mainControl").Reload(window?.Model);
        }
    }
}
