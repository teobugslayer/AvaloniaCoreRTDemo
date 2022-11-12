using System;

using Avalonia.Controls;

using AvaloniaCoreRTDemo.Interfaces;

using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels
{
    internal abstract class MainViewModelBase : ReactiveObject
    {
        private readonly IThemeSwitch _themeSwitch;
        private Boolean _aboutEnable = true;

        public Boolean AboutEnabled
        {
            get => this._aboutEnable;
            set => this.RaiseAndSetIfChanged(ref this._aboutEnable, value);
        }

        public MainViewModelBase(IThemeSwitch window)
            => this._themeSwitch = window;

        public abstract void HelpAboutMethod();

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
