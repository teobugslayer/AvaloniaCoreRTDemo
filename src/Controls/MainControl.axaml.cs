using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using AvaloniaCoreRTDemo.Controls.ViewModels;

namespace AvaloniaCoreRTDemo.Controls
{
    public sealed partial class MainControl : UserControl
    {
        public MainControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainControlViewModel();
        }

        public void Reload(IMainWindowState? model)
        {
            if(model is not null)
                this.DataContext = new MainControlViewModel(model);
        }
    }
}
