using Odysseus.DomainModel.MapGenerator;
using Odysseus.Framework.Randomizer;
using System.Collections.Generic;

namespace Odysseus.DomainServices.MapGenerator
{
    public class AdjacentRoomsGenerator : IRoomsGenerator
    {
        private readonly AdjacentRoomsGeneratorConfiguration configuration;

        public AdjacentRoomsGenerator(AdjacentRoomsGeneratorConfiguration configuration) =>
            this.configuration = configuration;

        public IEnumerable<Room> Generate()
        {
            var seed = GenerateRoomAt(new Tile());
            var set = new NonOverlappingRoomsSet();
            set.TryAdd(seed);

            for (int i = 0; i < configuration.Iterations; i++)
                for (int j = 0; j < configuration.SurroundingIterations; j++)
                    foreach (var newRoom in Generate(set[i]))
                        set.TryAdd(newRoom);

            return set.Rooms;
        }

        private IEnumerable<Room> Generate(Room room)
        {
            yield return GenerateRoomOnTheLeftSide(room);
            yield return GenerateRoomAtTheTop(room);
            yield return GenerateRoomOnTheRightSide(room);
            yield return GenerateRoomAtTheBottom(room);
        }

        private Room GenerateRoomOnTheLeftSide(Room seedRoom)
        {
            var newRoom = GenerateRoomAt(seedRoom.TopLeft);
            var offset = Offset.LeftBy(newRoom.Size.Width)
                .Then(Offset.BottomBy(Random(seedRoom.Size.Height)));

            return newRoom.OffsetBy(offset);
        }

        private Room GenerateRoomAtTheTop(Room seedRoom)
        {
            var newRoom = GenerateRoomAt(seedRoom.TopLeft);
            var offset = Offset.TopBy(newRoom.Size.Height)
                .Then(Offset.RightBy(Random(seedRoom.Size.Width)));

            return newRoom.OffsetBy(offset);
        }

        private Room GenerateRoomOnTheRightSide(Room seedRoom)
        {
            var offset = Offset.RightBy(seedRoom.Size.Width)
                .Then(Offset.BottomBy(Random(seedRoom.Size.Height)));

            return GenerateRoomAt(seedRoom.TopLeft).OffsetBy(offset);
        }

        private Room GenerateRoomAtTheBottom(Room seedRoom)
        {
            var offset = Offset.BottomBy(seedRoom.Size.Height)
                .Then(Offset.RightBy(Random(seedRoom.Size.Width)));

            return GenerateRoomAt(seedRoom.TopLeft).OffsetBy(offset);
        }

        private Room GenerateRoomAt(Tile topLeft) =>
            new Room(topLeft, GenerateSize());

        private Size GenerateSize()
        {
            int width = Randomizer.RandomInteger(configuration.RoomWidthRange.Min, configuration.RoomWidthRange.Max);
            int height = Randomizer.RandomInteger(configuration.RoomHeightRange.Min, configuration.RoomHeightRange.Max);
            return new Size(width, height);
        }

        private int Random(int max) => Randomizer.RandomInteger(0, max);
    }
}