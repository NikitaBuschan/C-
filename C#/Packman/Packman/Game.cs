using System;
using Pacman.Menu;
using System.Threading;
using System.Collections.Generic;

namespace Pacman
{
    public delegate void Move(Map map);
    public delegate void Eaten();
    public delegate void Exit();

    public class Game
    {
        private Map map;
        public static int lives;
        public static bool fright;
        public static Scores scores = new Scores();
        public static PacmanHero pacman;
        public static List<Unit> ghosts;
        public static List<Coord> startGhostPosition;
        public static Move move;
        public static Exit exit;
        public static Eaten eaten;

        public Game(Map _map)
        {
            map = _map;
            lives = 3;
            fright = false;
            pacman = new PacmanHero();
            ghosts = Create.listOfShadows();
            startGhostPosition = new List<Coord>();
            move = null;
            exit = null;
            eaten = null;
            eaten += pacman.Eaten;
            foreach (var item in ghosts)
            {
                startGhostPosition.Add(item.Coord);
                eaten += item.Eaten;
            }
        }

        public void Start()
        {
            Console.CursorVisible = false;
            Draw.AllMap(map);
            PauseBeforeStartTheGame();
            Draw.HighScore(ConsoleColor.White);
            Draw.Score();
            Draw.Lives();
            Timers.SetTimerOutShadows();

            while (true)
            {
                if (Console.KeyAvailable)
                    pacman.Control(map, Console.ReadKey());

                pacman.Move(map);
                pacman.CheckWin();
                Thread.Sleep(150);

                if (move != null)
                    move(map);
                if (exit != null)
                    exit();

                eaten();
                if (lives == 0)
                    EndGame();

                Draw.Score();
                if (PacmanHero.Scores > scores.highScores)
                {
                    scores.highScores = PacmanHero.Scores;
                    Draw.HighScore(ConsoleColor.Red);
                }
            }
        }

        public void EndGame()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(25, 10);
            Console.WriteLine("You lose!");
            Thread.Sleep(2000);
            Console.Clear();
            scores.AddScores();
            Console.Clear();
            scores.Draw();
            Console.ReadKey();
            Console.Clear();
            var menu = new Menu.Main();
            menu.ShowMenu();
            menu.Control();
        }

        public void PauseBeforeStartTheGame()
        {
            int topPos = 1;
            int leftPos = 18;
            int pauseSeconds = 5;
            var message = "The game will start in: ";

            while (pauseSeconds != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(leftPos, topPos);
                Console.WriteLine(message + pauseSeconds--);
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.KeyAvailable)
                {
                    pacman.Control(map, Console.ReadKey());
                    Console.SetCursorPosition(leftPos, topPos);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message + pauseSeconds);
                }
                Thread.Sleep(1000);
                if (pauseSeconds % 2 != 0)
                    Draw.DrawSymbol(new Coord(17, 14), new Sprite(ConsoleColor.DarkYellow, "@"));
                else
                    Draw.DrawSymbol(new Coord(17, 14), new Sprite(ConsoleColor.Yellow, "@"));
            }
            Console.SetCursorPosition(leftPos, topPos);
            for (int i = 0; i < message.Length + 2; i++)
                Console.Write(" ");
        }
    }
}
