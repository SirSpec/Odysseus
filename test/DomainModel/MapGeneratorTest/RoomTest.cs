using System;
using Odysseus.DomainModel.MapGenerator;
using Xunit;

namespace Odysseus.DomainModel.MapGeneratorTest
{
    public class RoomTest
    {
        [Fact]
        public void Contructor_InvalidCoordinates_ArgumentException()
        {
            //Arrange
            Action sut = () => new Room(new Tile(0, 0), new Tile(-1, 1));
            
            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var sut = new Room(new Tile(1, 2), new Tile(3, -4));

            //Act
            var (topLeft, bottomRight, size) = sut;

            //Assert
            Assert.Equal((1, 2), (topLeft.X, topLeft.Y));
            Assert.Equal((3, -4), (bottomRight.X, bottomRight.Y));
        }

        [Fact]
        public void Size_ValidValues_SizeRepresentsNumberOfTiles()
        {
            //Arrange
            var sutZero = new Room(new Tile(0, 0), new Tile(0, 0));
            var sut1 = new Room(new Tile(0, 0), new Tile(1, -1));
            var sut2 = new Room(new Tile(4, 4), new Tile(6, -3));
            var sut3 = new Room(new Tile(-5, -5), new Tile(-3, -8));
            var sut4 = new Room(new Tile(1, -2), new Tile(2, -4));
            var sut5 = new Room(new Tile(-5, 2), new Tile(5, -1));

            //Act
            var sizeZero = sutZero.Size;
            var size1 = sut1.Size;
            var size2 = sut2.Size;
            var size3 = sut3.Size;
            var size4 = sut4.Size;
            var size5 = sut5.Size;

            //Assert
            Assert.Equal((1, 1), (sizeZero.Width, sizeZero.Height));
            Assert.Equal((2, 2), (size1.Width, size1.Height));
            Assert.Equal((3, 8), (size2.Width, size2.Height));
            Assert.Equal((3, 4), (size3.Width, size3.Height));
            Assert.Equal((2, 3), (size4.Width, size4.Height));
            Assert.Equal((11, 4), (size5.Width, size5.Height));
        }

        [Fact]
        public void Equals_ZeroObjects_True()
        {
            //Arrange
            var sut1 = new Room(new Tile(0, 0), new Tile(0, 0));
            var sut2 = new Room(new Tile(0, 0), new Tile(0, 0));

            //Act
            var result1 = sut1.Equals(sut1);
            var result2 = sut1.Equals(sut2);
            var result3 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_SameParameters_True()
        {
            //Arrange
            var sut1 = new Room(new Tile(1, 2), new Tile(3, -4));
            var sut2 = new Room(new Tile(1, 2), new Tile(3, -4));

            //Act
            var result1 = sut1.Equals(sut1);
            var result2 = sut1.Equals(sut2);
            var result3 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_DifferentParameters_False()
        {
            //Arrange
            var sut1 = new Room(new Tile(1, 2), new Tile(3, -4));
            var sut2 = new Room(new Tile(1, 2), new Tile(3, -5));

            var sut3 = new Room(new Tile(5, 2), new Tile(7, -4));
            var sut4 = new Room(new Tile(6, 2), new Tile(7, -4));

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            var result3 = sut3.Equals(sut4);
            var result4 = sut4.Equals(sut3);

            //Assert
            Assert.False(result1);
            Assert.False(result2);

            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void OffsetBy_OffsetLeftTopBy2_ValidRoom()
        {
            //Arrange
            var sut1 = new Room(new Tile(1, 2), new Tile(3, -4)); ;
            var sut2 = new Offset(-2, 2);

            //Act
            var (topLeft, bottomRight, _) = sut1.OffsetBy(sut2);

            //Assert
            Assert.Equal((-1, 4), (topLeft.X, topLeft.Y));
            Assert.Equal((1, -2), (bottomRight.X, bottomRight.Y));
        }

        [Fact]
        public void OffsetBy_OffsetRightBottomBy2_ValidRoom()
        {
            //Arrange
            var sut1 = new Room(new Tile(1, 2), new Tile(3, -4)); ;
            var sut2 = new Offset(2, -2);

            //Act
            var (topLeft, bottomRight, _) = sut1.OffsetBy(sut2);

            //Assert
            Assert.Equal((3, 0), (topLeft.X, topLeft.Y));
            Assert.Equal((5, -6), (bottomRight.X, bottomRight.Y));
        }

        [Fact]
        public void OffsetBy_OffsetZero_TheSameRoom()
        {
            //Arrange
            var sut1 = new Room(new Tile(1, 2), new Tile(3, -4)); ;
            var sut2 = new Offset();

            //Act
            var (topLeft, bottomRight, _) = sut1.OffsetBy(sut2);

            //Assert
            Assert.Equal((1, 2), (topLeft.X, topLeft.Y));
            Assert.Equal((3, -4), (bottomRight.X, bottomRight.Y));
        }
    }
}
