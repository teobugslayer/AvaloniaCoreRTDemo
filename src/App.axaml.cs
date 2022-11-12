
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Themes.Simple;
using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows;

namespace AvaloniaCoreRTDemo
{
    public sealed class App : Application, IThemeSwitch
    {
        private FluentTheme _fluentTheme;
        private SimpleTheme _simpleTheme;

        private ApplicationTheme _currentTheme;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            this.Name = "AvaloniaCoreRTDemo";
        }

        public override void OnFrameworkInitializationCompleted()
        {
            this.InitializeThemes();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                this.DataContext = desktop.MainWindow.DataContext;
            }
            base.OnFrameworkInitializationCompleted();
        }

        private void InitializeThemes()
        {
            this._fluentTheme = (FluentTheme)this.Resources["fluentTheme"]!;
            this._simpleTheme = (SimpleTheme)this.Resources["simpleTheme"]!;
            Styles.Add(_fluentTheme);

            this._currentTheme = ApplicationTheme.FluentLight;
        }

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;

        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            this._currentTheme = theme;
            switch (theme)
            {
                case ApplicationTheme.SimpleLight:
                    this._simpleTheme.Mode = SimpleThemeMode.Light;
                    this.Styles[0] = this._simpleTheme;
                    break;
                case ApplicationTheme.SimpleDark:
                    this._simpleTheme.Mode = SimpleThemeMode.Dark;
                    this.Styles[0] = this._simpleTheme;
                    break;
                case ApplicationTheme.FluentLight:
                    this._fluentTheme.Mode = FluentThemeMode.Light;
                    this.Styles[0] = this._fluentTheme;
                    break;
                case ApplicationTheme.FluentDark:
                    this._fluentTheme.Mode = FluentThemeMode.Dark;
                    this.Styles[0] = this._fluentTheme;
                    break;
            }
        }
    }
}