using System;

using Avalonia;
using Avalonia.Controls;

using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        private IThemeSwitch ThemeSwitch => (IThemeSwitch)App.Current!;

        public MainWindow() : this(default) { }

        public MainWindow(IMainWindow? window)
        {
            this.InitializeComponent(window);
        }

        IThemeSwitch IMainWindow.ThemeSwitch => this.ThemeSwitch;
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
            this.InitializeMenu();
            if (window is not null)
            {
                this.MainControl.Reload(window.Model);
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.WindowState = window.State;
                this.Position = window.Position;
                this.FrameSize = window.FrameSize;
                this.ClientSize = window.ClientSize;
                this.Height = window.Height;
                this.Width = window.Width;
            }
        }

        private void InitializeMenu()
        {
            NativeMenu menu = (NativeMenu)this[NativeMenu.MenuProperty]!;
            DisableCurrentTheme(menu, this.ThemeSwitch.Current);
            if (Utilities.IsOSX)
                RemoveAboutMenu(menu);
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
