using System;

namespace Theseus.MapGenerator
{
    public class Calculator
    {
        public static double Distance(Vertex a, Vertex b)
        {
            var deltaX = a.X - b.X;
            var deltaY = a.Y - b.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
