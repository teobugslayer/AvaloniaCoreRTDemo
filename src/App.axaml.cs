using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

using AvaloniaCoreRTDemo.Interfaces;
using AvaloniaCoreRTDemo.Windows;

namespace AvaloniaCoreRTDemo
{
    public sealed class App : Application, IThemeSwitch
    {
        private IStyle _baseLight;
        private IStyle _baseDark;

        private IStyle _fluentLight;
        private IStyle _fluentDark;

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
                desktop.MainWindow = 
#if !OSX
                new MainWindow();
#else
                new MainWindowMacOS();
#endif
                this.DataContext = desktop.MainWindow.DataContext;
            }
            base.OnFrameworkInitializationCompleted();
        }

        private void InitializeThemes()
        {
            this._baseDark = this.Styles[0];
            this._baseLight = this.Styles[1];

            this.Styles.Remove(this._baseDark);

            this._fluentLight = (FluentTheme)this.Resources["fluentLight"]!;
            this._fluentDark = (FluentTheme)this.Resources["fluentDark"]!;

            this._currentTheme = ApplicationTheme.DefaultLight;
        }

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;

        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            this._currentTheme = theme;
            switch (theme)
            {
                case ApplicationTheme.DefaultLight:
                    this.Styles[0] = this._baseLight;
                    this.Styles.Remove(this._baseDark);
                    break;
                case ApplicationTheme.DefaultDark:
                    this.Styles[0] = this._baseDark;
                    this.Styles.Remove(this._baseLight);
                    break;
                case ApplicationTheme.FluentLight:
                    this.Styles[0] = this._fluentLight;
                    this.Styles.Remove(this._fluentDark);
                    if (!this.Styles.Contains(this._baseLight))
                        this.Styles.Add(this._baseLight);
                    break;
                case ApplicationTheme.FluentDark:
                    this.Styles[0] = this._fluentDark;
                    this.Styles.Remove(this._baseLight);
                    if (!this.Styles.Contains(this._baseDark))
                        this.Styles.Add(this._baseDark);
                    break;
            }
        }
    }
}