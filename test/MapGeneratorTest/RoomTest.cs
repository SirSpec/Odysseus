using Theseus.MapGenerator;
using Xunit;

namespace Theseus.MapGeneratorTest
{
    public class RoomTest
    {
        [Fact]
        public void DefaultContructor_EmptyObject_EmptyProperties()
        {
            //Arrange
            var testObject = new Room();

            //Act
            var (topLeftLocation, size) = testObject;

            //Assert
            Assert.Equal((0, 0), (topLeftLocation.X, topLeftLocation.Y));
            Assert.Equal((0, 0), (size.Width, size.Height));
        }

        [Fact]
        public void ParameterizedConstructor_ValidValues_ValidProperties()
        {
            //Arrange
            var testObject = new Room(new Tile(1, 2), new Size(3, 4));

            //Act
            var (topLeftLocation, size) = testObject;

            //Assert
            Assert.Equal((1, 2), (topLeftLocation.X, topLeftLocation.Y));
            Assert.Equal((3, 4), (size.Width, size.Height));
        }

        [Fact]
        public void Equals_EmptyObjects_True()
        {
            //Arrange
            var testObject1 = new Room();
            var testObject2 = new Room();

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
            var testObject1 = new Room(new Tile(1, 2), new Size(3, 4));
            var testObject2 = new Room(new Tile(1, 2), new Size(3, 4));

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
            var testObject1 = new Room(new Tile(1, 2), new Size(3, 4));
            var testObject2 = new Room(new Tile(1, 2), new Size(3, 5));

            var testObject3 = new Room(new Tile(5, 2), new Size(3, 4));
            var testObject4 = new Room(new Tile(6, 2), new Size(3, 4));

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
