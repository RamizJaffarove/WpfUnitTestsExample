using System.Windows;

namespace WpfUnitTestsExamble.Common.MessageBoxWrapper
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}