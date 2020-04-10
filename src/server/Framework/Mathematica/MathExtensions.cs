using System;

namespace Odysseus.Framework.Mathematica
{
    public static class MathExtensions
    {
        public static double Distance((double X, double Y) a, (double X, double Y) b)
        {
            var deltaX = a.X - b.X;
            var deltaY = a.Y - b.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static (double X, double Y) Midpoint((double X, double Y) a, (double X, double Y) b)
        {
            var x = (a.X + b.X) / 2;
            var y = (a.Y + a.Y) / 2;
            return (x, y);
        }
    }
}
