#region References

using System;
using System.Windows;
using Unity;
using WpfUnitTestsExamble.Common;
using WpfUnitTestsExamble.Common.MessageBoxWrapper;
using WpfUnitTestsExample.Services;

#endregion

namespace WpfUnitTestsExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Fields

        private readonly ISquareCalculationService _calculationService;
        private readonly IMessageBoxService _messageBoxService;
        private double _number;
        private double _result;

        #endregion

        #region Properties

        public double Number
        {
            get => _number;
            set
            {
                if (_number.Equals(value)) return;
                _number = value;
                OnPropertyChanged();
            }
        }

        public double Result
        {
            get => _result;
            set
            {
                if (value.Equals(_result)) return;
                _result = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand CalculateCommand { get; }

        #endregion

        #region Constructor

        public MainWindowViewModel(ISquareCalculationService calculationService, IMessageBoxService messageBoxService)
        {
            if (calculationService == null)
                throw new ArgumentNullException(nameof(calculationService));

            if (messageBoxService == null)
                throw new ArgumentNullException(nameof(messageBoxService));

            _calculationService = calculationService;
            _messageBoxService = messageBoxService;

            CalculateCommand = new DelegateCommand(Calculate);
        }

        #endregion

        #region Methods

        private void Calculate(object commandParameter)
        {
            try
            {
                Result = _calculationService.Calculate(Number);
            }
            catch (ArgumentOutOfRangeException)
            {
                _messageBoxService.Show("The number is out of range [0 .. 10]", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}