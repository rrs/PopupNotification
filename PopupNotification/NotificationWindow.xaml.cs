using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace PopupNotification;

public partial class NotificationWindow : Window
{
    public NotificationWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        Win32.HideWindowFromCapture(this);

        var hwnd = new WindowInteropHelper(this).Handle;

        var margins = new Win32.MARGINS { cxLeftWidth = -1 };
        Win32.DwmExtendFrameIntoClientArea(hwnd, ref margins);
        
        var hwndSource = HwndSource.FromHwnd(hwnd);
        hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
        Background = System.Windows.Media.Brushes.Transparent;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var screen = AppSettings.SelectedScreen ?? System.Windows.Forms.Screen.PrimaryScreen;
        if (screen == null) return;
        Left = screen.WorkingArea.Left;
        Top = screen.WorkingArea.Top;
        WindowState = WindowState.Maximized;
    }
}
