using System.Windows;

namespace WpfUnitTestsExamble.Common.MessageBoxWrapper
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
    }
}
