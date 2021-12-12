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

        private Boolean _defaultLightEnable = true;
        private Boolean _defaultDarkEnable = true;
        private Boolean _fluentLightEnable = true;
        private Boolean _fluentDarkEnable = true;

        public Boolean DefaultLightEnabled
        {
            get => this._defaultLightEnable;
            set => this.RaiseAndSetIfChanged(ref this._defaultLightEnable, value);
        }

        public Boolean DefaultDarkEnabled
        {
            get => this._defaultDarkEnable;
            set => this.RaiseAndSetIfChanged(ref this._defaultDarkEnable, value);
        }

        public Boolean FluentLightEnabled
        {
            get => this._fluentLightEnable;
            set => this.RaiseAndSetIfChanged(ref this._fluentLightEnable, value);
        }

        public Boolean FluentDarkEnabled
        {
            get => this._fluentDarkEnable;
            set => this.RaiseAndSetIfChanged(ref this._fluentDarkEnable, value);
        }

        public ReactiveCommand<Unit, Unit> FileExitCommand { get; }

        public MainViewModel(TWindow window)
            : base(window.ThemeSwitch)
        {
            this._window = window;
            this.FileExitCommand = ReactiveCommand.Create(RunFileExit);
            this.ChangeTheme(window.ThemeSwitch.Current);
        }

        public void DefaultLightMethod() => this.ChangeTheme(ApplicationTheme.DefaultLight);
        public void DefaultDarkMethod() => this.ChangeTheme(ApplicationTheme.DefaultDark);
        public void FluentLightMethod() => this.ChangeTheme(ApplicationTheme.FluentLight);
        public void FluentDarkMethod() => this.ChangeTheme(ApplicationTheme.FluentDark);
        public void HelpAboutMethod() => base.RunHelpAbout(this._window);

        private void RunFileExit()
            => Environment.Exit(0);

        private void ChangeTheme(ApplicationTheme theme)
        {
            this.DefaultLightEnabled = theme != ApplicationTheme.DefaultLight && theme != ApplicationTheme.FluentLight;
            this.DefaultDarkEnabled = theme != ApplicationTheme.DefaultDark && theme != ApplicationTheme.FluentDark;
            this.FluentLightEnabled = theme != ApplicationTheme.FluentLight;
            this.FluentDarkEnabled = theme != ApplicationTheme.FluentDark;
            this._window.ThemeSwitch?.ChangeTheme(theme);
        }
    }
}
