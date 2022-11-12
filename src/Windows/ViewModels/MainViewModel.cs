using System;
using System.Reactive;

using Avalonia.Controls;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal sealed class MainViewModel<TWindow> : MainViewModelBase
        where TWindow : Window, IMainWindow
    {
        private readonly TWindow _window;

        public MainViewModel(TWindow window)
            : base(window.ThemeSwitch)
        {
            this._window = window;
            this.ChangeTheme(window.ThemeSwitch.Current);
        }


        public override void HelpAboutMethod() => base.RunHelpAbout(this._window);

        public override void DefaultLightMethod() => this.ChangeTheme(ApplicationTheme.SimpleLight);
        public override void DefaultDarkMethod() => this.ChangeTheme(ApplicationTheme.SimpleDark);
        public override void FluentLightMethod() => this.ChangeTheme(ApplicationTheme.FluentLight);
        public override void FluentDarkMethod() => this.ChangeTheme(ApplicationTheme.FluentDark);
        
        private void ChangeTheme(ApplicationTheme theme)
        {
            this.DefaultLightEnabled = theme != ApplicationTheme.SimpleLight && theme != ApplicationTheme.FluentLight;
            this.DefaultDarkEnabled = theme != ApplicationTheme.SimpleDark && theme != ApplicationTheme.FluentDark;
            this.FluentLightEnabled = theme != ApplicationTheme.FluentLight;
            this.FluentDarkEnabled = theme != ApplicationTheme.FluentDark;
            this._window.ThemeSwitch?.ChangeTheme(theme);
        }
    }
}
