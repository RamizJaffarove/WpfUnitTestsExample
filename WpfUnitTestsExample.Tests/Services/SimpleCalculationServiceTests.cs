#region References

using System;
using System.Collections.Generic;
using NUnit.Framework;
using WpfUnitTestsExample.Services;

#endregion

namespace WpfUnitTestsExample.Tests.Services
{
    [TestFixture]
    public class SimpleCalculationServiceTests
    {
        #region Fields

        private ISquareCalculationService _squareCalculationService;

        #endregion

        #region SetUp

        [SetUp]
        public void Setup()
        {
            _squareCalculationService = new SquareCalculationService();
        }

        #endregion

        #region TearDown

        [TearDown]
        public void TearDown()
        { }

        #endregion


        #region Tests

        [Test]
        public void SquareOf2Is4Test()
        {
            //Arrange
            double number = 2;
            double expectedResult = 4;

            //Act
            double actualResult = _squareCalculationService.Calculate(number);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 4)]
        [TestCase(3, 9)]
        public void BunchOfDataExampleTest(double number, double expectedResult)
        {
            //Arrange 

            //Act
            double actualResult = _squareCalculationService.Calculate(number);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCaseSource(nameof(DataSource))]
        public void BigBunchOfInputTest(double number, double expectedResult)
        {
            //Arrange 

            //Act
            double actualResult = _squareCalculationService.Calculate(number);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCase(-1)]
        [TestCase(11)]
        public void ArgumentOutOfRangeTest(double number)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _squareCalculationService.Calculate(number));
        }

        #endregion


        #region TestCaseSources

        public static IEnumerable<object[]> DataSource()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 4 };
            yield return new object[] { 3, 9 };
            yield return new object[] { 4, 16 };
            yield return new object[] { 5, 25 };
            yield return new object[] { 6, 36 };
            yield return new object[] { 10, 100  };
        }

        #endregion
    }
}
