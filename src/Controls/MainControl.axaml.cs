using Avalonia.Controls;

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
            //Use generated InitializeComponent method.
            this.InitializeComponent(loadXaml: true);
            this.DataContext = new MainControlViewModel();
        }

        public void Reload(IMainWindowState model)
        {
            this.DataContext = new MainControlViewModel(model);
        }
    }
}
