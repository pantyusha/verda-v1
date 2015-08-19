using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace Verda
{
    public class NmapWorker
    {

        BackgroundWorker worker;
        private string NmapLocation;

        public delegate void ReceivedContainer(string data);
        public event ReceivedContainer Received;
        public delegate void EndedContainer();
        public event EndedContainer Ended;

        public void NmapRun(string arguments, string path)
        {
            worker = new BackgroundWorker();
            worker.DoWork += NmapExec;
            worker.RunWorkerCompleted += NmapEnds;
            NmapLocation = path;
            worker.RunWorkerAsync(arguments);
        }

        private void NmapExec(object sender, DoWorkEventArgs e)
        {
            Process compiler = new Process();
            compiler.StartInfo.FileName = NmapLocation;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardInput = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.RedirectStandardError = true;
            compiler.StartInfo.CreateNoWindow = true;
            compiler.OutputDataReceived += OutputDataHandler;
            compiler.ErrorDataReceived += OutputDataHandler;
            compiler.StartInfo.Arguments = (string)e.Argument;
            compiler.Start();
            compiler.BeginOutputReadLine();
            compiler.BeginErrorReadLine();
            compiler.WaitForExit();
            compiler.CancelOutputRead();
            compiler.CancelErrorRead();
            compiler.Close();
        }

        private void NmapEnds(object sender, RunWorkerCompletedEventArgs e)
        {
            Ended();
        }

        private void OutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                {

                    Received(outLine.Data);
                }
            }
        }

    }
}
