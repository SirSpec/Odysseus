using Odysseus.Framework.Randomizer;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct AdjacentRoomsGeneratorConfiguration
    {
        public int Iterations { get; }
        public int SurroundingIterations { get; }
        public ConstraintRange<int> RoomWidthRange { get; }
        public ConstraintRange<int> RoomHeightRange { get; }

        public AdjacentRoomsGeneratorConfiguration(
            int iterations,
            int surroundingIterations,
            ConstraintRange<int> roomWidthRange,
            ConstraintRange<int> roomHeightRange)
        {
            Iterations = iterations;
            SurroundingIterations = surroundingIterations;
            this.RoomWidthRange = roomWidthRange;
            this.RoomHeightRange = roomHeightRange;
        }
    }
}
