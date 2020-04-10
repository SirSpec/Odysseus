using Odysseus.Framework.Mathematica;
using Xunit;

namespace Odysseus.Framework.MathematicaTest
{
    public class MinimumSpanningTreeTest
    {
        private const string TestValue1 = "TestValue1";
        private const string TestValue2 = "TestValue2";
        private const string TestValue3 = "TestValue3";
        private const string TestValue4 = "TestValue4";
        private const string TestValue5 = "TestValue5";

        private readonly Vertex<string> TestVertex1 = new Vertex<string>(TestValue1);
        private readonly Vertex<string> TestVertex2 = new Vertex<string>(TestValue2);
        private readonly Vertex<string> TestVertex3 = new Vertex<string>(TestValue3);
        private readonly Vertex<string> TestVertex4 = new Vertex<string>(TestValue4);
        private readonly Vertex<string> TestVertex5 = new Vertex<string>(TestValue5);

        [Fact]
        public void MinimumSpanningTree_EmptyGraph_EmptyGraph()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            var result = new MinimumSpanningTree<string>(sut);

            //Assert
            Assert.True(result.IsEmpty);
        }

        [Fact]
        public void MinimumSpanningTree_UndirectedGraph_ValidMinimumSpanningTree()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddVertex(TestVertex3);
            sut.AddVertex(TestVertex4);
            sut.AddVertex(TestVertex5);

            sut.AddUndirectedEdge(TestVertex1, TestVertex2, 1);
            sut.AddUndirectedEdge(TestVertex1, TestVertex3, 2);
            sut.AddUndirectedEdge(TestVertex2, TestVertex3, 3);
            sut.AddUndirectedEdge(TestVertex4, TestVertex5, 135);
            sut.AddUndirectedEdge(TestVertex4, TestVertex5, 13);
            sut.AddUndirectedEdge(TestVertex2, TestVertex5, 5);

            //Act
            var result = new MinimumSpanningTree<string>(sut);

            //Assert
            foreach (var vertex in sut.Vertices)
            {
                Assert.Contains(vertex, result.Vertices);
            }

            foreach (var edge in result.Edges)
            {
                Assert.Contains(edge, sut.Edges);
            }
        }

        [Fact]
        public void MinimumSpanningTree_DirectedGraph_ValidMinimumSpanningTree()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddVertex(TestVertex3);
            sut.AddVertex(TestVertex4);
            sut.AddVertex(TestVertex5);

            sut.AddDirectedEdge(TestVertex1, TestVertex2, 1);
            sut.AddDirectedEdge(TestVertex1, TestVertex3, 2);
            sut.AddDirectedEdge(TestVertex2, TestVertex3, 3);
            sut.AddDirectedEdge(TestVertex4, TestVertex5, 135);
            sut.AddDirectedEdge(TestVertex4, TestVertex5, 13);
            sut.AddDirectedEdge(TestVertex2, TestVertex5, 5);

            //Act
            var result = new MinimumSpanningTree<string>(sut);

            //Assert
            foreach (var vertex in sut.Vertices)
            {
                Assert.Contains(vertex, result.Vertices);
            }

            foreach (var edge in result.Edges)
            {
                Assert.Contains(edge, sut.Edges);
            }
        }

        [Fact]
        public void MinimumSpanningTree_TwoUnconnectedGraphs_ValidMinimumSpanningForest()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddVertex(TestVertex3);
            sut.AddVertex(TestVertex4);
            sut.AddVertex(TestVertex5);

            sut.AddDirectedEdge(TestVertex1, TestVertex2, 1);
            sut.AddDirectedEdge(TestVertex1, TestVertex3, 2);
            sut.AddDirectedEdge(TestVertex2, TestVertex3, 3);

            sut.AddDirectedEdge(TestVertex5, TestVertex4, 135);
            sut.AddDirectedEdge(TestVertex4, TestVertex5, 13);

            //Act
            var result = new MinimumSpanningTree<string>(sut);

            //Assert
            foreach (var vertex in sut.Vertices)
            {
                Assert.Contains(vertex, result.Vertices);
            }

            foreach (var edge in result.Edges)
            {
                Assert.Contains(edge, sut.Edges);
            }
        }
    }
}