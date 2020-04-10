using Xunit;
using System.Linq;
using System;
using Odysseus.Framework.Mathematica;

namespace Odysseus.Framework.MathematicaTest
{
    public class GraphTest
    {
        private const string TestValue1 = "TestValue1";
        private const string TestValue2 = "TestValue2";

        private readonly Vertex<string> TestVertex1 = new Vertex<string>(TestValue1);
        private readonly Vertex<string> TestVertex2 = new Vertex<string>(TestValue2);

        private readonly Vertex<string> EmptyVertex = new Vertex<string>(string.Empty);
        private Edge<string> FeedbackEdge => new Edge<string>(EmptyVertex, EmptyVertex, 0);

        [Fact]
        public void Vertices_EmptyGraph_Zero()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            var result = sut.Vertices;

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Edges_EmptyGraph_Zero()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            var result = sut.Edges;

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void AddVertex_One_NumberOfVerticesOne()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(EmptyVertex);

            //Act
            var resultVertices = sut.Vertices;
            var resultVertex = sut.Vertices.First();

            //Assert
            Assert.Single(resultVertices);
            Assert.Equal(string.Empty, resultVertex.Value);
        }

        [Fact]
        public void AddVertex_TwoDifferentVertices_NumberOfVerticesTwo()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            //Act
            var resultCount = sut.Vertices.Count();
            var resultVertices = sut.Vertices.ToArray();

            //Assert
            Assert.Equal(2, resultCount);
            Assert.Equal(TestVertex1, resultVertices[0]);
            Assert.Equal(TestVertex2, resultVertices[1]);
        }

        [Fact]
        public void AddVertex_TheSameVertexTwice_SecondThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(TestVertex1);

            //Act
            Action result = () => sut.AddVertex(TestVertex1);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void DeleteVertex_VertexDoesNotExist_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            Action result = () => sut.RemoveVertex(TestVertex1);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void DeleteVertex_AddAndRemovedTheSameVertex_EmptyGraph()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            sut.AddVertex(TestVertex1);
            sut.RemoveVertex(TestVertex1);

            //Assert
            Assert.Empty(sut.Vertices);
        }


        [Fact]
        public void DeleteVertex_TwoVerticesAddedOneRemoved_SingleVertexGraph()
        {
            //Arrange
            var sut = new Graph<string>();
            
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            //Act
            sut.RemoveVertex(TestVertex1);
            var resultVertices = sut.Vertices;
            var resultOnlyVertex = sut.Vertices.First();

            //Assert
            Assert.Single(resultVertices);
            Assert.Equal(TestVertex2, resultOnlyVertex);
        }

        [Fact]
        public void AddEdge_AddEmptyEdgeToEmptyGraph_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            Action result = () => sut.AddEdge(FeedbackEdge);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void AddEdge_FeedbackEdge_SingleEdge()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(EmptyVertex);

            //Act
            sut.AddEdge(FeedbackEdge);

            //Assert
            Assert.Single(sut.Edges);
        }

        [Fact]
        public void AddEdge_AddEdgeToNonExistingVertices_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();
            var edge = new Edge<string>(TestVertex1, TestVertex2, 0);

            //Act
            Action result = () => sut.AddEdge(edge);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void AddEdge_OneVertexExistsSecondNot_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();
            var edge = new Edge<string>(TestVertex1, TestVertex2, 0);

            sut.AddVertex(TestVertex1);

            //Act
            Action result = () => sut.AddEdge(edge);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void AddEdge_TwoExistingVerticesAndAddedEdge_SingleEdge()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge = new Edge<string>(TestVertex1, TestVertex2, 0);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            //Act
            sut.AddEdge(testEdge);

            //Assert
            Assert.Single(sut.Edges);
        }

        [Fact]
        public void AddEdge_FeedbackLoopEdge_SingleEdge()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge = new Edge<string>(TestVertex1, TestVertex1, 0);
            
            sut.AddVertex(TestVertex1);

            //Act
            sut.AddEdge(testEdge);

            //Assert
            Assert.Single(sut.Edges);
        }

        [Fact]
        public void AddEdge_SetWeight_ValidWeight()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge = new Edge<string>(TestVertex1, TestVertex2, 2);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            //Act
            sut.AddEdge(testEdge);
            var result = sut.Edges.First();

            //Assert
            Assert.Equal(2, result.Weight);
        }

        [Fact]
        public void AddEdge_ValidEdge_ValidValues()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge = new Edge<string>(TestVertex1, TestVertex2, 2);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            //Act
            sut.AddEdge(testEdge);
            var result = sut.Edges.First();

            //Assert
            Assert.Equal(TestVertex1, result.Tail);
            Assert.Equal(TestVertex2, result.Head);
            Assert.Equal(2, result.Weight);
        }

        [Fact]
        public void AddEdge_AddTheSameEdgeTwice_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge = new Edge<string>(TestVertex1, TestVertex2, 2);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(testEdge);

            //Act
            Action result = () => sut.AddEdge(testEdge);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void AddEdge_EdgeWithSameCoordinatesButDifferentWeight_TwoEdgesAdded()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var testEdge2 = new Edge<string>(TestVertex1, TestVertex2, 5);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddEdge(testEdge1);

            //Act
            sut.AddEdge(testEdge2);
            var resultCount = sut.Edges.Count();
            var resultEdge = sut.Edges.ElementAt(1);

            //Assert
            Assert.Equal(2, resultCount);
            Assert.Equal(5, resultEdge.Weight);
            Assert.Equal(TestVertex1, resultEdge.Tail);
            Assert.Equal(TestVertex2, resultEdge.Head);
        }

        [Fact]
        public void AddEdge_EdgesAreDirected_TwoEdgesAdded()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var testEdge2 = new Edge<string>(TestVertex2, TestVertex1, 2);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddEdge(testEdge1);

            //Act
            sut.AddEdge(testEdge2);
            var resultCount = sut.Edges.Count();

            //Assert
            Assert.Equal(2, resultCount);
        }

        [Fact]
        public void AddEdge_ReversedEdgesWithDifferentWeight_TwoEdgesAdded()
        {
            //Arrange
            var sut = new Graph<string>();
            var testEdge1 = new Edge<string>(TestVertex1, TestVertex2, 2);
            var testEdge2 = new Edge<string>(TestVertex2, TestVertex1, 5);
            
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);
            sut.AddEdge(testEdge1);

            //Act
            sut.AddEdge(testEdge2);
            var resultCount = sut.Edges.Count();
            var resultEdge = sut.Edges.ElementAt(1);

            //Assert
            Assert.Equal(2, resultCount);
            Assert.Equal(5, resultEdge.Weight);
            Assert.Equal(TestVertex2, resultEdge.Tail);
            Assert.Equal(TestVertex1, resultEdge.Head);
        }

        [Fact]
        public void RemoveEdge_NonExistingEdge_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();

            //Act
            Action result = () => sut.RemoveEdge(FeedbackEdge);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void RemoveEdge_ExistingEdge_EmptyEdges()
        {
            //Arrange
            var sut = new Graph<string>();
            sut.AddVertex(EmptyVertex);
            sut.AddEdge(FeedbackEdge);

            //Act
            sut.RemoveEdge(FeedbackEdge);

            //Assert
            Assert.Empty(sut.Edges);
        }

        [Fact]
        public void RemoveEdge_TwoExistingEdgesRemoveOne_SingleEdge()
        {
            //Arrange
            var sut = new Graph<string>();

            sut.AddVertex(EmptyVertex);
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(FeedbackEdge);
            sut.AddEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Act
            sut.RemoveEdge(FeedbackEdge);

            //Assert
            Assert.Single(sut.Edges);
        }

        [Fact]
        public void RemoveEdge_TwoExistingEdgesRemoveOneNewObject_SingleEdge()
        {
            //Arrange
            var sut = new Graph<string>();

            sut.AddVertex(EmptyVertex);
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(FeedbackEdge);
            sut.AddEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Act
            sut.RemoveEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Assert
            Assert.Single(sut.Edges);
        }

        [Fact]
        public void RemoveEdge_TwoExistingEdgesRemoveOneInverted_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Graph<string>();

            sut.AddVertex(EmptyVertex);
            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(FeedbackEdge);
            sut.AddEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Act
            Action resultRemove = () => sut.RemoveEdge(new Edge<string>(TestVertex2, TestVertex1, 0));
            var resultCount = sut.Edges.Count();

            //Assert
            Assert.Throws<InvalidOperationException>(resultRemove);
            Assert.Equal(2, resultCount);
        }

        [Fact]
        public void ContainsSymmetric_ContainsTwoSymetricEdges_True()
        {
            //Arrange
            var sut = new Graph<string>();

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Act
            var result = sut.ContainsSymmetric(new Edge<string>(TestVertex2, TestVertex1, 0));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ContainsSymmetric_DoesNotContainTwoSymetricEdges_False()
        {
            //Arrange
            var sut = new Graph<string>();

            sut.AddVertex(TestVertex1);
            sut.AddVertex(TestVertex2);

            sut.AddEdge(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Act
            var result = sut.ContainsSymmetric(new Edge<string>(TestVertex1, TestVertex2, 0));

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveVertex_ConnectedGraph_RemoveTestVertexAndConnectedEdges()
        {
            //Arrange
            var sut = new Graph<string>();
            var vertexToRemove = TestVertex2;
            var vertex3 = new Vertex<string>("testValue3");
            var vertex4 = new Vertex<string>("testValue4");

            var edgeShouldBeRemoved1 = new Edge<string>(TestVertex1, vertexToRemove, 1);
            var edgeShouldBeRemoved2 = new Edge<string>(vertexToRemove, vertex3, 2);
            var edgeShouldBeRemoved3 = new Edge<string>(vertexToRemove, vertex4, 3);
            var edgeShouldStay = new Edge<string>(vertex3, vertex4, 4);

            sut.AddVertex(TestVertex1);
            sut.AddVertex(vertexToRemove);
            sut.AddVertex(vertex3);
            sut.AddVertex(vertex4);

            sut.AddEdge(edgeShouldBeRemoved1);
            sut.AddEdge(edgeShouldBeRemoved2);
            sut.AddEdge(edgeShouldBeRemoved3);
            sut.AddEdge(edgeShouldStay);

            //Act
            sut.RemoveVertex(vertexToRemove);
            var resultVerticesCount = sut.Vertices.Count();
            var resultEdgesCount = sut.Edges.Count();
            var resultEdge = sut.Edges.First();

            //Assert
            Assert.Equal(3, resultVerticesCount);
            Assert.Equal(1, resultEdgesCount);
            Assert.Equal(4, resultEdge.Weight);
            Assert.Equal(vertex3, resultEdge.Tail);
            Assert.Equal(vertex4, resultEdge.Head);
        }

        [Fact]
        public void FindAdjacentOf_UndirectedVertices_CorrectVertices()
        {
            //Arrange
            var sut = new Graph<string>();
            var vertex1 = TestVertex1;
            var vertex2 = new Vertex<string>("testValue3");
            var vertex3 = new Vertex<string>("testValue4");

            sut.AddVertex(vertex1);
            sut.AddVertex(vertex2);
            sut.AddVertex(vertex3);

            sut.AddUndirectedEdge(vertex1, vertex2, 0);
            sut.AddUndirectedEdge(vertex1, vertex3, 0);

            //Act
            var result1 = sut.FindAdjacentOf(vertex1);
            var result2 = sut.FindAdjacentOf(vertex2);
            var result3 = sut.FindAdjacentOf(vertex3);

            //Assert
            Assert.Equal(2, result1.Count());
            Assert.Equal(vertex2, result1.ElementAt(0));
            Assert.Equal(vertex3, result1.ElementAt(1));

            Assert.Single(result2);
            Assert.Equal(vertex1, result2.ElementAt(0));

            Assert.Single(result3);
            Assert.Equal(vertex1, result3.ElementAt(0));
        }

        [Fact]
        public void FindAdjacentOf_DirectedVertices_CorrectVertices()
        {
            //Arrange
            var sut = new Graph<string>();
            var vertex1 = TestVertex1;
            var vertex2 = new Vertex<string>("testValue3");
            var vertex3 = new Vertex<string>("testValue4");

            sut.AddVertex(vertex1);
            sut.AddVertex(vertex2);
            sut.AddVertex(vertex3);

            sut.AddDirectedEdge(vertex1, vertex2, 0);
            sut.AddDirectedEdge(vertex1, vertex3, 0);

            //Act
            var result1 = sut.FindAdjacentOf(vertex1);
            var result2 = sut.FindAdjacentOf(vertex2);
            var result3 = sut.FindAdjacentOf(vertex3);

            //Assert
            Assert.Equal(2, result1.Count());
            Assert.Equal(vertex2, result1.ElementAt(0));
            Assert.Equal(vertex3, result1.ElementAt(1));

            Assert.Empty(result2);
            Assert.Empty(result3);
        }
    }
}
