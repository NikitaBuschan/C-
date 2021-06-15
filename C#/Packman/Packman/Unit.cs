using System.Collections.Generic;

namespace Pacman
{
    public abstract class Unit
    {
        public Sprite Sprite { get;  set; }
        public Coord Coord { get; protected set; }
        public Coord NextCoord { get; protected set; }
        public Direction objectDirection = Direction.left;
        protected bool inGame = false;
        public int UnitNumber { get; protected set; }

        public abstract void Move(Map map);

        public abstract void Eaten();

        public abstract void Eat();

        public abstract void Exit();

        // Проверка возможности хода
        public bool CheckMove(Map map, Coord coord) => map[coord] != 1;

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
        public List<Direction> ChooseWey(Map map, Direction dir)
        {
            List<Direction> posibleDirections = new List<Direction>();
            if (!BackWay(dir, Direction.up) && CheckMove(map, GetCoordByDirection(Direction.up)))
                posibleDirections.Add(Direction.up);
            if (!BackWay(dir, Direction.down) && CheckMove(map, GetCoordByDirection(Direction.down)))
                posibleDirections.Add(Direction.down);
            if (!BackWay(dir, Direction.left) && CheckMove(map, GetCoordByDirection(Direction.left)))
                posibleDirections.Add(Direction.left);
            if (!BackWay(dir, Direction.right) && CheckMove(map, GetCoordByDirection(Direction.right)))
                posibleDirections.Add(Direction.right);

            return posibleDirections;
        }

        public void ChangeCoord(Map map, Coord newCoord, int step)
        {
            map.ArrangementOfObjects[newCoord.X, newCoord.Y] = step;
            Coord = newCoord;
        }

        public void ChangeCoord(Map map, Coord newCoord, int stay, int step)
        {
            map.ArrangementOfObjects[Coord.X, Coord.Y] = stay;
            map.ArrangementOfObjects[newCoord.X, newCoord.Y] = step;
            Coord = newCoord;
        }
    }
}