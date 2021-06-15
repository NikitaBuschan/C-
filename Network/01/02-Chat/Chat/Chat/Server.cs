using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Common;

namespace Chat
{
    public partial class Server : Form
    {
        private struct ClientInfo
        {
            public Socket Socket { get; set; }
            public string Name { get; set; }
        }

        private readonly List<ClientInfo> clientList = new List<ClientInfo>();
        private Socket serverSocket;
        private readonly byte[] byteDataToReceive = new byte[1024];

        public Server()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var ipEndPoint = new IPEndPoint(IPAddress.Any, 1111);

                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(10);
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                clientSocket.BeginReceive(byteDataToReceive, 0, byteDataToReceive.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;

                clientSocket.EndReceive(ar);

                var dataReceived = new Data(byteDataToReceive);

                var dataToSend = new Data
                {
                    Command = dataReceived.Command,
                    Name = dataReceived.Name
                };

                switch (dataReceived.Command)
                {
                    case Command.Login:
                        clientList.Add(new ClientInfo
                        {
                            Socket = clientSocket,
                            Name = dataReceived.Name
                        });

                        dataToSend.Message = $"<<<{dataReceived.Name} присоединился к чату>>>";
                        break;
                    case Command.Logout:
                        clientList.RemoveAt(clientList.FindIndex(c => c.Socket == clientSocket));
                        clientSocket.Close();

                        dataToSend.Message = $"<<<{dataReceived.Name} покинул чат>>>";
                        break;
                    case Command.Message:
                        dataToSend.Message = $"{dataReceived.Name}: {dataReceived.Message}";
                        break;
                    case Command.List:
                        dataToSend.Name = null;
                        dataToSend.Message = null;

                        foreach (var client in clientList)
                        {
                            dataToSend.Message += $"{client.Name}|";
                        }

                        byte[] byteDataToSend = dataToSend.ToBytes();

                        clientSocket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);
                        break;
                }

                if (dataToSend.Command != Command.List)
                {
                    byte[] byteDataToSend = dataToSend.ToBytes();

                    foreach (var client in clientList)
                    {
                        if (client.Socket != clientSocket || dataToSend.Command != Command.Login)
                        {
                            client.Socket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None, new AsyncCallback(OnSend), client.Socket);
                        }
                    }

                    textBox.Text += $"{dataToSend.Message}\r\n";
                }

                if (dataReceived.Command != Command.Logout)
                {
                    clientSocket.BeginReceive(byteDataToReceive, 0, byteDataToReceive.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;

                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
