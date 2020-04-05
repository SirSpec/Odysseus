using Odysseus.DomainModel.MapGenerator;
using Xunit;

namespace Odysseus.DomainModelTests.MapGeneratorTest
{
    public class EdgeTest
    {
        private const string TestValue1 = "TestValue1";
        private const string TestValue2 = "TestValue2";
        private readonly Vertex<string> TestVertex1 = new Vertex<string>(TestValue1);
        private readonly Vertex<string> TestVertex2 = new Vertex<string>(TestValue2);

        [Fact]
        public void Equals_OneObject_True()
        {
            //Arrange
            var sut = new Edge<string>(TestVertex1, TestVertex2, 0);

            //Act
            var result = sut.Equals(sut);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_TwoTheSameObjects_True()
        {
            //Arrange
            var sut1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var sut2 = new Edge<string>(TestVertex1, TestVertex2, 2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_ObjectsWithReversedCoordinates_False()
        {
            //Arrange
            var sut1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var sut2 = new Edge<string>(TestVertex2, TestVertex1, 2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Equals_TwoDifferentObjects_False()
        {
            //Arrange
            var sut1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var sut2 = new Edge<string>(TestVertex2, new Vertex<string>("TestValue3"), 5);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}
