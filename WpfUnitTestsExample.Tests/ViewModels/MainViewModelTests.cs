#region References

using System;
using System.Collections.Generic;
using System.Windows;
using Moq;
using NUnit.Framework;
using Unity;
using WpfUnitTestsExamble.Common.MessageBoxWrapper;
using WpfUnitTestsExample.Services;
using WpfUnitTestsExample.ViewModels;

#endregion

namespace WpfUnitTestsExample.Tests.ViewModels
{
    [TestFixture]
    public class MainViewModelTests
    {
        #region Fields

        private IMainWindowViewModel _viewModel;
        private Mock<ISquareCalculationService> _mockCalculationService;
        private Mock<IMessageBoxService> _mockMessageBoxService;
        private UnityContainer _diContainer;

        #endregion

        #region SetUp

        [SetUp]
        public void Setup()
        {
            _mockCalculationService = new Mock<ISquareCalculationService>();
            _mockMessageBoxService = new Mock<IMessageBoxService>();

            //_viewModel = new MainWindowViewModel(_mockCalculationService.Object, _mockMessageBoxService.Object);

            _diContainer = new UnityContainer();
            _diContainer.RegisterInstance(_mockCalculationService.Object);
            _diContainer.RegisterInstance(_mockMessageBoxService.Object);
            _diContainer.RegisterType<IMainWindowViewModel, MainWindowViewModel>();

            _viewModel = _diContainer.Resolve<IMainWindowViewModel>();
        }

        #endregion


        #region Tests

        [TestCaseSource(nameof(NullArgumentInConstructorSource))]
        public void NullArgumentInConstructorTest(ISquareCalculationService calculationService, IMessageBoxService messageBoxService)
        {
            //Check that contructor throws an exception if some of passed services is null
            Assert.Throws<ArgumentNullException>(() =>
            {
                var _ = new MainWindowViewModel(calculationService, messageBoxService);
            });
        }

        [TestCase(1, 1)]
        [TestCase(2, 4)]
        [TestCase(3, 9)]    //To pass this test uncomment mock setup in the code of test
        public void CalculateCommandTest(double number, double expectedResult)
        {
            //Arrange
            _mockCalculationService
                .Setup(x => x.Calculate(1))
                .Returns(1);

            _mockCalculationService
                .Setup(x => x.Calculate(2))
                .Returns(4);

            //_mockCalculationService
            //    .Setup(x => x.Calculate(3))
            //    .Returns(9);

            //Act
            _viewModel.Number = number;
            _viewModel.CalculateCommand.Execute();
            var actualResult = _viewModel.Result;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

            //Check that the method 'ISquareCalculationService.Calculate' was called one time from ViewModel after performing 'CalculateCommand'
            _mockCalculationService.Verify(x => x.Calculate(number), Times.Once);
        }

        [Test]
        public void CalculateCommandForAnyNumberTest()
        {
            //Arrange
            double expectedResult = 123;
            _mockCalculationService
                .Setup(x => x.Calculate(It.IsAny<double>()))
                .Returns(expectedResult);

            //Act
            _viewModel.CalculateCommand.Execute();

            //Assert

            //Check that the method 'ISquareCalculationService.Calculate' was called with some double number
            _mockCalculationService.Verify(x => x.Calculate(It.IsAny<double>()));

            //Check that the Result property was changed with expected value
            Assert.AreEqual(expectedResult, _viewModel.Result);
        }


        [Test]
        public void MessageBoxIfOutOfRangeTest()
        {
            //Arrange
            _mockCalculationService
                .Setup(x => x.Calculate(It.IsAny<double>()))
                .Throws<ArgumentOutOfRangeException>();

            //Act
            _viewModel.CalculateCommand.Execute();

            //Assert

            //Verify that the message box was called when calculation service throw an exception. Check that message box has expected parameters and called only one time
            _mockMessageBoxService.Verify(x => x.Show(
                    It.Is<string>(msg => msg.StartsWith("The number is out of range ")),
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error),
                Times.Once);
        }

        #endregion


        #region Test case sources

        public static IEnumerable<object[]> NullArgumentInConstructorSource()
        {
            var mockCalculationService = new Mock<ISquareCalculationService>();
            var mockMessageBoxService = new Mock<IMessageBoxService>();

            yield return new object[] { null, mockMessageBoxService.Object };
            yield return new object[] { mockCalculationService.Object, null };
        }

        #endregion
    }

    public class MockSquareCalculationServiceReturnNumber : ISquareCalculationService
    {
        public double Calculate(double x)
        {
            return 123;
        }
    }

    public class MockSquareCalculationServiceThrowsException : ISquareCalculationService
    {
        public double Calculate(double x)
        {
            throw new ArgumentOutOfRangeException(nameof(x));
        }
    }
}