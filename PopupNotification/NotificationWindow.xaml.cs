using System.Windows;
using System.Windows.Forms;

namespace PopupNotification;
/// <summary>
/// Interaction logic for NotificationWindow.xaml
/// </summary>
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
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var screen = AppSettings.SelectedScreen ?? Screen.PrimaryScreen;
        if (screen == null) return;
        Left = screen.WorkingArea.Left;
        Top = screen.WorkingArea.Top;
        WindowState = WindowState.Maximized;
    }
}
