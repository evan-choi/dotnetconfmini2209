using Avalonia.Platform;

namespace MyApp.Platform.X11;

public sealed class X11WindowingPlatformProxy : IWindowingPlatform
{
    private readonly IWindowingPlatform _windowingPlatform;

    public X11WindowingPlatformProxy(IWindowingPlatform windowingPlatform)
    {
        _windowingPlatform = windowingPlatform;
    }

    public IWindowImpl CreateWindow()
    {
        var originalWindowImpl = _windowingPlatform.CreateWindow();
        return new X11WindowImplProxy(originalWindowImpl);
    }

    public IWindowImpl CreateEmbeddableWindow()
    {
        return _windowingPlatform.CreateEmbeddableWindow();
    }

    public ITrayIconImpl CreateTrayIcon()
    {
        return _windowingPlatform.CreateTrayIcon();
    }
}