using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        private static readonly IThemeSwitch themeSwitch = (IThemeSwitch)App.Current!;

        private readonly WindowState? _initialState;

        public MainWindow() : this(default) { }

        public MainWindow(IMainWindow? window)
        {
            this._initialState = window?.State;
            this.InitializeComponent(window);
        }

        IThemeSwitch IMainWindow.ThemeSwitch => themeSwitch;
        IMainWindowState IMainWindow.Model => (IMainWindowState)this.MainControl.DataContext!;
        PixelPoint IMainWindow.Position => Utilities.GetWindowPosition(this);
        Size IMainWindow.ClientSize => this.ClientSize;
        Size? IMainWindow.FrameSize => this.FrameSize;
        WindowState IMainWindow.State => this.WindowState;

        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            // The window state on non-windows platforms seems to have to be initialized after
            // window loading.
            if (this._initialState.HasValue && !Utilities.IsWindows)
                this.WindowState = this._initialState.Value;
        }

        private void InitializeComponent(IMainWindow? window)
        {
            //Use generated InitializeComponent method.
            this.InitializeComponent(loadXaml: true);
            this.DataContext = new MainViewModel<MainWindow>(this);
            this.InitializeMenu();
            if (window is not null)
            {
                this.MainControl.Reload(window.Model);
                this.SetSizeAndPosition(window);
            }
        }
        private void InitializeMenu()
        {
            NativeMenu menu = (NativeMenu)this[NativeMenu.MenuProperty]!;
            DisableCurrentTheme(menu, themeSwitch.Current);
            if (Utilities.IsOSX)
                RemoveAboutMenu(menu);
        }
        private void SetSizeAndPosition(IMainWindow window)
        {
            if (Utilities.IsWindows) this.WindowState = window.State;
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.Position = window.Position;
                this.FrameSize = window.FrameSize;
                this.ClientSize = window.ClientSize;
                this.Height = window.Height;
                this.Width = window.Width;
            }
        }

        private static void DisableCurrentTheme(NativeMenu menu, ApplicationTheme theme)
        {
            NativeMenuItem themeMenu = (NativeMenuItem)menu.Items[1];
            NativeMenuItem themeItem = (NativeMenuItem)themeMenu.Menu!.Items[(Int32)theme];
            themeItem.IsEnabled = false;
        }
        private static void RemoveAboutMenu(NativeMenu menu)
        {
            NativeMenuItem fileMenu = (NativeMenuItem)menu.Items[0];
            fileMenu.Menu!.Items.RemoveAt(1);
        }
    }
}
