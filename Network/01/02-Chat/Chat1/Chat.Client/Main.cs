using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Chat.Common;

namespace Chat.Client
{
    public partial class Main : Form
    {
        public Socket ClientSocket { get; set; }
        public string ClientName { get; set; }
        private readonly byte[] byteDataToReceive = new byte[1024];

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Text = $"TcpChat.Client: {ClientName}";

            var dataToSend = new Data
            {
                Command = Command.List,
                Name = ClientName,
                Message = null
            };

            byte[] byteDataToSend = dataToSend.ToBytes();

            ClientSocket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

            ClientSocket.BeginReceive(byteDataToReceive, 0, byteDataToReceive.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }

        private void textMessage_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = textMessage.Text.Trim().Length > 0;
        }

        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End && btnSend.Enabled)
                btnSend_Click(sender, null);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var dataToSend = new Data
                {
                    Command = Command.Message,
                    Name = ClientName,
                    Message = textMessage.Text.Trim()
                };

                byte[] byteDataToSend = dataToSend.ToBytes();

                ClientSocket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                textMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу отослать сообщение серверу.", $"TcpChat.Client: {ClientName}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"TcpChat.Client: {ClientName}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndReceive(ar);

                var dataReceived = new Data(byteDataToReceive);

                switch (dataReceived.Command)
                {
                    case Command.Login:
                        listBox.Items.Add(dataReceived.Name);
                        break;
                    case Command.Logout:
                        listBox.Items.Remove(dataReceived.Name);
                        break;
                    case Command.Message:
                        break;
                    case Command.List:
                        listBox.Items.AddRange(dataReceived.Message.Split('|'));
                        listBox.Items.RemoveAt(listBox.Items.Count - 1);
                        textMessage.Text += $"<<<{ClientName} присоединился к чату>>>\r\n";
                        break;
                }

                if (dataReceived.Message != null && dataReceived.Command != Command.List)
                    textMessage.Text += $"{dataReceived.Message}\r\n";

                ClientSocket.BeginReceive(byteDataToReceive, 0, byteDataToReceive.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"TcpChat.Client: {ClientName}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите покинуть чат?", $"TcpChat.Client: {ClientName}", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                var dataToSend = new Data
                {
                    Command = Command.Logout,
                    Name = ClientName,
                    Message = null
                };

                byte[] byteDataToSend = dataToSend.ToBytes();

                ClientSocket.Send(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None);
                ClientSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"TcpChat.Client: {ClientName}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
