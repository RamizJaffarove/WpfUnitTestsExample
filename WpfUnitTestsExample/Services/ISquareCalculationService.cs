using System;

namespace WpfUnitTestsExample.Services
{
    /// <summary>
    /// Calculate square of number
    /// </summary>
    public interface ISquareCalculationService
    {
        /// <summary>
        /// The method calculates square of number 
        /// </summary>
        /// <param name="x">The number</param>
        /// <returns>Square of number</returns>
        /// <exception cref="ArgumentOutOfRangeException">If number is out of range [0 .. 10]</exception>
        double Calculate(double x);
    }
}
