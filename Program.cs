using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Verda
{
    static class Program
    {
        public static MainForm Window;
        public static CameraLogin _cameraLogin;
        private static WebSend _websend;
        public static int CamTargets;
        private static Thread ThA;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Window = new MainForm();

            ThA = new Thread(() =>
            {
                _cameraLogin = new CameraLogin();
                //_cameraLogin.Show();
                //_cameraHikvisionLogin.Check(toCheck);
                Application.Run();
            }
            );

            ThA.SetApartmentState(ApartmentState.STA);
            ThA.Start();

            _websend = new WebSend();

            Application.Run(Window);
        }


        public static void VerdaPost(string _in)
        {
            _websend.toSend(_in);
            Window.resultsBox.Invoke(new Action<string>((s) => Window.resultsBox.AppendText(Times.TimeReport() + s + "\r\n")), _in);
        }

        public static void NmapPost(string _in)
        {
            Window.outputBox.Invoke(new Action<string>((s) => Window.outputBox.AppendText(s + "\r\n")), _in);
        }

        public static void StatsPost(string _in)
        {
            Window.statsLabel.Invoke(new Action<string>((s) => Window.statsLabel.Text = (s)), _in);
        }
    }
}
