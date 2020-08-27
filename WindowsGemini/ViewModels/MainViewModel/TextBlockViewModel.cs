using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public string txbMainPageHello
        {
            get
            {
                return FoldersToScan.Count == 0 ? resourceLoader.GetString("txbMainPageHelloRes") : "";
            }
            private set { }
        }
        public string txbMainPageWelcomeTo
        {
            get
            {
                return FoldersToScan.Count == 0 ? resourceLoader.GetString("txbMainPageWelcomeToRes") : 
                    resourceLoader.GetString("txbReadyToScanRes");
            }
            private set { }
        }
        public string txbMainPageSomeNameApp
        {
            get
            {
                return FoldersToScan.Count == 0 ? "WindowsGemini!" : "";
            }
            private set { }
        }
        public string txbMainPageHintPlusOrPressButoonTop
        {
            get
            {
                return FoldersToScan.Count == 0 ? resourceLoader.GetString("txbPressPlusToAddRes") :
                    resourceLoader.GetString("txbJustPushButtonBellowRes");
            }
        }
        public string txbMainPageHintPlusOrPressButoonBottom
        {
            get
            {
                return FoldersToScan.Count == 0 ? resourceLoader.GetString("txbOrJustDDtoStartRes") :
                    resourceLoader.GetString("txbAllOfyDuplicatesRes");
            }
        }
    }
}
