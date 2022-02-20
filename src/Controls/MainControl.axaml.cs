using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Controls.ViewModels;

namespace AvaloniaCoreRTDemo.Controls
{
    public sealed partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainViewModel();
        }
    }
}
