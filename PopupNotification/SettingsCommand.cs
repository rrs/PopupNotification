namespace PopupNotification;

public class SettingsCommand : CommandBase
{
    public override void Execute(object? parameter)
    {
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
    }
}
