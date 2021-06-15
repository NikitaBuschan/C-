using Pacman.Shadows;
using System.Collections.Generic;

namespace Pacman
{
    public class Create
    {
        public static List<Unit> listOfShadows() =>
            new List<Unit>()
            {
                Create.Red(),
                Create.Blue(),
                Create.Cyan(),
                Create.Green()
            };

        public static Unit Red() => new RedShadow(14, 15);

        public static Unit Blue() => new BlueShadow(14, 14);

        public static Unit Cyan() => new CyanShadow(14, 13);

        public static Unit Green() => new GreenShadow(14, 12);
    }
}