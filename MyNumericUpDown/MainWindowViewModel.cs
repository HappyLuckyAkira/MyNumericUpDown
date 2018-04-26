using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace MyNumericUpDown
{

    class MainWindowViewModel: BindableBase
    {
        private int input1;
        private int input2;
        bool hasViewError;
        public bool HasViewError
        {
            get { return hasViewError; }
            set
            {
                SetProperty(ref hasViewError, value);
                SampleCommand.RaiseCanExecuteChanged();
            }
        }

        public MainWindowViewModel()
        {
            this.SampleCommand = new DelegateCommand(
                // Execute
                () =>
                {
                },
                // CanExecute
                () =>
                {
                    return !HasViewError;
                });
        }
        public DelegateCommand SampleCommand { get; private set; }

        public int Input1
        {
            get
            {
                return this.input1;
            }

            set
            {
                SetProperty(ref input1, value);
            }
        }

        public int Input2
        {
            get
            {
                return this.input2;
            }

            set
            {
                SetProperty(ref input2, value);
            }
        }
    }
}
