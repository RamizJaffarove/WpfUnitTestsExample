using System;
using WpfUnitTestsExamble.Services;

namespace WpfUnitTestsExamble.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private bool _returnOne;
        private readonly ISimpleCalculationService _calculationService;
        private double _calculationResult;
        private bool _showError;

        #endregion

        #region Properties

        public bool ReturnOne
        {
            get => _returnOne;
            set
            {
                if (value == _returnOne) return;
                _returnOne = value;
                OnPropertyChanged();

                try
                {
                    CalculationResult = Calculate(_returnOne);
                }
                catch (Exception)
                {
                    ShowError = true;
                }
            }
        }

        public double CalculationResult
        {
            get => _calculationResult;
            set
            {
                if (value.Equals(_calculationResult)) return;
                _calculationResult = value;
                OnPropertyChanged();
            }
        }

        public bool ShowError
        {
            get => _showError;
            set
            {
                if (value == _showError) return;
                _showError = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel(ISimpleCalculationService calculationService)
        {
            if (calculationService == null)
                throw new ArgumentNullException(nameof(calculationService));

            _calculationService = calculationService;
        }

        #endregion

        #region Methods

        private double Calculate(bool returnOne)
        {
            return _calculationService.Calculate(returnOne);
        }

        #endregion
    }
}