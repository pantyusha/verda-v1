using System;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Net;

namespace Verda
{
    public partial class MainForm : Form
    {
        private string argConfig;
        private string argRange;
        private string arguments;
        private int debugcounter = 1;
        private string nextliner;
        public string chosenPreset;
        private string verdaVersion;
        private string verdaVersionAdditional = ("Delayed Apologies");
        private string NmapLocation;
        private string availVersion;
        WebClient client = new WebClient();
        private bool waitForBrute;
        DirectoryInfo reportsDir;

        NmapWorker nmap;
        NmapReceiver _nmapReceiver;
        NmapAnalyzer _nmapAnalyzer;

        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Copy");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //версию в шапку
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            verdaVersion = version.Major + "." + version.Minor + "." + (version.Build - 5677) + "." + (version.Revision / 86);
            this.Text = "Verda " + verdaVersion + " " + verdaVersionAdditional;

            //список пресетов
            ArrayList Presets = new ArrayList();
            Presets.Add(new Preset("http-title", "http-title"));
            Presets.Add(new Preset("Camera(Normal)", "Webcam"));
            Presets.Add(new Preset("Camera(Fastest)", "Webcam-fast"));
            Presets.Add(new Preset("Camera(Alternative)", "Webcam-advanced"));
            Presets.Add(new Preset("Custom args", "custom"));
            presetComboBox.DataSource = Presets;
            presetComboBox.DisplayMember = "DisplayName";
            presetComboBox.ValueMember = "ShortName";

            try
            {
                availVersion = client.DownloadString("http://verda-dl.zz.mu/version");
                availVersion = availVersion.Remove(availVersion.Length - 1);
                if (availVersion == verdaVersion)
                {
                    updateLabel.Text = "you are using the latest version";
                    updateLabel.ForeColor = Color.Green;
                }
                else
                {
                    updateLabel.Text = "update is available:" + availVersion;
                    updateLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                updateLabel.Text = "verda-dl.zz.mu unreachable?";
                updateLabel.ForeColor = Color.Red;
            }

            //восстановление сессии
            if (File.Exists("restore"))
            {
                using (StreamReader resread = new StreamReader(File.Open("restore", FileMode.Open)))
                {
                    presetComboBox.SelectedValue = resread.ReadLine();
                    presetRangeBox.Text = resread.ReadLine();
                    NmapLocation = resread.ReadLine();
                    resread.Close();
                }
            }
            else
            {
                presetComboBox.SelectedValue = "Webcam-fast";
                presetRangeBox.Text = "-iR 10000";
            }

            //обеспечение контекстного меню
            menuItem.Click += new EventHandler(CopyAction);
            contextMenu.MenuItems.Add(menuItem);
            resultsBox.ContextMenu = contextMenu;
            //outputBox.ContextMenu = contextMenu;

            //пишем в Version
            System.IO.StreamWriter verwrite = new System.IO.StreamWriter("version");
            verwrite.WriteLine(verdaVersion);
            verwrite.Close();

            //ищем Nmap
            locateNmap();
        }

        private void locateNmap()
        {
            if (File.Exists(NmapLocation))
            {
                labelAboutNmap.Text = "Path to nmap.exe set as " + NmapLocation;
            }
            else
                if (File.Exists("C:/Program Files (x86)/Nmap/nmap.exe"))
                {
                    NmapLocation = "C:/Program Files (x86)/Nmap/nmap.exe";
                    labelAboutNmap.Text = "Path to nmap.exe automatically set as  " + NmapLocation;
                }
                else
                    if (File.Exists("C:/Program Files/Nmap/nmap.exe"))
                    {
                        NmapLocation = "C:/Program Files/Nmap/nmap.exe";
                        labelAboutNmap.Text = "Path to nmap.exe automatically set as  " + NmapLocation;
                    }
                    else
                        if (File.Exists("nmap/nmap.exe"))
                        {
                            NmapLocation = "nmap/nmap.exe";
                            labelAboutNmap.Text = "Path to nmap.exe automatically set as  " + NmapLocation;
                        }
                        else
                        {
                            MessageBox.Show("nmap.exe not found. Install NMAP or set path to nmap.exe in settings", "nmap.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            labelAboutNmap.Text = "nmap.exe not found!";
                        }
        }

        public void OnScanEnd()
        {
            if (Program.CamTargets <= 0)
            {

                waitForBrute = false;
                sendButton.Enabled = true;
                cancelScanButton.Enabled = false;
                this.BackColor = Color.GhostWhite;
                debugPost("Verda has finished.");
                busyPic.Image = null;
                statsLabel.Text = "Verda has finished.";
                busyPic.Image = null;
                optionsTabControl.Enabled = true;
                resultsPost(Times.TimeReport() + "Scan completed. Found:" + _nmapAnalyzer.resultCounter + System.Environment.NewLine);

                reportTimer.Enabled = false;
                System.IO.StreamWriter report = new System.IO.StreamWriter(reportsDir + "/nmap.txt");
                report.Write(outputBox.Text);
                report.Close();
                report = new System.IO.StreamWriter(reportsDir + "/Verda.txt");
                report.Write("Verda version " + verdaVersion + System.Environment.NewLine + resultsBox.Text);
                report.Close();

            }
            else
            {
                statsLabel.Text = "NMAP has finished, waiting for brute to finish...";
                waitForBrute = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            statsLabel.Text = "trying to launch...";
            debugPost("Trying to launch...");

            Program.CamTargets = 0;

            System.IO.StreamWriter reswrite = new System.IO.StreamWriter("restore");
            reswrite.WriteLine(presetComboBox.SelectedValue);
            reswrite.WriteLine(presetRangeBox.Text);
            reswrite.WriteLine(NmapLocation);
            reswrite.Close();

            sendButton.Enabled = false;
            optionsTabControl.SelectedIndex = 0;
            waitForBrute = false;
            scanLaunch();
        }

        private void scanLaunch()
        {
            if (File.Exists(NmapLocation))
            {
                reportsDir = new DirectoryInfo("reports/" + "Verda-report-" + Times.DateFolderName());
                reportsDir.Create();
                outputBox.Text = null;
                resultsBox.Text = null;
                reportTimer.Enabled = true;
                outputBox.AppendText("Command: " + arguments + System.Environment.NewLine);
                argConfig = null;
                argRange = null;
                generateArguments();
                resultsPost(DateTime.Now.ToString("[HH:mm:ss] ") + "Scan started. Target: " + argRange + " , Preset: " + chosenPreset + System.Environment.NewLine);
                optionsTabControl.Enabled = false;

                inputBox.Text = arguments;
                cancelScanButton.Enabled = true;

                nmap = new NmapWorker();
                _nmapReceiver = new NmapReceiver();
                _nmapAnalyzer = new NmapAnalyzer();
                _nmapAnalyzer.mode = chosenPreset;
                nmap.Received += _nmapReceiver.OnReceive;
                nmap.Received += _nmapAnalyzer.Parse;
                nmap.Ended += OnScanEnd;
                nmap.NmapRun(arguments, NmapLocation);

                debugPost("Scan started.");
                busyPic.Image = Verda.Properties.Resources.gif_loading;
                statsLabel.Text = "Scan started.";
                this.BackColor = Color.Lavender;
            }
            else
                MessageBox.Show("nmap.exe not found. Install NMAP or set path to nmap.exe in settings", "nmap.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void generateArguments()
        {
            chosenPreset = presetComboBox.SelectedValue.ToString();
            argRange = presetRangeBox.Text;
            if (chosenPreset == "http-title") { argConfig = "-T5 -n -Pn -p 80,443 --open --script http-title --stats-every 5s"; }
            if (chosenPreset == "Webcam") { argConfig = "-T3 -n -Pn -p 80,8080 --open --script http-title --stats-every 5s"; }
            if (chosenPreset == "Webcam-fast") { argConfig = "-T5 -n -Pn -p 80,8080 --open --script http-title --stats-every 5s"; }
            if (chosenPreset == "Webcam-advanced") { argConfig = "-T5 -n -Pn -p 80,82,83,1010,1614,2000,4002,5000,5900,8003,8028,8080,8081,8082,8888,12122 --open --stats-every 5s"; }
            if (chosenPreset == "custom") { argConfig = customArgTextBox.Text + " "; }
            arguments = argConfig + " " + argRange;
        }

        private void debugPost(string message)
        {
            if (debugBox.Text == "") { nextliner = null; } else { nextliner = "\r\n"; }
            debugBox.AppendText(nextliner + debugcounter + ": " + message);
            debugcounter += 1;
        }

        private void resultsPost(string message)
        {
            resultsBox.AppendText(message);
        }
        private void statsPost(string message)
        {
            statsLabel.Text = message;
        }
        public delegate void RTResultsPost(string message);
        public delegate void RTStatsPost(string message);

        private void debugBox_TextChanged(object sender, EventArgs e)
        {
            debugBox.Select(debugBox.Text.Length, 0);
            debugBox.ScrollToCaret();
        }

        private void cancelScanButton_Click(object sender, EventArgs e)
        {
            Process[] nmaps = Process.GetProcessesByName("nmap");
            if (nmaps.Length > 0)
            {
                foreach (Process nmap in nmaps)
                {
                    nmap.Kill();
                }
            }
            debugPost("Force stop.");
            resultsPost(DateTime.Now.ToString("[HH:mm:ss] ") + "Force stop." + System.Environment.NewLine);
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(resultsBox.SelectedText);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] nmaps = Process.GetProcessesByName("nmap");
            if (nmaps.Length > 0)
            {
                foreach (Process nmap in nmaps)
                {
                    nmap.Kill();
                }
            }
        }

        private void resultsBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateArguments();
            inputBox.Text = arguments;
        }

        private void presetRangeBox_TextChanged(object sender, EventArgs e)
        {
            generateArguments();
            inputBox.Text = arguments;
        }

        private void customArgTextBox_TextChanged(object sender, EventArgs e)
        {
            generateArguments();
            inputBox.Text = arguments;
        }

        private void reportTimer_Tick(object sender, EventArgs e)
        {
            System.IO.StreamWriter report = new System.IO.StreamWriter(reportsDir + "/nmap.txt");
            report.Write(outputBox.Text);
            report.Close();
            report = new System.IO.StreamWriter(reportsDir + "/Verda.txt");
            report.Write("Verda version " + verdaVersion + verdaVersionAdditional + System.Environment.NewLine + resultsBox.Text);
            report.Close();
        }

        private void nmapPath_Click(object sender, EventArgs e)
        {
            NmapLocationDialog.ShowDialog();
        }

        private void NmapLocationDialog_FileOk(object sender, CancelEventArgs e)
        {
            NmapLocation = NmapLocationDialog.FileName;
            labelAboutNmap.Text = "Path to nmap.exe manually set as  " + NmapLocation;
            System.IO.StreamWriter reswrite = new System.IO.StreamWriter("restore");
            reswrite.WriteLine(presetComboBox.SelectedValue);
            reswrite.WriteLine(presetRangeBox.Text);
            reswrite.WriteLine(NmapLocation);
            reswrite.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void camBruteTimer_Tick(object sender, EventArgs e)
        {
            camTargetsLabel.Text = Program.CamTargets.ToString();
            if (waitForBrute == true && Program.CamTargets <= 0)
                OnScanEnd();
        }



    }
}
