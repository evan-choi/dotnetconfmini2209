using Avalonia;
using System;
using Avalonia.Media;

// ReSharper disable All

namespace MyApp
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .With(() => new FontManagerOptions
                {
                    DefaultFamilyName = "Noto Sans KR",
                    FontFallbacks = new[]
                    {
                        new FontFallback
                        {
                            FontFamily = new FontFamily("avares://MyApp/Assets/Fonts#Noto Sans KR")
                        }
                    }
                })
                .LogToTrace();
    }
}