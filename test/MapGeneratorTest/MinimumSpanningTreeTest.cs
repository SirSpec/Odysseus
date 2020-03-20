using Xunit;
using Theseus.MapGenerator;

namespace Theseus.MapGeneratorTest
{
    public class MinimumSpanningTreeTest
    {
        [Fact]
        public void MinimumSpanningTree_EmptyGraph_EmptyGraph()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            var result = new MinimumSpanningTree(testObject);

            //Assert
            Assert.True(result.IsEmpty);
        }

        [Fact]
        public void MinimumSpanningTree_ValidGraph_ValidMinimumSpanningTree()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex(1, 2));
            testObject.TryAddVertex(new Vertex(2, 3));
            testObject.TryAddVertex(new Vertex(3, 4));
            testObject.TryAddVertex(new Vertex(4, 56));
            testObject.TryAddVertex(new Vertex(5, 33));

            testObject.TryAddUndirectedEdge(new Vertex(1, 2), new Vertex(2, 3), 1);
            testObject.TryAddUndirectedEdge(new Vertex(1, 2), new Vertex(3, 4), 2);
            testObject.TryAddUndirectedEdge(new Vertex(2, 3), new Vertex(3, 4), 3);
            testObject.TryAddUndirectedEdge(new Vertex(4, 56), new Vertex(5, 33), 135);
            testObject.TryAddUndirectedEdge(new Vertex(4, 56), new Vertex(5, 33), 13);
            testObject.TryAddUndirectedEdge(new Vertex(2, 3), new Vertex(5, 33), 5);

            //Act
            var result = new MinimumSpanningTree(testObject);

            //Assert
            foreach (var vertex in result.Vertices)
            {
                Assert.Contains(vertex, testObject.Vertices);
            }

            foreach (var edge in result.Edges)
            {
                Assert.Contains(edge, testObject.Edges);
            }
        }
    }
}