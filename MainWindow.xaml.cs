using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using Path = System.IO.Path;

namespace AvaloniaCoreRTDemo
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class ViewModel: ReactiveObject
    {
        public ViewModel()
        {
            DotNetImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnet.png"));
            AvaloniaImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avalonia.png"));
        }

        private IBitmap dotNetImage;
        public IBitmap DotNetImage
        {
            get { return dotNetImage; }
            set { this.RaiseAndSetIfChanged(ref this.dotNetImage, value); }
        }

        private IBitmap avaloniaImage;
        public IBitmap AvaloniaImage
        {
            get { return avaloniaImage; }
            set { this.RaiseAndSetIfChanged(ref this.avaloniaImage, value); }
        }
    }
}