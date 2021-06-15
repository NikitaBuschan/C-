using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat.Common;


namespace Chat.Client
{
    public partial class Login : Form
    {
        public Socket ClientSocket { get; set; }
        public string ClientName { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = textBoxName.Text.Trim().Length > 0 && textBoxServer.Text.Trim().Length > 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var ipAddress = IPAddress.Parse(textBoxServer.Text.Trim());
                var ipEndPoint = new IPEndPoint(ipAddress, 1111);

                ClientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndConnect(ar);

                var dataToSend = new Data
                {
                    Command = Command.Login,
                    Name = textBoxName.Text.Trim(),
                    Message = null
                };

                byte[] byteDataToSend = dataToSend.ToBytes();

                ClientSocket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndSend(ar);

                ClientName = textBoxName.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
