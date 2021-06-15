using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 22000;

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];

            var ipEndPoint = new IPEndPoint(ipAddr, port);
            var socketListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socketListener.Bind(ipEndPoint);
                socketListener.Listen(10);

                Console.WriteLine($"Ожидаем соединения через порт {ipEndPoint.Port}...");

                while (true)
                {
                    Socket socket = socketListener.Accept();

                    Console.WriteLine($"Присоединился {socket.RemoteEndPoint}.");

                    var thread = new Thread(new ParameterizedThreadStart(ClientThreadProc));
                    thread.IsBackground = true;
                    thread.Start(socket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void ClientThreadProc(object socket)
        {
            Socket clientSocket = (Socket)socket;

            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesReceived = clientSocket.Receive(bytes);

                    string data = Encoding.UTF8.GetString(bytes, 0, bytesReceived);

                    if (data.Trim() == "time")
                    {
                        clientSocket.Send(Encoding.UTF8.GetBytes($"Текущее время: {DateTime.Now.ToLocalTime().ToShortTimeString()}"));
                    }
                    else if (data.Trim() == "exit")
                    {
                        Console.WriteLine($"Отсоединился {clientSocket.RemoteEndPoint}.");
                        break;
                    }
                    else
                    {
                        clientSocket.Send(Encoding.UTF8.GetBytes($"Not found command: \"{data.Trim()}\""));
                    }
                }
            }
            catch (SocketException)
            {
                Console.WriteLine($"Соединение с {clientSocket.RemoteEndPoint} разорвано.");
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
