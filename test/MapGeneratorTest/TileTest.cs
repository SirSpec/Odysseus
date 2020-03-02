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
            var testObject = new Tile();

            //Act
            var (x, y) = testObject;

            //Assert
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var testObject = new Tile(1, 2);

            //Act
            var (x, y) = testObject;

            //Assert
            Assert.Equal(1, x);
            Assert.Equal(2, y);
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var testObject1 = new Tile();
            var testObject2 = new Tile();

            //Act
            var result1 = testObject1.Equals(testObject1);
            var result2 = testObject1.Equals(testObject2);
            var result3 = testObject2.Equals(testObject1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_SameParameters_True()
        {
            //Arrange
            var testObject1 = new Tile(1, 2);
            var testObject2 = new Tile(1, 2);

            //Act
            var result1 = testObject1.Equals(testObject1);
            var result2 = testObject1.Equals(testObject2);
            var result3 = testObject2.Equals(testObject1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_DifferentParameters_False()
        {
            //Arrange
            var testObject1 = new Tile(1, 3);
            var testObject2 = new Tile(1, 2);

            var testObject3 = new Tile(1, 2);
            var testObject4 = new Tile(2, 2);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            var result3 = testObject3.Equals(testObject4);
            var result4 = testObject4.Equals(testObject3);

            //Assert
            Assert.False(result1);
            Assert.False(result2);

            Assert.False(result3);
            Assert.False(result4);
        }
    }
}
