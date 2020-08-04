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
                return FoldersToScan.Count == 0 ? "Hello!" : "";
            }
            private set { }
        }
        public string txbMainPageWelcomeTo
        {
            get
            {
                return FoldersToScan.Count == 0 ? "Welcome to " : "Ready to Scan!";
            }
            private set { }
        }
        public string txbMainPageSomeNameApp
        {
            get
            {
                return FoldersToScan.Count == 0 ? "SomeNameApp!" : "";
            }
            private set { }
        }
        public string txbMainPageHintPlusOrPressButoonTop
        {
            get
            {
                return FoldersToScan.Count == 0 ? "Please press \"+\"  to add folders" : "Just push the button below to find";
            }
        }
        public string txbMainPageHintPlusOrPressButoonBottom
        {
            get
            {
                return FoldersToScan.Count == 0 ? "or just drag&drop to start scanning." : "all of your duplicates.";
            }
        }
    }
}
