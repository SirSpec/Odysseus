using Xunit;
using Theseus.MapGenerator;

namespace Theseus.MapGeneratorTest
{
    public class VertexTest
    {
        [Fact]
        public void Equals_OneObject_True()
        {
            //Arrange
            var testObject = new Vertex(0, 0);

            //Act
            var result = testObject.Equals(testObject);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_TwoTheSameObjects_True()
        {
            //Arrange
            var testObject1 = new Vertex(0, 0);
            var testObject2 = new Vertex(0, 0);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_DifferentVertices_False()
        {
            //Arrange
            var testObject1 = new Vertex(1, 2);
            var testObject2 = new Vertex(3, 4);

            //Act
            var result1 = testObject1.Equals(testObject2);
            var result2 = testObject2.Equals(testObject1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Deconstruct_OneValidVertices_ValidCoordinates()
        {
            //Arrange
            var testObject = new Vertex(1, 2);

            //Act
            var (x, y) = testObject;

            //Assert
            Assert.Equal((1, 2), (x, y));
        }
    }
}
