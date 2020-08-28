using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.ViewModels
{
    class MVVMLocator
    {
        private static MainViewModel mainVM;
        public static MainViewModel MainViewModel
        {
            get
            {
                if(mainVM == null)
                {
                    mainVM = new MainViewModel();
                }
                return mainVM;
            }
        }
    }
}
