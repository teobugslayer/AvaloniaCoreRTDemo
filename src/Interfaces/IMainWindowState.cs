using System;

using Avalonia.Media;

namespace AvaloniaCoreRTDemo
{
    public interface IMainWindowState
    {
        IImage DotNetImage { get; }
        IImage AvaloniaImage { get; }
        String? Text { get; }

        void SetUnloadable();
    }
}

