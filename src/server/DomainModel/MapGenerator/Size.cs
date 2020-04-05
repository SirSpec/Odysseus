using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Size : IEquatable<Size>
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException($"Arguments {nameof(width)}({width}), {nameof(height)}({height}) cannot be less than 0.");

            (Width, Height) = (width, height);
        }
        public void Deconstruct(out int width, out int height) => (width, height) = (Width, Height);

        public bool Equals(Size other) => Width == other.Width && Height == other.Height;
    }
}
