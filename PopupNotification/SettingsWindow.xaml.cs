using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PopupNotification;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        LoadMonitors();
        MonitorSelector.SelectionChanged += MonitorSelector_SelectionChanged;

        FontSizeSlider.Value = AppSettings.FontSize;
        FontSizeSlider.ValueChanged += FontSizeSlider_ValueChanged;

        DurationSlider.Value = AppSettings.NotificationDuration;
        DurationSlider.ValueChanged += DurationSlider_ValueChanged;
    }

    private void DurationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        AppSettings.NotificationDuration = (int)e.NewValue;
    }

    private void FontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        AppSettings.FontSize = e.NewValue;
    }

    private void LoadMonitors()
    {
        MonitorSelector.ItemsSource = Screen.AllScreens;
        MonitorSelector.SelectedItem = AppSettings.SelectedScreen ?? Screen.AllScreens.FirstOrDefault();
    }

    private void MonitorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MonitorSelector.SelectedItem is Screen selectedScreen)
        {
            AppSettings.SelectedScreen = selectedScreen;
        }
    }
}
