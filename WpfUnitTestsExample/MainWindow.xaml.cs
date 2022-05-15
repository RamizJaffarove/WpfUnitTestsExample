using WpfUnitTestsExamble.Services;
using WpfUnitTestsExamble.ViewModels;

namespace WpfUnitTestsExamble
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainWindowViewModel(new SimpleCalculationService());
        }
    }
}
