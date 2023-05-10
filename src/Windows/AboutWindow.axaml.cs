using System;

using Avalonia.Controls;

using AvaloniaCoreRTDemo.Windows.ViewModels;

namespace AvaloniaCoreRTDemo.Windows
{
    public sealed partial class AboutWindow : Window
    {
        private readonly Boolean _darkTheme;

        public AboutWindow() : this(false) { }

        public AboutWindow(Boolean darkTheme)
        {
            this._darkTheme = darkTheme;
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Use generated InitializeComponent method.
            this.InitializeComponent(loadXaml: true);
            this.DataContext = new AboutViewModel(this._darkTheme);
        }
    }
}
