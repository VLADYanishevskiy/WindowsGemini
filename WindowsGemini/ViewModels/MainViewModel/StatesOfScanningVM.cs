using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private void _state_select_folder()
        {
            this.StateOfScanning = 0;
        }
        private void _state_scanning_comparing_files()
        {
            this.StateOfScanning = 1;
        }
        private void _state_scanning_finished()
        {
            this.StateOfScanning = 2;
        }
    }
}
