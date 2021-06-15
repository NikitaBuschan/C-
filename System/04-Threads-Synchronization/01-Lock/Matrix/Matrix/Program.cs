using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Threading;

namespace Matrix
{
    class Program
    {
        public static List<bool> DropLinePosition { get; set; } = new List<bool>();
        public static object counterLock = new object();

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.CursorVisible = false;

            for (int i = 0; i < Console.WindowWidth; i++)
                DropLinePosition.Add(true);

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
                CreateThread();
                Thread.Sleep(100);
            }
            Console.Clear();
        }

        static void CreateThread()
        {
            int line = new Random().Next(0, Console.WindowWidth);

            if (DropLinePosition[line] == true)
            {
                (new Thread(() =>
                {
                    DropLinePosition[line] = false;

                    List<char> symbols = new List<char>();
                    for (int i = new Random().Next(3, 10); i > 0; i--)
                        symbols.Add((char)new Random().Next(65, 90));

                    int topPosition = -symbols.Count;
                    int botPosition = 0;
                    do
                    {
                        if (topPosition < 0)
                        {
                            for (int i = symbols.Count - botPosition; i < symbols.Count; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(symbols[i]);
                                }
                            }
                            Thread.Sleep(100);
                            for (int i = symbols.Count - botPosition; i < symbols.Count; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(" ");
                                }
                            }
                        }
                        else if (botPosition > Console.WindowHeight - 2)
                        {
                            for (int i = 0; i < Console.WindowHeight - 2 - topPosition; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(symbols[i]);
                                }
                            }
                            Thread.Sleep(100);
                            for (int i = 0; i < Console.WindowHeight - 2 - topPosition; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(" ");
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < symbols.Count; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(symbols[i]);
                                }
                            }
                            Thread.Sleep(100);
                            for (int i = 0; i < symbols.Count; i++)
                            {
                                SetTextColore(i, symbols.Count);
                                lock (counterLock)
                                {
                                    Console.SetCursorPosition(line, topPosition + i);
                                    Console.WriteLine(" ");
                                }
                            }
                        }

                        botPosition++;
                        topPosition++;
                    } while (topPosition != Console.WindowHeight - 1);

                    DropLinePosition[line] = true;
                })
                { IsBackground = true }).Start();
            }
        }

        public static void SetTextColore(int symbolPosotion, int countSymbols)
        {
            if (symbolPosotion == countSymbols - 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (symbolPosotion == countSymbols - 2)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
