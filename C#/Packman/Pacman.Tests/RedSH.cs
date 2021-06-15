using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Tests
{
    public class RedSH
    {
        private int top = 4;
        private int left = 3;

        public RememberStepObject eat = null;
        public Sprite Sprite { get; set; }
        public Coord Coord { get; protected set; }
        public Coord NextCoord { get; protected set; }
        public Direction objectDirection = Direction.left;
        protected int unitNumber;
        protected bool inGame = false;
        public bool drop = false;

        public RedSH(MapTest map, Coord coord)
        {
            unitNumber = 6;
            Coord = coord;
            map.map[coord.X, coord.Y] = 6;
        }

        public void DrawSymbol(Coord coord, Sprite spriteObject)
        {
            Console.ForegroundColor = spriteObject.Color;
            //Console.SetCursorPosition(coord.Y * 2 + left, coord.X + top);
            //Console.Write(spriteObject.Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RedrowUnit(RedSH unit, RememberStepObject obj)
        {
            // Если существует объект obj который должен быть возвращен на своё
            // прежднее место после прохода другого объекта
            if (obj != null)
                DrawSymbol(obj.Coord, obj.Sprite);
            else
                DrawSymbol(unit.Coord, new Sprite(0, " "));

            DrawSymbol(unit.NextCoord, unit.Sprite);
        }
        public void RedrowUnitToNewPosition(RedSH unit, Coord newCoord)
        {
            DrawSymbol(unit.Coord, new Sprite(0, " "));
            DrawSymbol(newCoord, unit.Sprite);
        }

        public void Move(MapTest map)
        {
            Random random = new Random();
            List<Direction> posibleDir = ChooseWey(map, objectDirection);
            objectDirection = posibleDir[random.Next(0, posibleDir.Count)];

            NextCoord = GetCoordByDirection(objectDirection);

            // Если мы наступали в пустое поле
            if (eat == null)
            {
                if (map.map[NextCoord.X, NextCoord.Y] == 3)
                    eat = new RememberStepObject(NextCoord, 3, Point.Sprite);
                else if (map.map[NextCoord.X, NextCoord.Y] == 4)
                    eat = new RememberStepObject(NextCoord, 4, SuperPoint.Sprite);
                else if (map.map[NextCoord.X, NextCoord.Y] == 7)
                    eat = new RememberStepObject(NextCoord, 7, new Sprite(0, ""));


                // если приведение наступает в тунель
                if (GetCoordByDirection(objectDirection).X == 14 && GetCoordByDirection(objectDirection).Y == 0)
                {
                    NextCoord = new Coord(14, 27);
                    RedrowUnit(this, null);
                    ChangeCoord(map, NextCoord, 0, unitNumber);
                    return;
                }
                else if (GetCoordByDirection(objectDirection).X == 14 && GetCoordByDirection(objectDirection).Y == 27)
                {
                    NextCoord = new Coord(14, 0);
                    RedrowUnit(this, null);
                    ChangeCoord(map, NextCoord, 0, unitNumber);
                    return;
                }

                RedrowUnit(this, null);
                ChangeCoord(map, GetCoordByDirection(objectDirection), 0, unitNumber);
            }
            //Если наступали в поле, в котором уже кто - то был
            else if (eat != null)
            {
                if (map.map[NextCoord.X, NextCoord.Y] == 3)
                {
                    RedrowUnit(this, eat);
                    eat = new RememberStepObject(NextCoord, 3, Point.Sprite);
                    ChangeCoord(map, GetCoordByDirection(objectDirection), eat.Number, unitNumber);
                }
                else if (map.map[NextCoord.X, NextCoord.Y] == 4)
                {
                    RedrowUnit(this, eat);
                    eat = new RememberStepObject(NextCoord, 4, SuperPoint.Sprite);
                    ChangeCoord(map, GetCoordByDirection(objectDirection), eat.Number, unitNumber);
                }
                else if (eat.Number == 7)
                {
                    ChangeCoord(map, NextCoord, unitNumber);
                    eat = null;
                }
                else
                {
                    RedrowUnit(this, eat);
                    ChangeCoord(map, GetCoordByDirection(objectDirection), eat.Number, unitNumber);
                    eat = null;
                }
            }
        }

        // Проверка возможности хода
        public bool CheckMove(MapTest map, Coord coord) => map.map[coord.X, coord.Y] != 1;

        // Вернуть координаты по указанному пути
        public Coord GetCoordByDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    return new Coord(Coord.X - 1, Coord.Y);
                case Direction.down:
                    return new Coord(Coord.X + 1, Coord.Y);
                case Direction.left:
                    return new Coord(Coord.X, Coord.Y - 1);
                case Direction.right:
                    return new Coord(Coord.X, Coord.Y + 1);
            }
            return null;
        }

        // Проверка на противоположность направлений
        public bool BackWay(Direction direction, Direction newDirection)
        {
            return direction == Direction.down && newDirection == Direction.up ||
                direction == Direction.up && newDirection == Direction.down ||
                direction == Direction.left && newDirection == Direction.right ||
                direction == Direction.right && newDirection == Direction.left;
        }

        // Вернуть лист возможных путей
        public List<Direction> ChooseWey(MapTest map, Direction dir)
        {
            List<Direction> posibleDirections = new List<Direction>();
            //if (!BackWay(dir, Direction.up) && CheckMove(map, GetCoordByDirection(Direction.up)))
            //    posibleDirections.Add(Direction.up);
            //if (!BackWay(dir, Direction.down) && CheckMove(map, GetCoordByDirection(Direction.down)))
            //    posibleDirections.Add(Direction.down);
            //if (!BackWay(dir, Direction.left) && CheckMove(map, GetCoordByDirection(Direction.left)))
            //    posibleDirections.Add(Direction.left);
            if (!BackWay(dir, Direction.right) && CheckMove(map, GetCoordByDirection(Direction.right)))
                posibleDirections.Add(Direction.right);

            return posibleDirections;
        }

        public void ChangeCoord(MapTest map, Coord newCoord, int step)
        {
            map.map[newCoord.X, newCoord.Y] = step;
            Coord = newCoord;
        }

        public void ChangeCoord(MapTest map, Coord newCoord, int stay, int step)
        {
            map.map[Coord.X, Coord.Y] = stay;
            map.map[newCoord.X, newCoord.Y] = step;
            Coord = newCoord;
        }
    }
}
