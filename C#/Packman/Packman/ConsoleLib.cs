using System;

namespace Pacman
{
    public class Wall
    {
        public static int Symbol { get; } = 1;
        public static Sprite Sprite { get; } = new Sprite(ConsoleColor.DarkGray, "██");
    }

    public class Point
    {
        public static int Symbol { get; } = 3;
        public static Sprite Sprite { get; } = new Sprite(ConsoleColor.DarkGray, "#");
    }

    public class SuperPoint
    {
        public static int Symbol { get; } = 4;
        public static Sprite Sprite { get; } = new Sprite(ConsoleColor.Gray, "#");
    }

    [Serializable]
    public class ScoresData
    {
        public int Scores { get; private set; }
        public string Name { get; private set; }

        public ScoresData(ScoresData scoresData)
        {
            Scores = scoresData.Scores;
            Name = scoresData.Name;
        }

        public ScoresData(int scores, string name)
        {
            Scores = scores;
            Name = name;
        }

        public static bool operator <(ScoresData scoresData1, ScoresData scoresData2) =>
            scoresData1.Scores < scoresData2.Scores;

        public static bool operator >(ScoresData scoresData1, ScoresData scoresData2) =>
            scoresData1.Scores > scoresData2.Scores;

        public static bool operator <=(ScoresData scoresData1, ScoresData scoresData2) =>
      scoresData1.Scores <= scoresData2.Scores;

        public static bool operator >=(ScoresData scoresData1, ScoresData scoresData2) =>
            scoresData1.Scores >= scoresData2.Scores;

        public override int GetHashCode()
        {
            unchecked
            {
                return 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((Coord)obj);
        }
    }

    // Направление
    public enum Direction { up, down, left, right, nowhere };

    // Цвет и символ объекта
    public struct Sprite
    {
        public ConsoleColor Color { get; private set; }
        public string Symbol { get; private set; }

        public Sprite(ConsoleColor color, string sym)
        {
            Color = color;
            Symbol = sym;
        }
    }

    // Координаты
    public class Coord
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coord coord1, Coord coord2) =>
                coord1.X == coord2.X && coord1.Y == coord2.Y;

        public static bool operator !=(Coord coord1, Coord coord2) =>
                coord1.X != coord2.X && coord1.Y != coord2.Y && coord2 == null;

        public override int GetHashCode()
        {
            unchecked
            {
                return 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((Coord)obj);
        }
    }

    // Если на объект "наступили" - он запоминаеться 
    public class RememberStepObject
    {
        public Coord Coord { get; private set; }
        public int Number { get; private set; }
        public Sprite Sprite { get; private set; }

        public RememberStepObject(Coord coord, int number, Sprite sprite)
        {
            Coord = coord;
            Number = number;
            Sprite = sprite;
        }

        public RememberStepObject(Coord coord, int number)
        {
            Coord = coord;
            Number = number;
            Sprite = new Sprite(0, "");
        }
    }
}