using WpfUnitTestsExamble.Common;

namespace WpfUnitTestsExample.ViewModels
{
    public interface IMainWindowViewModel
    {
        double Number { get; set; }

        double Result { get; set; }

        DelegateCommand CalculateCommand { get; }
    }
}