using Theseus.MapGenerator;
using Xunit;

namespace Theseus.MapGeneratorTest
{
    public class CorridorTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var testObject = new Corridor();

            //Act
            var (start, end) = testObject.Vector;

            //Assert
            Assert.Equal((0, 0), (start.X, start.Y));
            Assert.Equal((0, 0), (end.X, end.Y));
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var testObject = new Corridor(new Vector(new Tile(1, 2), new Tile(3, 4)));

            //Act
            var (start, end) = testObject.Vector;

            //Assert
            Assert.Equal((1, 2), (start.X, start.Y));
            Assert.Equal((3, 4), (end.X, end.Y));
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var testObject1 = new Corridor();
            var testObject2 = new Corridor();

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
            var testObject1 = new Corridor(new Vector(new Tile(1, 2), new Tile(3, 4)));
            var testObject2 = new Corridor(new Vector(new Tile(1, 2), new Tile(3, 4)));

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
            var testObject1 = new Corridor(new Vector(new Tile(1, 2), new Tile(3, 4)));
            var testObject2 = new Corridor(new Vector(new Tile(1, 2), new Tile(3, 5)));

            var testObject3 = new Corridor(new Vector(new Tile(5, 2), new Tile(3, 4)));
            var testObject4 = new Corridor(new Vector(new Tile(6, 2), new Tile(3, 4)));

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
