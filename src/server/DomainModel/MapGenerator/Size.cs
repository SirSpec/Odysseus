using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Size : IEquatable<Size>
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height) => (Width, Height) = (width, height);
        public void Deconstruct(out int width, out int height) => (width, height) = (Width, Height);

        public bool Equals(Size other) => Width == other.Width && Height == other.Height;
    }
}
