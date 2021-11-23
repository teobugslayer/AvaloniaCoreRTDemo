using System;
using System.Reactive;

using Avalonia.Media.Imaging;

using ReactiveUI;

using Path = System.IO.Path;

namespace AvaloniaCoreRTDemo
{
    public class MainWindowViewModel : ReactiveObject
    {
        private IBitmap dotNetImage;
        private IBitmap avaloniaImage;
        private readonly MainWindow _window;

        public IBitmap DotNetImage
        {
            get { return dotNetImage; }
            set { this.RaiseAndSetIfChanged(ref this.dotNetImage, value); }
        }
        public IBitmap AvaloniaImage
        {
            get { return avaloniaImage; }
            set { this.RaiseAndSetIfChanged(ref this.avaloniaImage, value); }
        }
        public ReactiveCommand<Unit, Unit> FileExitCommand { get; }

        public MainWindowViewModel(MainWindow window)
        {
            this._window = window;

            this.DotNetImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnet.png"));
            this.AvaloniaImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avalonia.png"));

            this.FileExitCommand = ReactiveCommand.Create(RunFileExit);
        }

        public void DefaultLightMethod() => this.ChangeTheme(ApplicationTheme.DefaultLight);
        public void DefaultDarkMethod() => this.ChangeTheme(ApplicationTheme.DefaultDark);
        public void FluentLightMethod() => this.ChangeTheme(ApplicationTheme.FluentLight);
        public void FluentDarkMethod() => this.ChangeTheme(ApplicationTheme.FluentDark);
        public void HelpAboutMethod() => RunHelpAbout();

        private void RunFileExit()
        {
            Environment.Exit(0);
        }

        private void ChangeTheme(ApplicationTheme theme)
        {
            switch (theme)
            {
                case ApplicationTheme.FluentLight:
                    this._window.DefaultDark.IsEnabled = true;
                    this._window.DefaultLight.IsEnabled = false;
                    break;
                case ApplicationTheme.FluentDark:
                    this._window.DefaultDark.IsEnabled = false;
                    this._window.DefaultLight.IsEnabled = true;
                    break;
                default:
                    this._window.DefaultDark.IsEnabled = true;
                    this._window.DefaultLight.IsEnabled = true;
                    break;
            }
            this._window.ThemeHelper?.ChangeTheme(theme);
        }

        private async void RunHelpAbout()
        {
            await new AboutWindow(IsDarkTheme(this._window.ThemeHelper?.CurrentTheme())).ShowDialog(_window);
        }

        private static Boolean IsDarkTheme(ApplicationTheme? theme)
            => theme switch
            {
                ApplicationTheme.DefaultDark => true,
                ApplicationTheme.FluentDark => true,
                _ => false,
            };
    }
}