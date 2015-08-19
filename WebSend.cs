using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace Verda
{
    public partial class WebSend
    {
        static string report;
        static void sendReport()
        {
            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create("http://verda.zz.mu/reports/uploadreport.php?string=" + report);
                wrGETURL.GetResponse();
            }
            catch (Exception) { }
        }

        public void toSend(string _report)
        {
            if (Program.Window.chosenPreset == "Webcam" |
                Program.Window.chosenPreset == "Webcam-fast" |
                Program.Window.chosenPreset == "Webcam-advanced")
            {
                report = _report;
                Thread sender = new Thread(sendReport);
                sender.Start();
            }
        }

    }
}
