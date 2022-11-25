using System;
using System.Reactive;
using Avalonia.Controls;

using AvaloniaCoreRTDemo.Interfaces;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal abstract class MainViewModelBase : ReactiveObject
    {
        private readonly IThemeSwitch _themeSwitch;
        private Boolean _aboutEnable = true;
        private Boolean _defaultLightEnable = true;
        private Boolean _defaultDarkEnable = true;
        private Boolean _fluentLightEnable = true;
        private Boolean _fluentDarkEnable = true;

        public Boolean AboutEnabled
        {
            get => this._aboutEnable;
            set => this.RaiseAndSetIfChanged(ref this._aboutEnable, value);
        }

        public MainViewModelBase(IThemeSwitch window)
        {
            this._themeSwitch = window;
            this.FileExitCommand = ReactiveCommand.Create(RunFileExit);
        }

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
        
        public abstract void HelpAboutMethod();

        public abstract void DefaultLightMethod();
        public abstract void DefaultDarkMethod();
        public abstract void FluentLightMethod();
        public abstract void FluentDarkMethod();
        
        private void RunFileExit()
            => Environment.Exit(0);
        
        protected async void RunHelpAbout(Window currentWindow)
        {
            if (this.AboutEnabled)
                try
                {
                    this.AboutEnabled = false;
                    await new AboutWindow(IsDarkTheme(this._themeSwitch.Current)).ShowDialog(currentWindow);
                }
                finally
                {
                    this.AboutEnabled = true;
                }
        }

        private static Boolean IsDarkTheme(ApplicationTheme? theme)
            => theme switch
            {
                ApplicationTheme.SimpleDark => true,
                ApplicationTheme.FluentDark => true,
                _ => false,
            };
    }
}
