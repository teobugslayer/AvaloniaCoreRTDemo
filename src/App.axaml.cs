using System;

using Avalonia;
using Avalonia.Controls;
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
        private FluentTheme _fluentTheme = default!;
        private SimpleTheme _simpleTheme = default!;
        private IStyle _fluentDataGrid = default!;
        private IStyle _simpleDataGrid = default!;

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
            this._simpleTheme = new SimpleTheme();
            this._fluentTheme = new FluentTheme();

            this._fluentDataGrid = (IStyle)this.Resources["fluentDataGrid"]!;
            this._simpleDataGrid = (IStyle)this.Resources["simpleDataGrid"]!;

            Styles.Add(_fluentTheme);
            Styles.Add(_fluentDataGrid);
            this._currentTheme = ApplicationTheme.FluentLight;
        }

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;

        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            if (theme == this._currentTheme)
                return;

            Boolean themeChanged = theme switch
            {
                ApplicationTheme.SimpleLight => this._currentTheme is ApplicationTheme.FluentDark or ApplicationTheme.FluentLight,
                ApplicationTheme.SimpleDark => this._currentTheme is ApplicationTheme.FluentDark or ApplicationTheme.FluentLight,
                ApplicationTheme.FluentLight => this._currentTheme is ApplicationTheme.SimpleLight or ApplicationTheme.SimpleDark,
                ApplicationTheme.FluentDark => this._currentTheme is ApplicationTheme.SimpleLight or ApplicationTheme.SimpleDark,
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };

            this._currentTheme = theme;
            switch (theme)
            {
                case ApplicationTheme.SimpleLight:
                    this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
                    this.Styles[0] = this._simpleTheme;
                    this.Styles[1] = this._simpleDataGrid;
                    break;
                case ApplicationTheme.SimpleDark:
                    this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
                    this.Styles[0] = this._simpleTheme;
                    this.Styles[1] = this._simpleDataGrid;
                    break;
                case ApplicationTheme.FluentLight:
                    this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
                    this.Styles[0] = this._fluentTheme;
                    this.Styles[1] = this._fluentDataGrid;
                    break;
                case ApplicationTheme.FluentDark:
                    this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
                    this.Styles[0] = this._fluentTheme;
                    this.Styles[1] = this._fluentDataGrid;
                    break;
            }

            if (themeChanged && this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                MainWindow oldWindow = (desktop.MainWindow as MainWindow)!;
                MainWindow newWindow = new(oldWindow);

                desktop.MainWindow = newWindow;
                this.DataContext = newWindow.DataContext;

                oldWindow.Hide();
                newWindow.Show();
                oldWindow.Close();
            }
        }
    }
}