using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Input;
using Avalonia.Input.Raw;
using Avalonia.Input.TextInput;
using Avalonia.Platform;
using Avalonia.Rendering;

namespace MyApp.Platform.X11;

public sealed class X11WindowImplProxy : IWindowImpl,
    ITopLevelImplWithNativeMenuExporter,
    ITopLevelImplWithNativeControlHost,
    ITopLevelImplWithTextInputMethod
{
    public ITopLevelNativeMenuExporter NativeMenuExporter =>
        ((ITopLevelImplWithNativeMenuExporter) _windowImpl).NativeMenuExporter;

    public INativeControlHostImpl NativeControlHost =>
        ((ITopLevelImplWithNativeControlHost) _windowImpl).NativeControlHost;

    public ITextInputMethodImpl TextInputMethod => ((ITopLevelImplWithTextInputMethod) _windowImpl).TextInputMethod;

    private readonly IWindowImpl _windowImpl;
    private PixelPoint? _position;

    public X11WindowImplProxy(IWindowImpl windowImpl)
    {
        _windowImpl = windowImpl;
    }

    public void Dispose()
    {
        _windowImpl.Dispose();
    }

    public IRenderer CreateRenderer(IRenderRoot root)
    {
        return _windowImpl.CreateRenderer(root);
    }

    public void Invalidate(Rect rect)
    {
        _windowImpl.Invalidate(rect);
    }

    public void SetInputRoot(IInputRoot inputRoot)
    {
        _windowImpl.SetInputRoot(inputRoot);
    }

    public Point PointToClient(PixelPoint point)
    {
        return _windowImpl.PointToClient(point);
    }

    public PixelPoint PointToScreen(Point point)
    {
        return _windowImpl.PointToScreen(point);
    }

    public void SetCursor(ICursorImpl cursor)
    {
        _windowImpl.SetCursor(cursor);
    }

    public IPopupImpl CreatePopup()
    {
        return _windowImpl.CreatePopup();
    }

    public void SetTransparencyLevelHint(WindowTransparencyLevel transparencyLevel)
    {
        _windowImpl.SetTransparencyLevelHint(transparencyLevel);
    }

    public Size ClientSize => _windowImpl.ClientSize;

    public Size? FrameSize => _windowImpl.FrameSize;

    public double RenderScaling => _windowImpl.RenderScaling;

    public IEnumerable<object> Surfaces => _windowImpl.Surfaces;

    public Action<RawInputEventArgs> Input
    {
        get => _windowImpl.Input;
        set => _windowImpl.Input = value;
    }

    public Action<Rect> Paint
    {
        get => _windowImpl.Paint;
        set => _windowImpl.Paint = value;
    }

    public Action<Size, PlatformResizeReason> Resized
    {
        get => _windowImpl.Resized;
        set => _windowImpl.Resized = value;
    }

    public Action<double> ScalingChanged
    {
        get => _windowImpl.ScalingChanged;
        set => _windowImpl.ScalingChanged = value;
    }

    public Action<WindowTransparencyLevel> TransparencyLevelChanged
    {
        get => _windowImpl.TransparencyLevelChanged;
        set => _windowImpl.TransparencyLevelChanged = value;
    }

    public Action Closed
    {
        get => _windowImpl.Closed;
        set => _windowImpl.Closed = value;
    }

    public Action LostFocus
    {
        get => _windowImpl.LostFocus;
        set => _windowImpl.LostFocus = value;
    }

    public IMouseDevice MouseDevice => _windowImpl.MouseDevice;

    public WindowTransparencyLevel TransparencyLevel => _windowImpl.TransparencyLevel;

    public AcrylicPlatformCompensationLevels AcrylicCompensationLevels => _windowImpl.AcrylicCompensationLevels;

    public void Show(bool activate, bool isDialog)
    {
        _windowImpl.Show(activate, isDialog);

        if (!_position.HasValue)
            return;

        _windowImpl.Move(_position.Value);
        _position = null;
    }

    public void Hide()
    {
        _windowImpl.Hide();
    }

    public void Activate()
    {
        _windowImpl.Activate();
    }

    public void SetTopmost(bool value)
    {
        _windowImpl.SetTopmost(value);
    }

    public double DesktopScaling => _windowImpl.DesktopScaling;

    public PixelPoint Position => _windowImpl.Position;

    public Action<PixelPoint> PositionChanged
    {
        get => _windowImpl.PositionChanged;
        set => _windowImpl.PositionChanged = value;
    }

    public Action Deactivated
    {
        get => _windowImpl.Deactivated;
        set => _windowImpl.Deactivated = value;
    }

    public Action Activated
    {
        get => _windowImpl.Activated;
        set => _windowImpl.Activated = value;
    }

    public IPlatformHandle Handle => _windowImpl.Handle;

    public Size MaxAutoSizeHint => _windowImpl.MaxAutoSizeHint;

    public IScreenImpl Screen => _windowImpl.Screen;

    public void SetTitle(string title)
    {
        _windowImpl.SetTitle(title);
    }

    public void SetParent(IWindowImpl parent)
    {
        _windowImpl.SetParent(parent);
    }

    public void SetEnabled(bool enable)
    {
        _windowImpl.SetEnabled(enable);
    }

    public void SetSystemDecorations(SystemDecorations enabled)
    {
        _windowImpl.SetSystemDecorations(enabled);
    }

    public void SetIcon(IWindowIconImpl icon)
    {
        _windowImpl.SetIcon(icon);
    }

    public void ShowTaskbarIcon(bool value)
    {
        _windowImpl.ShowTaskbarIcon(value);
    }

    public void CanResize(bool value)
    {
        _windowImpl.CanResize(value);
    }

    public void BeginMoveDrag(PointerPressedEventArgs e)
    {
        _windowImpl.BeginMoveDrag(e);
    }

    public void BeginResizeDrag(WindowEdge edge, PointerPressedEventArgs e)
    {
        _windowImpl.BeginResizeDrag(edge, e);
    }

    public void Resize(Size clientSize, PlatformResizeReason reason = PlatformResizeReason.Application)
    {
        _windowImpl.Resize(clientSize, reason);
    }

    public void Move(PixelPoint point)
    {
        _windowImpl.Move(point);
        _position = point;
    }

    public void SetMinMaxSize(Size minSize, Size maxSize)
    {
        _windowImpl.SetMinMaxSize(minSize, maxSize);
    }

    public void SetExtendClientAreaToDecorationsHint(bool extendIntoClientAreaHint)
    {
        _windowImpl.SetExtendClientAreaToDecorationsHint(extendIntoClientAreaHint);
    }

    public void SetExtendClientAreaChromeHints(ExtendClientAreaChromeHints hints)
    {
        _windowImpl.SetExtendClientAreaChromeHints(hints);
    }

    public void SetExtendClientAreaTitleBarHeightHint(double titleBarHeight)
    {
        _windowImpl.SetExtendClientAreaTitleBarHeightHint(titleBarHeight);
    }

    public WindowState WindowState
    {
        get => _windowImpl.WindowState;
        set => _windowImpl.WindowState = value;
    }

    public Action<WindowState> WindowStateChanged
    {
        get => _windowImpl.WindowStateChanged;
        set => _windowImpl.WindowStateChanged = value;
    }

    public Action GotInputWhenDisabled
    {
        get => _windowImpl.GotInputWhenDisabled;
        set => _windowImpl.GotInputWhenDisabled = value;
    }

    public Func<bool> Closing
    {
        get => _windowImpl.Closing;
        set => _windowImpl.Closing = value;
    }

    public bool IsClientAreaExtendedToDecorations => _windowImpl.IsClientAreaExtendedToDecorations;

    public Action<bool> ExtendClientAreaToDecorationsChanged
    {
        get => _windowImpl.ExtendClientAreaToDecorationsChanged;
        set => _windowImpl.ExtendClientAreaToDecorationsChanged = value;
    }

    public bool NeedsManagedDecorations => _windowImpl.NeedsManagedDecorations;

    public Thickness ExtendedMargins => _windowImpl.ExtendedMargins;

    public Thickness OffScreenMargin => _windowImpl.OffScreenMargin;
}