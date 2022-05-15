using System;

namespace WpfUnitTestsExamble.Services
{
    public class SimpleCalculationService : ISimpleCalculationService
    {
        public double Calculate(bool returnOne, bool throwException = false)
        {
            if (throwException)
                throw new ArgumentException(nameof(throwException));

            return returnOne ? 1 : 0;
        }
    }
}