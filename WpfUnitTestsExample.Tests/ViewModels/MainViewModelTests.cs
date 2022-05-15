using System;
using Moq;
using NUnit.Framework;
using WpfUnitTestsExamble.Services;
using WpfUnitTestsExamble.ViewModels;

namespace WpfUnitTestsExamble.Tests.ViewModels
{
    [TestFixture]
    public class MainViewModelTests
    {
        private MainWindowViewModel _viewModel;
        private Mock<ISimpleCalculationService> _mockCalculationService;

        [SetUp]
        public void Setup()
        {
            _mockCalculationService = new Mock<ISimpleCalculationService>();
            _viewModel = new MainWindowViewModel(_mockCalculationService.Object);
        }

        [Test]
        public void NullArgumentConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var _ = new MainWindowViewModel(null);
            });
        }

        [Test]
        public void ReturnOneChangedTest()
        {
            //Arrange
            double expectedResult = 10;
            //_mockCalculationService.Setup(x => x.Calculate(true, false)).Returns(1);
            //_mockCalculationService.Setup(x => x.Calculate(false, false)).Returns(0);
            _mockCalculationService.Setup(x => x.Calculate(It.IsAny<bool>(), It.IsAny<bool>())).Returns(expectedResult);

            //Act
            _viewModel.ReturnOne = true;

            //Assert
            Assert.AreEqual(expectedResult, _viewModel.CalculationResult);
            _mockCalculationService.Verify(x => x.Calculate(It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
        }


        [Test]
        public void CalculationErrorTest()
        {
            //Arrange
            _mockCalculationService.Setup(x => x.Calculate(It.IsAny<bool>(), It.IsAny<bool>())).Throws<ArgumentException>();

            //Act
            _viewModel.ReturnOne = true;

            //Assert
            _mockCalculationService.Verify(x => x.Calculate(It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
            Assert.IsTrue(_viewModel.ShowError);
        }
    }
}