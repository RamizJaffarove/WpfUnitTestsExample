#region References

using System.Windows;
using Unity;
using WpfUnitTestsExamble.Common.MessageBoxWrapper;
using WpfUnitTestsExample.Services;
using WpfUnitTestsExample.ViewModels;

#endregion

namespace WpfUnitTestsExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static UnityContainer Container { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new UnityContainer();

            Container.RegisterType<ISquareCalculationService, SquareCalculationService>();
            Container.RegisterType<IMessageBoxService, MessageBoxService>();
            Container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
        }
    }
}
