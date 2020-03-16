using Theseus.MapGenerator;
using Xunit;

namespace Theseus.MapGeneratorTest
{
    public class EdgeTest
    {
        [Fact]
        public void Equals_OneObject_True()
        {
            //Arrange
            var testObject = new Edge();

            //Act
            var result = testObject.Equals(testObject);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_TwoTheSameObjects_True()
        {
            //Arrange
            var testObject1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testObject2 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_TheSameObjectsWithReversedCoordinates_True()
        {
            //Arrange
            var testObject1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testObject2 = new Edge((new Vertex(2, 3), new Vertex(1, 2)), 2);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_TwoDifferentObjects_False()
        {
            //Arrange
            var testObject1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testObject2 = new Edge((new Vertex(2, 3), new Vertex(5, 2)), 5);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}
