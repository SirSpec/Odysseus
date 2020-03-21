using Theseus.MapGenerator;
using Xunit;

namespace Theseus.MapGeneratorTest
{
    public class TileTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new Tile();

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var sut = new Tile(1, 2);

            //Act
            var (x, y) = sut;

            //Assert
            Assert.Equal(1, x);
            Assert.Equal(2, y);
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var sut1 = new Tile();
            var sut2 = new Tile();

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
            var sut1 = new Tile(1, 2);
            var sut2 = new Tile(1, 2);

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
            var sut1 = new Tile(1, 3);
            var sut2 = new Tile(1, 2);

            var sut3 = new Tile(1, 2);
            var sut4 = new Tile(2, 2);

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
    }
}
