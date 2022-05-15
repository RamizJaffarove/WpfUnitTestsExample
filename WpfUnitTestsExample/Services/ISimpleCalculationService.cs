using System.IO;

namespace WpfUnitTestsExamble.Services
{
    public interface ISimpleCalculationService
    {
        double Calculate(bool returnOne, bool throwException = false);
    }
}
