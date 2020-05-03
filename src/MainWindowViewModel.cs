using Avalonia;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.Reactive;
using Path = System.IO.Path;

namespace AvaloniaCoreRTDemo
{
    public class MainWindowViewModel: ReactiveObject
    {
        public MainWindowViewModel(MainWindow window)
        {
            _window = window;
			
            DotNetImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnet.png"));
            AvaloniaImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avalonia.png"));

            FileExitCommand = ReactiveCommand.Create(RunFileExit);
        }
        
        public IBitmap DotNetImage
        {
            get { return dotNetImage; }
            set { this.RaiseAndSetIfChanged(ref this.dotNetImage, value); }
        }

        public IBitmap AvaloniaImage
        {
            get { return avaloniaImage; }
            set { this.RaiseAndSetIfChanged(ref this.avaloniaImage, value); }
        }

        public ReactiveCommand<Unit, Unit> FileExitCommand { get; }
        public void HelpAboutMethod() => RunHelpAbout();

        void RunFileExit()
        {
            Environment.Exit(0);
        }

        void RunHelpAbout()
        {
            new AboutWindow().ShowDialog(_window);
        }

        private IBitmap dotNetImage;
        private IBitmap avaloniaImage;
        private readonly MainWindow _window;
    }
}