using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Runtime.InteropServices;
using Avalonia.Platform;
using MyApp.Platform.X11;

namespace MyApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            var windowingPlatform = AvaloniaLocator.Current.GetService<IWindowingPlatform>();
            var windowingPlatformProxy = new X11WindowingPlatformProxy(windowingPlatform);

            AvaloniaLocator.CurrentMutable.BindToSelf<IWindowingPlatform>(windowingPlatformProxy);
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}