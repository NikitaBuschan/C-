using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 22000;

            try
            {
                byte[] bytes = new byte[1024];

                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];

                var ipEndPoint = new IPEndPoint(ipAddr, port);
                var sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ipEndPoint);

                try
                {
                    while (true)
                    {
                        Console.Write("Введите сообщение \"time\" для отображения времени: ");
                        string message = Console.ReadLine();

                        if (message.Length == 0)
                            continue;

                        int bytesSent = sender.Send(Encoding.UTF8.GetBytes(message));
                        int bytesReceived = sender.Receive(bytes);

                        if (message.Trim() == "exit")
                            break;

                        Console.WriteLine($"Ответ от сервера: {Encoding.UTF8.GetString(bytes, 0, bytesReceived)}.");
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine($"Соединение с сервером разорвано.");
                }
                finally
                {
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("Не могу установить соединение с сервером.");
            }
        }
    }
}
