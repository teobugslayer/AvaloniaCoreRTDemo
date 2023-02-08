using Avalonia.Controls;

namespace AvaloniaCoreRTDemo.Interfaces
{
    public interface IMainWindow
    {
        IThemeSwitch ThemeSwitch { get; }
        IMainWindowState Model { get; }
    }
}
