using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Input;

namespace PopupNotification;

/// <summary>
/// Closes the current window.
/// </summary>
public class CloseWindowCommand : CommandBase
{
    public override void Execute(object? parameter)
    {
        if (parameter is TaskbarIcon taskbarIcon)
        {
            taskbarIcon.CloseTrayPopup();
            GetTaskbarWindow(taskbarIcon)?.Close();
            CommandManager.InvalidateRequerySuggested();
        }
    }


    public override bool CanExecute(object? parameter)
    {
        var win = GetTaskbarWindow(parameter);
        return win != null;
    }
}