using System;

namespace WpfUnitTestsExample.Services
{
    /// <inheritdoc />
    public class SquareCalculationService : ISquareCalculationService
    {
        /// <inheritdoc />
        public double Calculate(double x)
        {
            if (x < 0 || x > 10)
                throw new ArgumentOutOfRangeException(nameof(x));

            return x * x;
        }
    }
}