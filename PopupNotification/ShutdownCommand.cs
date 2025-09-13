using System.Windows;

namespace PopupNotification;
internal class ShutdownCommand : CommandBase
{
    public override void Execute(object? _)
    {
        Application.Current.Shutdown();
    }
}
