using System;
using Avalonia.Media.Imaging;

namespace AvaloniaCoreRTDemo
{
	public interface IMainWindowState
	{
        IBitmap DotNetImage { get; }
        IBitmap AvaloniaImage { get; }
        String? Text { get; }

        void SetUnloadable();
	}
}

