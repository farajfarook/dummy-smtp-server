using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rnwood.SmtpServer;

namespace dummy_smtp_server
{
    public partial class FormMain : Form
    {
        private DefaultServer server;
        private List<IMessage> messages = new List<IMessage>();

        public FormMain()
        {
            InitializeComponent();
            server = new DefaultServer(25);            
            server.MessageReceived += (s, ea) => messages.Add(ea.Message);
            server.SessionStarted += new EventHandler<SessionEventArgs>(this.Server_SessionStarted);
            server.SessionCompleted += new EventHandler<SessionEventArgs>(this.Server_SessionCompleted);
            server.MessageReceived += new EventHandler<MessageEventArgs>(this.Server_MessageRecieved);
            server.MessageCompleted += new EventHandler<MessageEventArgs>(this.Server_MessageCompleted); 
            UpdateUI();
        }

        private void Server_MessageCompleted(object sender, MessageEventArgs e)
        {
            ConsoleLog(e.Message.ToString() + " completed");
            UpdateUI();
        }

        private void Server_MessageRecieved(object sender, MessageEventArgs e)
        {
            ConsoleLog(e.Message.ToString() + " recieved");
            UpdateUI();
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

            lbxEmails.Items.Clear();
            messages.ForEach((msg) => lbxEmails.Items.Insert(0, msg.ToString()));            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }
    }
}
