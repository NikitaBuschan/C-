using System;
using System.Collections.Generic;

namespace Pacman.Shadows
{
    public class CyanShadow : Unit
    {
        RememberStepObject eat = null;

        public CyanShadow(int x, int y)
        {
            UnitNumber = 8;
            Coord = new Coord(x, y);
            NextCoord = new Coord(x, y);
            Sprite = new Sprite(ConsoleColor.Cyan, "%");
        }

        public override void Move(Map map)
        {
            Random random = new Random();
            List<Direction> posibleDir = ChooseWey(map, objectDirection);
            objectDirection = posibleDir[random.Next(0, posibleDir.Count)];

            NextCoord = GetCoordByDirection(objectDirection);

            // Если мы наступали в пустое поле
            if (eat == null)
            {
                if (NextCoord == new Coord(14, 0))
                    NextCoord = new Coord(14, 27);
                else if (NextCoord == new Coord(14, 27))
                    NextCoord = new Coord(14, 0);
                else if (map[NextCoord] == 3)
                    eat = new RememberStepObject(NextCoord, 3, Point.Sprite);
                else if (map[NextCoord] == 4)
                    eat = new RememberStepObject(NextCoord, 4, SuperPoint.Sprite);
                else
                {
                    foreach (var item in Game.ghosts)
                    {
                        if (NextCoord == item.Coord)
                        {
                            Draw.DrawSymbol(Coord, new Sprite(0, ""));
                            eat = new RememberStepObject(item.Coord, item.UnitNumber);
                            ChangeCoord(map, NextCoord, UnitNumber);
                            return;
                        }
                    }
                }
                Draw.RedrowUnit(this, null);
                ChangeCoord(map, NextCoord, 0, UnitNumber);
            }
            // Если наступали в поле, в котором уже кто-то был
            else if (eat != null)
            {
                if (map[NextCoord] == 3)
                {
                    foreach (var item in Game.ghosts)
                    {
                        if (item.UnitNumber == eat.Number && item.GetType() != this.GetType())
                        {
                            Draw.DrawSymbol(NextCoord, Sprite);
                            eat = new RememberStepObject(NextCoord, 3, Point.Sprite);
                            ChangeCoord(map, NextCoord, UnitNumber);
                            return;
                        }
                    }
                    Draw.RedrowUnit(this, eat);
                    ChangeCoord(map, NextCoord, eat.Number, UnitNumber);
                    eat = new RememberStepObject(NextCoord, 3, Point.Sprite);

                }
                else if (map[NextCoord] == 4)
                {
                    foreach (var item in Game.ghosts)
                    {
                        if (item.UnitNumber == eat.Number && item.GetType() != this.GetType())
                        {
                            Draw.DrawSymbol(NextCoord, Sprite);
                            eat = new RememberStepObject(NextCoord, 4, SuperPoint.Sprite);
                            ChangeCoord(map, NextCoord, UnitNumber);
                            return;
                        }
                    }
                    Draw.RedrowUnit(this, eat);
                    ChangeCoord(map, NextCoord, eat.Number, UnitNumber);
                    eat = new RememberStepObject(NextCoord, 4, SuperPoint.Sprite);
                }
                else
                {
                    foreach (var item in Game.ghosts)
                    {
                        if (NextCoord == item.Coord && item.GetType() != this.GetType())
                        {
                            foreach (var gh in Game.ghosts)
                            {
                                if (gh.UnitNumber == eat.Number && gh.GetType() != this.GetType())
                                {
                                    eat = new RememberStepObject(NextCoord, gh.UnitNumber);
                                    ChangeCoord(map, NextCoord, UnitNumber);
                                    return;
                                }
                            }
                            map[Coord] = eat.Number;
                            Draw.DrawSymbol(Coord, eat.Sprite);
                            eat = new RememberStepObject(NextCoord, item.UnitNumber);
                            ChangeCoord(map, NextCoord, UnitNumber);
                            return;
                        }
                    }
                    Draw.RedrowUnit(this, eat);
                    ChangeCoord(map, NextCoord, eat.Number, UnitNumber);
                    eat = null;
                }
            }
        }

        public override void Eaten()
        {
            if (Coord == Game.pacman.Coord && Game.fright == false)
            {
                Game.lives--;
                Console.ForegroundColor = ConsoleColor.White;
                Draw.Lives();
            }
        }

        public override void Eat() => Coord = Create.Cyan().Coord;

        public override void Exit()
        {
            var temp = new Coord(0, 0);
            if (Coord == new Coord(14, 13))
            {
                temp = new Coord(13, 13);
                Draw.RedrowUnitToNewPosition(this, temp);
                Coord = temp;
            }
            else if (Coord == new Coord(13, 13))
            {
                temp = new Coord(13, 14);
                Draw.RedrowUnitToNewPosition(this, temp);
                Coord = temp;
            }
            else if (Coord == new Coord(13, 14))
            {
                temp = new Coord(12, 14);
                Draw.RedrowUnitToNewPosition(this, temp);
                Coord = temp;
            }
            else if (Coord == new Coord(12, 14))
            {
                temp = new Coord(11, 14);
                Draw.RedrowUnitToNewPosition(this, temp);
                Coord = temp;

                foreach (var item in Game.ghosts)
                {
                    if (item is CyanShadow)
                    {
                        Game.move += item.Move;
                        Game.exit -= item.Exit;
                    }
                }
            }
        }
    }
}