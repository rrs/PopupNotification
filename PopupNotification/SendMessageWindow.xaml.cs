using System;
using System.Windows;

namespace PopupNotification
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window
    {
        public SendMessageWindow()
        {
            InitializeComponent();
            ContentRendered += OnContentRendered;
        }

        private void OnContentRendered(object? sender, EventArgs e)
        {
            Message.Focus();
        }
    }
}
