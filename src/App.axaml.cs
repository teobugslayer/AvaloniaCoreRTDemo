
using System;
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
        private IStyle _fluentDataGrid;
        private IStyle _simpleDataGrid;

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
            this._fluentDataGrid = (IStyle)this.Resources["fluentDataGrid"]!;
            this._simpleDataGrid = (IStyle)this.Resources["simpleDataGrid"]!;
            Styles.Add(_fluentTheme);
            Styles.Add(_fluentDataGrid);

            this._currentTheme = ApplicationTheme.FluentLight;
        }

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;

        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            var themeChanged = theme switch
            {
                ApplicationTheme.SimpleLight => _currentTheme is ApplicationTheme.FluentDark or ApplicationTheme.FluentLight,
                ApplicationTheme.SimpleDark => _currentTheme is ApplicationTheme.FluentDark or ApplicationTheme.FluentLight,
                ApplicationTheme.FluentLight => _currentTheme is ApplicationTheme.SimpleLight or ApplicationTheme.SimpleDark,
                ApplicationTheme.FluentDark => _currentTheme is ApplicationTheme.SimpleLight or ApplicationTheme.SimpleDark,
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };
            
            this._currentTheme = theme;
            switch (theme)
            {
                case ApplicationTheme.SimpleLight:
                    this._simpleTheme.Mode = SimpleThemeMode.Light;
                    this.Styles[0] = this._simpleTheme;
                    this.Styles[1] = this._simpleDataGrid;
                    break;
                case ApplicationTheme.SimpleDark:
                    this._simpleTheme.Mode = SimpleThemeMode.Dark;
                    this.Styles[0] = this._simpleTheme;
                    this.Styles[1] = this._simpleDataGrid;
                    break;
                case ApplicationTheme.FluentLight:
                    this._fluentTheme.Mode = FluentThemeMode.Light;
                    this.Styles[0] = this._fluentTheme;
                    this.Styles[1] = this._fluentDataGrid;
                    break;
                case ApplicationTheme.FluentDark:
                    this._fluentTheme.Mode = FluentThemeMode.Dark;
                    this.Styles[0] = this._fluentTheme;
                    this.Styles[1] = this._fluentDataGrid;
                    break;
            }

            if (themeChanged && ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var oldWindow = desktop.MainWindow;
                var newWindow = new MainWindow();
                desktop.MainWindow = newWindow;
                newWindow.Show();
                oldWindow.Close();
                this.DataContext = desktop.MainWindow.DataContext;
            }
        }
    }
}