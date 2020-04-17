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
        public MainWindowViewModel()
        {
            DotNetImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotnet.png"));
            AvaloniaImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avalonia.png"));

            FileExitCommand = ReactiveCommand.Create(RunFileExit);
            HelpAboutCommand = ReactiveCommand.Create(RunHelpAbout);
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
        public ReactiveCommand<Unit, Unit> HelpAboutCommand { get; }

        void RunFileExit()
        {
            Environment.Exit(0);
        }

        void RunHelpAbout()
        {
            // Code for executing the command here.
        }

        private IBitmap dotNetImage;
        private IBitmap avaloniaImage;
    }
}