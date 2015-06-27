using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rnwood.SmtpServer;

namespace Dummy.SmtpServer
{
    public partial class FormMain : Form
    {
        private const String SAVED_EMAIL_FOLDER = "Saved Emails";        
        private DefaultServer server;
        private List<SavedMessage> messages = new List<SavedMessage>();

        public FormMain()
        {
            InitializeComponent();            
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            server = new DefaultServer(25);                        
            server.SessionStarted += new EventHandler<SessionEventArgs>(this.Server_SessionStarted);
            server.SessionCompleted += new EventHandler<SessionEventArgs>(this.Server_SessionCompleted);
            server.MessageReceived += new EventHandler<MessageEventArgs>(this.Server_MessageRecieved);
            server.MessageCompleted += new EventHandler<MessageEventArgs>(this.Server_MessageCompleted);
            StartServer();
        }

        private void Server_MessageCompleted(object sender, MessageEventArgs e)
        {
            ConsoleLog(e.Message.ToString() + " completed");
            UpdateUI();
        }

        private void Server_MessageRecieved(object sender, MessageEventArgs e)
        {
            IMessage msg = e.Message;
            String path = SaveToFile(msg);            
            messages.Add(new SavedMessage(msg, path));

            ConsoleLog(e.Message.ToString() + " recieved");

            UpdateUI();
        }

        private string SaveToFile(IMessage msg)
        {
            if (!Directory.Exists(SAVED_EMAIL_FOLDER)) Directory.CreateDirectory(SAVED_EMAIL_FOLDER);

            String path = ""; int fileNo = 0;
            do path = SAVED_EMAIL_FOLDER + "\\" + msg.ReceivedDate.ToString(@"hh_mm_ss") + "_" + (fileNo++) + ".msg"; while (File.Exists(path));

            StreamReader dataReader = new StreamReader(msg.GetData());
            String data = dataReader.ReadToEnd();
            File.WriteAllText(path, data);
            return path;
        }

        private void Server_SessionCompleted(object sender, SessionEventArgs e)
        {
            ConsoleLog(e.Session.ClientAddress.ToString() + " disconnected");
        }

        private void Server_SessionStarted(object sender, SessionEventArgs e)
        {
            ConsoleLog(e.Session.ClientAddress.ToString() + " connected");
        }

        private void ConsoleLog(String message)
        {
            String time = DateTime.Now.ToString(@"hh\:mm\:ss");
            if (lbxConsole.InvokeRequired)
            {
                lbxConsole.Invoke(new MethodInvoker(delegate { lbxConsole.Items.Insert(0, time + ": " + message);}));
            }
            else
            {
                lbxConsole.Items.Insert(0, time + ": " + message);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (server.IsRunning) server.Stop();
            UpdateUI();
        }

        private void StartServer()
        {
            if(!server.IsRunning) server.Start();
            UpdateUI();
        }

        private void UpdateUI()
        {
            String message = (server.IsRunning) ? "SMTP Server started in port " + server.PortNumber + "..." : "Server Stopped.";
            btnStart.Enabled = !server.IsRunning;
            btnStop.Enabled = server.IsRunning;
            lblServerStatus.Text = message;
            ConsoleLog(message);

            if (lbxEmails.InvokeRequired) lbxEmails.Invoke(new MethodInvoker(updateEmailList));
            else updateEmailList();            
        }

        private void updateEmailList()        {
            lbxEmails.Items.Clear();
            messages.ForEach((msg) =>
            {
                String title = msg.Message.ReceivedDate.ToString(@"hh\:mm\:ss") + ", To: ";                
                foreach (String to in msg.Message.To) { title += to + ","; }
                title = title.Remove(title.Length - 1);
                lbxEmails.Items.Insert(0, title);
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void lbxEmails_DoubleClick(object sender, EventArgs e)
        {
            int index = lbxEmails.SelectedIndex;
            if(index < 0) return;

            SavedMessage msg = messages[messages.Count - (index + 1)];
            if (File.Exists(msg.Path))
            {
                msg.Path = SaveToFile(msg.Message);
            }
            System.Diagnostics.Process.Start(msg.Path);
        }
    }
}
