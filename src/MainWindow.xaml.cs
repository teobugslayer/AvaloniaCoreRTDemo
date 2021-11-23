
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaCoreRTDemo
{
    public class MainWindow : Window
    {
        public ThemeHelper ThemeHelper { get; private init; }

        public MenuItem DefaultLight { get; private set; }
        public MenuItem DefaultDark { get; private set; }
        public MenuItem FluentLight { get; private set; }
        public MenuItem FluentDark { get; private set; }

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainWindow(ThemeHelper themeHelper)
        {
            this.InitializeComponent();
            this.ThemeHelper = themeHelper;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new MainWindowViewModel(this);
            this.DefaultLight = this.Get<MenuItem>("menuDLight");
            this.DefaultDark = this.Get<MenuItem>("menuDDark");
            this.FluentLight = this.Get<MenuItem>("menuFLight");
            this.FluentDark = this.Get<MenuItem>("menuFDark");
#if !FLUENT
            this.FluentLight.IsEnabled = false;
            this.FluentDark.IsEnabled = false;
#endif
        }
    }
}