namespace PopupNotification;
internal class ShowSendMessageWindowCommand : CommandBase
{
    public override void Execute(object? _)
    {
        var w = new SendMessageWindow();
        w.Show();
    }
}
