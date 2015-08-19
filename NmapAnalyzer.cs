using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Verda
{
    class NmapAnalyzer
    {
        private int currentPort;
        private string currentip;
        public int resultCounter = 0;
        private string stats;
        private bool parseContinue;
        private string prefix;
        public string mode;

        public void Parse(string _toParse)
        {
            string res = "";

            if (mode == "http-title") { res = httptitleParse(_toParse); }
            else
                if (mode == "Webcam" | mode == "Webcam-fast") { res = titleWebCamParse(_toParse); }
                else
                    if (mode == "Webcam-advanced") { res = titleWebCamParseAdvanced(_toParse); }
                    else
                        if (mode == "custom") { res = "Custom preset, NMAP output only."; }
                        else res = "WTF?";

            if (res != null) Program.VerdaPost(res);
        }

        private string httptitleParse(string toParse)
        {
            if (toParse.Contains("Nmap scan report for"))
            {
                currentip = toParse.Remove(0, 21);
            }

            if (toParse.Contains("/tcp open") | toParse.Contains("/tcp  open") | toParse.Contains("/tcp   open"))
            {
                currentPort = Convert.ToInt32(toParse.Remove(toParse.IndexOf("/")));
                if (currentPort == 443) { prefix = "https://"; }
                else prefix = "http://";
            }

            if (toParse.Contains("Stats: "))
            {
                stats = toParse;
            }

            if (toParse.Contains("Timing: "))
            {
                stats += "\r\n" + toParse;
                Program.StatsPost(stats);
            }

            if (toParse.Contains("|_http-title:"))
            {
                resultCounter++;
                return "[HTTP] " + prefix + currentip + ":" + currentPort + " " + toParse.Remove(0, 14);
            }
            else

                if (toParse.Contains("| http-title:")) //|_Requested resource was 
                {
                    resultCounter++;
                    return "[HTTP] " + prefix + currentip + ":" + currentPort + " " + toParse.Remove(0, 14);
                }
                else
                    if (toParse.Contains("|_Requested resource was "))
                    {
                        return toParse.Remove(0, 2);
                    }
                    else
                        return null;
        }

        private string titleWebCamParse(string toParse)
        {


            if (toParse.Contains("Nmap scan report for"))
            {
                currentip = toParse.Remove(0, 21);
                parseContinue = false;
                if (currentip.Contains("(")) { currentip = currentip.Remove((currentip.IndexOf("(") - 1), currentip.Length - currentip.IndexOf("(") + 1); }
            }

            if (toParse.Contains("/tcp open") | toParse.Contains("/tcp  open") | toParse.Contains("/tcp   open"))
            {
                currentPort = Convert.ToInt32(toParse.Remove(toParse.IndexOf("/")));
                if (currentPort == 443) { prefix = "https://"; }
                else prefix = "http://";
            }

            if (toParse.Contains("Stats: "))
            {
                stats = toParse;
            }

            if (toParse.Contains("Timing: "))
            {
                stats += "\r\n" + toParse;
                Program.StatsPost(stats);
            }

            if (toParse.Contains("http-title: NetSurveillance WEB") | toParse.Contains("http-title: NETSurveillance WEB"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NetSurveillance WEB[ActiveX]";
            }

            if (toParse.Contains("http-title: Intelligent Digital Security System"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Intelligent Digital Security System";
            }

            if (toParse.Contains("http-title: DVR Remote Management System"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - DVR Remote Management[ActiveX]";
            }

            if (toParse.Contains("http-title: Live view / - AXIS")) //Network Camera VB-C60
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - AXIS Network Camera";
            }

            if (toParse.Contains("http-title: AXIS 2120 Network Camera"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - AXIS 2120 Network Camera";
            }

            if (toParse.Contains("http-title: Network Camera VB-"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Canon Network Camera";
            }

            if (toParse.Contains("http-title: Sony Network Camera")) //было предназначено для Sony Network Camera SNC-RZ30
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + "/image" + " - Sony Network Camera";
            }

            if (toParse.Contains("http-title: Network Camera Server"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + "/-wvhttp-01-/getoneshot" + " - Canon Network Camera Server";
            }

            if (toParse.Contains("http-title: SNC-RZ30"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + "/image" + " - Sony SNC-RZ30 Camera";
            }

            if (toParse.Contains("http-title: DVR Components Download")) //admin:123456
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Chipspoint Electronics Camera [Plugin]";
            }

            if (toParse.Contains("http-title: DVR WebViewer"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - DVR WebViewer [ActiveX]";
            }

            if (toParse.Contains("http-title: Web Client for EDVS/EDVR"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - EDVR WebClient [ActiveX]";
            }

            if (toParse.Contains("http-title: Web Viewer for Samsung DVR")) //admin:4321
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Samsung DVR [Plugin]";
            }

            if (toParse.Contains("http-title:  WebViewer"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - WebViewer[?]";
            }

            if (toParse.Contains("http-title: WebCam"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + "/webcamera.html" + " - SuperDVR[ActiveX]";
            }

            if (toParse.Contains("http-title: ::: Login :::")) //admin:admin
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - AVTECH Cam";
            }

            if (toParse.Contains("http-title: NetDvrV2"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NetDvrV2[Plugin]";
            }

            if (toParse.Contains("http-title: NetDvrV3"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NetDvrV3[Plugin]";
            }

            if (toParse.Contains("http-title: NETSuveillance WEB")) //admin:
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NETSuveillance WEB[Plugin]";
            }

            if (toParse.Contains("http-title: Web Viewer"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Web Viewer[ActiveX]";
            }

            if (toParse.Contains("http-title: hd client"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - hd client[?][ActiveX]";
            }

            if (toParse.Contains("http-title: DVR remote management sytem"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - DVR rms";
            }

            if (toParse.Contains("http-title: DVR"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - I suppose it was DVR";
            }

            if (toParse.Contains("http-title: XWebPlay"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - XWebPlay[ActiveX]";
            }

            if (toParse.Contains("http-title: Network Surveillance"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Network Surveillance[ActiveX]";
            }

            if (toParse.Contains("http-title: Net Viewer"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Net Viewer[ActiveX]";
            }

            if (toParse.Contains("http-title: LvrWeb"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - LvrWeb[ActiveX]";
            }

            if (toParse.Contains("http-title:  DVR Web "))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - DVR Web";
            }

            if (toParse.Contains("http-title: Network Video Recorder Login"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NUUO Network Video Recorder";
            }

            if (toParse.Contains("http-title: NUUO Web Remote Client"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - NUUO Web Remote Client";
            }

            if (toParse.Contains("http-title: Web Client"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Feedback dev about wtf is this page plz[?]";
            }

            if (toParse.Contains("http-title: IVSWeb 2.0 - Welcome"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - IVSWeb[Plugin]";
            }

            if (toParse.Contains("http-title: WebViewer"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " - WebViewer[?]";
            }

            if (toParse.Contains("http-title: GeoVision Inc. - IP Camera"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " -  GeoVision IP Camera";
            }

            if (toParse.Contains("http-title: Access Remote DVR PCBased"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " -  Access Remote DVR PCBased";
            }

            if (toParse.Contains("http-title: Surveillance System"))
            {
                resultCounter++;
                return "[IPcam] " + prefix + currentip + ":" + currentPort + " -  Surveillance System[Flash]";
            }

            ///---------------------------------

            if (toParse.Contains("http-title: Site doesn't have a title") | toParse.Contains("http-title: Index page") | toParse.Contains("http-title: Login")
              | toParse.Contains("http-title: Video"))
            {
                string np = webcamNitpicker(currentip, currentPort);
                return np;
            }
            //
            if (toParse.Contains("http-title: Server"))
            {
                return currentip + " - it may be worth a try with Advanced Nitpick";
            }

            if (toParse.Contains("http-title: index") | toParse.Contains("http-title: WebVideo")) //if для подтверждения дальнейшего парсинга Requested resource
            {
                parseContinue = true;
                return null;
            }

            if (toParse.Contains("Requested resource was ") && parseContinue == true)
            {
                if (toParse.Contains("/index.asp")) //admin:12345
                {
                    resultCounter++;

                    string toCheck = currentip;


                    Program._cameraLogin.AddToCheckQueue(toCheck, "hikvision");


                    return "[IPcam] " + prefix + currentip + ":" + currentPort + " - Hikvision - like";
                }
                if (toParse.Contains("/default.html"))
                {
                    resultCounter++;
                    return "[IPcam] " + prefix + currentip + ":" + currentPort + " - WebVideo[Plugin]";
                }
                else return null;
            }
            return null; //сдаёмся
        }

        private string titleWebCamParseAdvanced(string toParse)
        {
            currentPort = -1;
            if (toParse.Contains("Nmap scan report for"))
            {
                currentip = toParse.Remove(0, 21);
                if (currentip.Contains("(")) { currentip = currentip.Remove((currentip.IndexOf("(") - 1), currentip.Length - currentip.IndexOf("(") + 1); }
            }

            if (toParse.Contains("/tcp open") | toParse.Contains("/tcp  open") | toParse.Contains("/tcp   open"))
            {
                currentPort = Convert.ToInt32(toParse.Remove(toParse.IndexOf("/")));
            }

            if (toParse.Contains("Stats: "))
            {
                stats = toParse;
            }

            if (toParse.Contains("Timing: "))
            {
                stats += "\r\n" + toParse;
                Program.StatsPost(stats);
            }

            if (currentPort != -1)
            {
                string np = webcamNitpicker(currentip, currentPort);
                currentPort = -1;
                return np;
            }
            return null;
        }


        private string webcamNitpicker(string ip, int port)
        {

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/no/way/youcanhave.thispage"); //ловушка для редиректа на двухсотую
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            //webRequest.ServicePoint.MaxIdleTime = 5000;
            //webRequest.ServicePoint.ConnectionLeaseTimeout = 5000;
            //ServicePointManager.MaxServicePointIdleTime = 3000;

            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    return null;
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/ChangePwd.htm");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/" + " - Probably undef_webcam type4";
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/live.html");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;

            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/live.html" + " - Maybe it's Techno Vision Security System blyat type R-1?";
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/view/index.shtml");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/view/index.shtml" + " OR " + "http://" + ip + ":" + port + "/mjpg/video.mjpg" + " - AXIS Video type1";
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/view/indexFrame.shtml");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/view/indexFrame.shtml" + " - Maybe it's AXIS Video type2?";
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/anony/mjpg.cgi");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/anony/mjpg.cgi" + " - Maybe it's undef_webcam type3?"; //на фейках срабатывает anyrandom.cgi, проверить на работающих экземплярах
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/images/zoom-in.jpg");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/" + " - Maybe it's undef_webcam[plugin] type5?";
                }
            }
            catch (System.Net.WebException) { };

            webRequest = (HttpWebRequest)WebRequest.Create("http://" + ip + ":" + port + "/image/time_setting.gif");
            webRequest.AllowAutoRedirect = false;
            webRequest.Timeout = 3000;
            webRequest.ReadWriteTimeout = 3000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode.ToString() == "OK")
                {
                    resultCounter++;
                    return "[IPcam][N!] " + "http://" + ip + ":" + port + "/" + " - Maybe it's undef_webcam[plugin] type6?";
                }
            }
            catch (System.Net.WebException) { };

            return null;

        }
    }
}
