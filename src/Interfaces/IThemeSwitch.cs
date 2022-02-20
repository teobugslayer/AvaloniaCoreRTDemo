namespace AvaloniaCoreRTDemo.Interfaces
{
    public interface IThemeSwitch
    {
        ApplicationTheme Current { get; }
        void ChangeTheme(ApplicationTheme theme);
    }
}
