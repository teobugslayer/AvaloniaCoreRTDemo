using System;
using System.Reactive;
using Avalonia.Controls;
using AvaloniaCoreRTDemo.Interfaces;
using ReactiveUI;

namespace AvaloniaCoreRTDemo.Windows.ViewModels;

internal abstract class ApplicationModelBase : ReactiveObject
{
    private readonly IThemeSwitch _themeSwitch;
    private bool _aboutEnable = true;
    private bool _defaultLightEnable = false;
    private bool _defaultDarkEnable = false;
    private bool _fluentLightEnable = false;
    private bool _fluentDarkEnable = false;
    private bool _classicEnable = false;

    public bool AboutEnabled
    {
        get => this._aboutEnable;
        set => this.RaiseAndSetIfChanged(ref this._aboutEnable, value);
    }

    public bool DefaultLightEnabled
    {
        get => this._defaultLightEnable;
        set => this.RaiseAndSetIfChanged(ref this._defaultLightEnable, value);
    }

    public bool DefaultDarkEnabled
    {
        get => this._defaultDarkEnable;
        set => this.RaiseAndSetIfChanged(ref this._defaultDarkEnable, value);
    }

    public bool FluentLightEnabled
    {
        get => this._fluentLightEnable;
        set => this.RaiseAndSetIfChanged(ref this._fluentLightEnable, value);
    }

    public bool FluentDarkEnabled
    {
        get => this._fluentDarkEnable;
        set => this.RaiseAndSetIfChanged(ref this._fluentDarkEnable, value);
    }

    public bool ClassicEnabled
    {
        get => this._classicEnable;
        set => this.RaiseAndSetIfChanged(ref this._classicEnable, value);
    }

    public ReactiveCommand<Unit, Unit> FileExitCommand { get; }

    public ApplicationModelBase(IThemeSwitch themeSwitch)
    {
        this._themeSwitch = themeSwitch;
        this.IntializeTheme(themeSwitch.Current);
        this.FileExitCommand = ReactiveCommand.Create(RunFileExit);
    }

    public abstract void HelpAboutMethod();
    public abstract void DefaultLightMethod();
    public abstract void DefaultDarkMethod();
    public abstract void FluentLightMethod();
    public abstract void FluentDarkMethod();
    public abstract void ClassicMethod();

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

    protected void SetTheme(ApplicationTheme theme)
    {
        this.IntializeTheme(theme);
        this._themeSwitch.ChangeTheme(theme);
    }

    private void RunFileExit() => Environment.Exit(0);

    private void IntializeTheme(ApplicationTheme theme)
    {
        this.DefaultLightEnabled = theme != ApplicationTheme.SimpleLight;
        this.DefaultDarkEnabled = theme != ApplicationTheme.SimpleDark;
        this.FluentLightEnabled = theme != ApplicationTheme.FluentLight;
        this.FluentDarkEnabled = theme != ApplicationTheme.FluentDark;
    }

    private static bool IsDarkTheme(ApplicationTheme? theme)
        => theme switch
        {
            ApplicationTheme.SimpleDark => true,
            ApplicationTheme.FluentDark => true,
            _ => false,
        };
}
