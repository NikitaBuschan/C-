using NUnit.Framework;

namespace Pacman.Tests
{
    public class MapTest
    {
        public int[,] map = new int[,]
        {
            { 0,0,0 }
        };
    }

    public delegate void Moves(MapTest map);

    //[TestFixture]
    public class GameTest
    {
        private static MapTest map = new MapTest();
        public static RedSH redShadow = new RedSH(map, new Coord(0,0));
        public static GreenSH greenShadow = new GreenSH(map, new Coord(0, 2));
        public Moves move;

        public GameTest()
        {
            map.map[0, 1] = 3;
            move += redShadow.Move;
            move += greenShadow.Move;
            redShadow.objectDirection = Direction.right;
            greenShadow.objectDirection = Direction.left;
        }

        [Test]
        public void MakeStep()
        {
            Assert.AreEqual(map.map[0, 0], 6);
            Assert.AreEqual(map.map[0, 1], 3);
            Assert.AreEqual(map.map[0, 2], 7);
            move(map);
            // Red Shadow position == 0,1
            Assert.AreEqual(redShadow.Coord.X, 0);
            Assert.AreEqual(redShadow.Coord.Y, 1);
            // Green Shadow position == 0,1
            Assert.AreEqual(greenShadow.Coord.X, 0);
            Assert.AreEqual(greenShadow.Coord.Y, 1);
            move(map);
            // Red Shadow position == 0,2
            Assert.AreEqual(redShadow.Coord.X, 0);
            Assert.AreEqual(redShadow.Coord.Y, 2);
            // Green Shadow position == 0,0
            Assert.AreEqual(greenShadow.Coord.X, 0);
            Assert.AreEqual(greenShadow.Coord.Y, 0);

            Assert.AreEqual(map.map[0, 0], 7);
            Assert.AreEqual(map.map[0, 1], 3);
            Assert.AreEqual(map.map[0, 2], 6);
        }
    }
}