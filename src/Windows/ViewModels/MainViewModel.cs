using Avalonia.Controls;

using AvaloniaCoreRTDemo.Interfaces;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal sealed class MainViewModel<TWindow> : ApplicationModelBase
        where TWindow : Window, IMainWindow
    {
        private TWindow _window;

        public MainViewModel(TWindow window)
            : base(window.ThemeSwitch)
        {
            this._window = window;
        }

        public override void HelpAboutMethod() => base.RunHelpAbout(this._window);
        public override void DefaultLightMethod() => base.SetTheme(ApplicationTheme.SimpleLight);
        public override void DefaultDarkMethod() => base.SetTheme(ApplicationTheme.SimpleDark);
        public override void FluentLightMethod() => base.SetTheme(ApplicationTheme.FluentLight);
        public override void FluentDarkMethod() => base.SetTheme(ApplicationTheme.FluentDark);
    }
}
