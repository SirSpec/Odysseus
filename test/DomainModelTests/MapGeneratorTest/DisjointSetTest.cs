using Xunit;
using Odysseus.DomainModel.MapGenerator;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModelTests.MapGeneratorTest
{
    public class DisjointSetTest
    {
        private const string TestValue1 = "TestValue1";
        private const string TestValue2 = "TestValue2";
        private const string TestValue3 = "TestValue3";

        private readonly IList<Vertex<string>> TestObjects = new Vertex<string>[]
        {
            new Vertex<string>(TestValue1),
            new Vertex<string>(TestValue2),
            new Vertex<string>(TestValue3)
        };

        [Fact]
        public void FindRoot_InitialSet_EachElementInDifferentSubset()
        {
            //Arrange
            var sut = new DisjointSet<Vertex<string>>(TestObjects);

            //Act
            var results = TestObjects.Select(sut.FindRoot);

            //Assert
            foreach (var testObject in TestObjects)
            {
                Assert.Contains(testObject, results);
            }
        }

        [Fact]
        public void Union_UnionOfTwoElements_TwoElelemntInTheSameSubset()
        {
            //Arrange
            var sut = new DisjointSet<Vertex<string>>(TestObjects);

            //Act
            sut.Union(TestObjects[0], TestObjects[1]);

            var resultRoot1 = sut.FindRoot(TestObjects[0]);
            var resultRoot2 = sut.FindRoot(TestObjects[1]);
            var equalsResult = resultRoot1.Equals(resultRoot2);

            //Assert
            Assert.True(equalsResult);
            Assert.Equal(TestObjects[1], resultRoot1);
            Assert.Equal(TestObjects[1], resultRoot2);
        }

        [Fact]
        public void HaveTheSameRoot_UnionOfTwoElements_True()
        {
            //Arrange
            var sut = new DisjointSet<Vertex<string>>(TestObjects);

            //Act
            sut.Union(TestObjects[0], TestObjects[1]);
            var result = sut.HaveTheSameRoot(TestObjects[0], TestObjects[1]);

            //Assert
            Assert.True(result);
        }
    }
}