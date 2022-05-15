#region References

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using WpfUnitTestsExamble.Services;

#endregion

namespace WpfUnitTestsExamble.Tests.Services
{
    [TestFixture]
    public class SimpleCalculationServiceTests
    {
        #region Fields

        private ISimpleCalculationService _simpleCalculationService;

        #endregion

        
        #region SetUp

        [SetUp]
        public void Setup()
        {
            _simpleCalculationService = new SimpleCalculationService();
        }

        #endregion

        #region TearDown

        [TearDown]
        public void TearDown()
        {

        }

        #endregion


        #region Tests

        [Test]
        public void ResultIsOneTest()
        {
            //Arrange
            bool returnOne = true;
            double expectedResult = 1;

            //Act
            double actualResult = _simpleCalculationService.Calculate(returnOne);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ResultIsZeroTest()
        {
            //Arrange
            bool returnOne = false;
            double expectedResult = 0;

            //Act
            double result = _simpleCalculationService.Calculate(returnOne);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        
        [Test]
        public void BadArgumentTest()
        {
            //Arrange
            bool returnOne = true;
            bool badArgument = true;

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => _simpleCalculationService.Calculate(returnOne, badArgument));
        }



        [TestCase(true, 1)]
        [TestCase(false, 0)]
        public void BunchOfDataExampleTest(bool returnOne, double expectedResult)
        {
            //Arrange 

            //Act
            double actualResult = _simpleCalculationService.Calculate(returnOne);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCaseSource(nameof(DataSource))]
        public void BigBunchOfDataExampleTest(bool returnOne, double expectedResult)
        {
            //Arrange 

            //Act
            double actualResult = _simpleCalculationService.Calculate(returnOne);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion


        #region TestCaseSources

        public static IEnumerable<object[]> DataSource()
        {
            yield return new object[] { true, 1 };
            yield return new object[] { false, 0 };
            //...
        }

        #endregion
    }
}
