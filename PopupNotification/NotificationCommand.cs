using Rrs.Tasks;
using System.Windows;

namespace PopupNotification;
internal class NotificationCommand : CommandBase
{
    public override void Execute(object? parameter)
    {
        if (parameter is not string message) return;
        if (string.IsNullOrWhiteSpace(message)) return;
        var w = new NotificationWindow();
        w.Message.Text = message;
        w.Show();
        Schedule.In(() => Application.Current.Dispatcher.BeginInvoke(w.Close), TimeSpan.FromSeconds(AppSettings.NotificationDuration));
    }
}
