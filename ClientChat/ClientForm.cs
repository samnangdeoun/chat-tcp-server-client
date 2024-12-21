using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClientChat
{
    public partial class ClientForm : Form
    {

        private TcpClient client;
        private NetworkStream stream;
        private string username;
        private bool isClosing = false;

        public ClientForm()
        {
            InitializeComponent();
            DisplayChat.ReadOnly = true;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTb.Text != "")
            {
                // Start listening for messages in a background thread
                client = new TcpClient();
                client.Connect("127.0.0.1", 8888);
                stream = client.GetStream();

                username = UsernameTb.Text;
                UsersLb.Items.Add(username);
                SendMessage($"{username} Joined the Chat.");

                Task.Run(() => ReceiveMessages());
                ConnectBtn.Enabled = false;
                SendBtn.Enabled = true;
                SendMessageTb.Enabled = true;
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            string message;
            try
            {
                while (!isClosing)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // Server disconnected
                        SendMessage("Diconnected From Server...");
                        stream.Close();
                        client.Close();

                        return;
                        //break;
                    }

                    message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Check if the received message is a user joining message
                    if (message.StartsWith("User") && message.EndsWith("Joined the Chat."))
                    {
                        string userJoined = message.Split(' ')[1];
                        bool userAlreadyExists = false;

                        // Check if the user is already in the listuser ListBox
                        foreach (var item in UsersLb.Items)
                        {
                            if (item.ToString() == userJoined)
                            {
                                userAlreadyExists = true;
                                break;
                            }
                        }

                        if (!userAlreadyExists)
                        {
                            AddUser(userJoined);                   
                        }
                    }
                    else
                    {
                        AppendToChatWindow(message);
                    }
                }
            }
            catch
            {
                stream.Close();
                client.Close();

                return;
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SendMessageTb.Text))
            {
                string message = $"{username}: {SendMessageTb.Text}";
                SendMessage(message);
                SendMessageTb.Clear();
            }
        }

        private void SendMessage(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                isClosing = true;
                if (client != null && client.Connected && stream != null)
                {
                    string disMessage = $"{username} Disconnected.";
                    byte[] disByte = Encoding.UTF8.GetBytes(disMessage);
                    stream.Write(disByte, 0, disByte.Length);
                    stream.Close();
                    client.Close();

                }

                SendMessage("Disconnected From Server");
                this.ClientForm_FormClosing(sender, e);
            }
            catch (IOException) { this.Close(); }
            catch (Exception)
            {
                if (!isClosing)
                {
                    isClosing = true;
                    MessageBox.Show("Error Disconnecting From Server");
                    isClosing = false;
                }
            }
        }

        private void AddUser(string user)
        {
            UsersLb.Items.Add(user);
        }
        private void AppendToChatWindow(string message)
        {    
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    AppendToChatWindow(message);
                }));
                return;
            }
            DisplayChat.AppendText(message + Environment.NewLine);
            DisplayChat.ScrollToCaret();
        }
    }
}