using System;

namespace Pacman
{
    public class Draw
    {
        private static int top = 4;
        private static int left = 3;

        public static void AllMap(Map map)
        {
            for (int i = 13; i < 15; i++)
                map[12, i] = 0;

            for (int i = 0; i < map.Rows; i++)
                for (int j = 0; j < map.Colums; j++)
                    if (map[i, j] == 1)
                        DrawSymbol(new Coord(i, j), Wall.Sprite);
                    else if (map[i, j] == 3)
                        DrawSymbol(new Coord(i, j), Point.Sprite);
                    else if (map[i, j] == 4)
                        DrawSymbol(new Coord(i, j), SuperPoint.Sprite);
                    else if (map[i, j] == 5)
                        DrawSymbol(new Coord(i, j), new Sprite(ConsoleColor.Yellow, "@"));
                    else if (map[i, j] == 6)
                        DrawSymbol(new Coord(i, j), new Sprite(ConsoleColor.Red, "%"));
                    else if (map[i, j] == 7)
                        DrawSymbol(new Coord(i, j), new Sprite(ConsoleColor.Blue, "%"));
                    else if (map[i, j] == 8)
                        DrawSymbol(new Coord(i, j), new Sprite(ConsoleColor.Cyan, "%"));
                    else if (map[i, j] == 9)
                        DrawSymbol(new Coord(i, j), new Sprite(ConsoleColor.Green, "%"));

            CloseTheDoor(map);
        }

        // Закрыти двери после выхода монстра
        public static void CloseTheDoor(Map map)
        {
            for (int i = 13; i < 15; i++)
                map[12, i] = 1;
        }
        // Рекорд заработанных очков за игру
        public static void HighScore(ConsoleColor color)
        {
            Console.SetCursorPosition(6, 2);
            Console.Write($"High score: ");
            Console.ForegroundColor = color;
            Console.Write(Game.scores.highScores);
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Очки текущей игры
        public static void Score()
        {
            Console.SetCursorPosition(28, 2);
            Console.WriteLine($"Scores: {PacmanHero.Scores}");
        }
        // Количество жизней
        public static void Lives()
        {
            Console.SetCursorPosition(46, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Lives: ");
            Console.Write(Game.lives);
        }

        public static void DrawSymbol(Coord coord, Sprite spriteObject)
        {
            Console.ForegroundColor = spriteObject.Color;
            Console.SetCursorPosition(coord.Y * 2 + left, coord.X + top);
            Console.Write(spriteObject.Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RedrowUnit(Unit unit, RememberStepObject obj)
        {
            if (obj != null)
                DrawSymbol(obj.Coord, obj.Sprite);
            else
                DrawSymbol(unit.Coord, new Sprite(0, " "));

            DrawSymbol(unit.NextCoord, unit.Sprite);
        }
        public static void RedrowUnitToNewPosition(Unit unit, Coord newCoord)
        {
            DrawSymbol(unit.Coord, new Sprite(0, " "));
            DrawSymbol(newCoord, unit.Sprite);
        }
    }
}