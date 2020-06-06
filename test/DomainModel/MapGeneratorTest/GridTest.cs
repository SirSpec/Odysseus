using Odysseus.DomainModel.MapGenerator;
using System;
using System.Linq;
using Xunit;

namespace Odysseus.DomainModel.MapGeneratorTest
{
    public class GridTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new Grid();

            //Act
            var result = sut.Tiles.Count();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_ValidTile_IncreasedCount()
        {
            //Arrange
            var sut = new Grid();

            //Act
            sut.Add(new Tile());
            var result = sut.Tiles.Count();

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_TheSameTileTwice_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Grid();
            sut.Add(new Tile());

            //Act
            Action action = () => sut.Add(new Tile());

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Neighbors_SingleTile_Empty()
        {
            //Arrange
            var sut = new Grid();
            var testTile = new Tile();

            //Act
            sut.Add(testTile);
            var result = sut.Neighbors(testTile);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Neighbors_ThreeValidNeighbors_TwoNeighbors()
        {
            //Arrange
            var sut = new Grid();
            var testTileA = new Tile(0, 0);
            var testTileB = new Tile(1, 0);
            var testTileC = new Tile(-1, 0);

            //Act
            sut.Add(testTileA);
            sut.Add(testTileB);
            sut.Add(testTileC);
            var result = sut.Neighbors(testTileA).Count();

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Neighbors_ThreeValidNeighborsAndOneInvalid_TwoNeighbors()
        {
            //Arrange
            var sut = new Grid();
            var testTileA = new Tile(0, 0);
            var testTileB = new Tile(1, 0);
            var testTileC = new Tile(-1, 0);
            var testTileD = new Tile(2, 0);

            //Act
            sut.Add(testTileA);
            sut.Add(testTileB);
            sut.Add(testTileC);
            sut.Add(testTileD);
            var result = sut.Neighbors(testTileA).Count();

            //Assert
            Assert.Equal(2, result);
        }
    }
}
