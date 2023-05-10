using Avalonia;
using Avalonia.Controls;

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
        }

        IThemeSwitch IMainWindow.ThemeSwitch => (IThemeSwitch)this._app!;
        IMainWindowState IMainWindow.Model => (IMainWindowState)this.MainControl.DataContext!;
        PixelPoint IMainWindow.Position => Utilities.GetWindowPosition(this);
        Size IMainWindow.ClientSize => this.ClientSize;
        Size? IMainWindow.FrameSize => this.FrameSize;
        WindowState IMainWindow.State => this.WindowState;

        private void InitializeComponent(IMainWindow? window)
        {
            //Use generated InitializeComponent method.
            this.InitializeComponent(loadXaml: true);
            this.DataContext = new MainViewModel<MainWindow>(this);
            if (window is not null)
            {
                this.MainControl.Reload(window.Model);
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.WindowState = window.State;
                this.Position = window.Position;
                this.FrameSize = window.FrameSize;
                this.ClientSize = window.ClientSize;
            }
        }
    }
}
