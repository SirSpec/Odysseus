using Xunit;
using Odysseus.DomainModel.MapGenerator;

namespace Odysseus.DomainModel.MapGeneratorTest
{
    public class VertexTest
    {
        private const string TestValue1 = "TestValue1";
        private const string TestValue2 = "TestValue2";

        [Fact]
        public void Equals_OneObject_True()
        {
            //Arrange
            var sut = new Vertex<string>(TestValue1);

            //Act
            var result = sut.Equals(sut);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_TwoObjectsWithTheSameValue_False()
        {
            //Arrange
            var sut1 = new Vertex<string>(TestValue1);
            var sut2 = new Vertex<string>(TestValue1);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Equals_DifferentVertices_False()
        {
            //Arrange
            var sut1 = new Vertex<string>(TestValue1);
            var sut2 = new Vertex<string>(TestValue2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Value_ValidVertex_ValidValue()
        {
            //Arrange
            var sut = new Vertex<string>(TestValue1);

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(TestValue1, result);
        }

        [Fact]
        public void ToString_TestValue1_TestValue1()
        {
            //Arrange
            var sut = new Vertex<string>(TestValue1);

            //Act
            var result = sut.ToString();

            //Assert
            Assert.Equal(TestValue1, result);
        }
    }
}
