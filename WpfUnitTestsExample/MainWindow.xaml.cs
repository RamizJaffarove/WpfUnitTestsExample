using Unity;
using Unity.Resolution;
using WpfUnitTestsExample.ViewModels;

namespace WpfUnitTestsExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = App.Container.Resolve<IMainWindowViewModel>();
        }
    }
}
