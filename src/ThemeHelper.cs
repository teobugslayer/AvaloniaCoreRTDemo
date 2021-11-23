using System;

namespace AvaloniaCoreRTDemo
{
    public sealed record ThemeHelper
    {
        public Action<ApplicationTheme> ChangeTheme { get; init; }
        public Func<ApplicationTheme> CurrentTheme { get; init; }
    }
}
