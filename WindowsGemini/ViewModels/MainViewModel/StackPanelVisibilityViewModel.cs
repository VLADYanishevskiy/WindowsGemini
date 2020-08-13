using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private int _stateOfScanning;
        public int StateOfScanning
        {
            get
            {
                return _stateOfScanning;
            }
            set
            {
                _stateOfScanning = value;
                NotifyPropertyChanged(nameof(StateOfScanning));
            }
        }
    }
}
