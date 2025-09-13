using PopupNotification.Properties;
using System.Windows.Forms;

namespace PopupNotification;

internal static class AppSettings
{
    public static Screen? SelectedScreen
    {
        get
        {
            var deviceName = Settings.Default.SelectedScreenDeviceName;
            if (string.IsNullOrEmpty(deviceName))
            {
                return null;
            }
            return Screen.AllScreens.FirstOrDefault(s => s.DeviceName == deviceName);
        }
        set
        {
            Settings.Default.SelectedScreenDeviceName = value?.DeviceName;
            Settings.Default.Save();
        }
    }

    public static double FontSize
    {
        get => Settings.Default.FontSize;
        set
        {
            Settings.Default.FontSize = value;
            Settings.Default.Save();
        }
    }

    public static int NotificationDuration
    {
        get => Settings.Default.NotificationDuration;
        set
        {
            Settings.Default.NotificationDuration = value;
            Settings.Default.Save();
        }
    }
}
