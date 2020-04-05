using Odysseus.DomainModel.MapGenerator;
using Xunit;

namespace Odysseus.DomainModelTests.MapGeneratorTest
{
    public class VectorTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var sut = new Vector();

            //Act
            var (start, end) = sut;

            //Assert
            Assert.Equal((0, 0), (start.X, start.Y));
            Assert.Equal((0, 0), (end.X, end.Y));
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var sut = new Vector(new Tile(1, 2), new Tile(3, 4));

            //Act
            var (start, end) = sut;

            //Assert
            Assert.Equal((1, 2), (start.X, start.Y));
            Assert.Equal((3, 4), (end.X, end.Y));
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var sut1 = new Vector();
            var sut2 = new Vector();

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
            var sut1 = new Vector(new Tile(1, 2), new Tile(3, 4));
            var sut2 = new Vector(new Tile(1, 2), new Tile(3, 4));

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
            var sut1 = new Vector(new Tile(1, 2), new Tile(3, 4));
            var sut2 = new Vector(new Tile(1, 2), new Tile(3, 5));

            var sut3 = new Vector(new Tile(5, 2), new Tile(3, 4));
            var sut4 = new Vector(new Tile(6, 2), new Tile(3, 4));

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
