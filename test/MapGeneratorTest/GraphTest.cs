using Xunit;
using System.Linq;
using Theseus.MapGenerator;

namespace Theseus.MapGeneratorTest
{
    public class GraphTest
    {
        [Fact]
        public void Vertices_EmptyGraph_Zero()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            var result = testObject.Vertices.Count();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Edges_EmptyGraph_Zero()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            var result = testObject.Edges;

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TryAddVertex_One_NumberOfVerticesOne()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());

            //Act
            var resultVertices = testObject.Vertices;
            var resultVertex = testObject.Vertices.First();

            //Assert
            Assert.Single(resultVertices);
            Assert.Equal((0, 0), (resultVertex.X, resultVertex.Y));
        }

        [Fact]
        public void TryAddVertex_TwoDifferentVertices_NumberOfVerticesTwo()
        {
            //Arrange
            var testObject = new Graph();
            var testVertex1 = new Vertex(1, 2);
            var testVertex2 = new Vertex(2, 3);
            testObject.TryAddVertex(testVertex1);
            testObject.TryAddVertex(testVertex2);

            //Act
            var resultCount = testObject.Vertices.Count();
            var resultVertices = testObject.Vertices.ToArray();

            //Assert
            Assert.Equal(2, resultCount);
            Assert.Equal(testVertex1, resultVertices[0]);
            Assert.Equal(testVertex2, resultVertices[1]);
        }

        [Fact]
        public void TryAddVertex_TheSameCoordinates_SecondVertexNotAdded()
        {
            //Arrange
            var testObject = new Graph();
            var testVertex1 = new Vertex(1, 2);
            var testVertex2 = new Vertex(1, 2);

            //Act
            var resultAdd1 = testObject.TryAddVertex(testVertex1);
            var resultAdd2 = testObject.TryAddVertex(testVertex2);
            var resultVertices = testObject.Vertices;

            //Assert
            Assert.True(resultAdd1);
            Assert.False(resultAdd2);
            Assert.Single(resultVertices);
        }

        [Fact]
        public void TryDeleteVertex_VertexDoesNotExist_False()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            var result = testObject.TryRemoveVertex(new Vertex(1, 2));

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TryDeleteVertex_VertexExistsAndRemoved_True()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            testObject.TryAddVertex(new Vertex(1, 2));
            var result = testObject.TryRemoveVertex(new Vertex(1, 2));

            //Assert
            Assert.True(result);
        }


        [Fact]
        public void TryDeleteVertex_TwoVerticesAddedOneRemoved_TrueAndOneLeft()
        {
            //Arrange
            var testObject = new Graph();
            var vertex1 = new Vertex(1, 2);
            var vertex2 = new Vertex(2, 3);
            
            testObject.TryAddVertex(vertex1);
            testObject.TryAddVertex(vertex2);

            //Act
            var resultDelete = testObject.TryRemoveVertex(vertex1);
            var resultVertices = testObject.Vertices;
            var resultOnlyVertex = testObject.Vertices.First();

            //Assert
            Assert.True(resultDelete);
            Assert.Single(resultVertices);
            Assert.Equal(vertex2, resultOnlyVertex);
        }

        [Fact]
        public void TryAddEdge_AddEmptyEdgeWithoutEmptyVertex_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge();

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.False(resultAdd);
            Assert.Empty(resultEdges);
        }

        [Fact]
        public void TryAddEdge_AddEmptyEdgeWithEmptyVertex_True()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge();
            testObject.TryAddVertex(new Vertex());

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.True(resultAdd);
            Assert.Single(resultEdges);
        }

        [Fact]
        public void TryAddEdge_AddEdgeToNonExistingVertices_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 0);

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.False(resultAdd);
            Assert.Empty(resultEdges);
        }

        [Fact]
        public void TryAddEdge_OneVertexExistsSecondNot_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 0);
            testObject.TryAddVertex(new Vertex(1, 2));

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.False(resultAdd);
            Assert.Empty(resultEdges);
        }

        [Fact]
        public void TryAddEdge_TwoExistingVerticesAndAddedEdge_True()
        {
            //Arrange
            var testObject = new Graph();

            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var edge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 0);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.True(resultAdd);
            Assert.Single(resultEdges);
        }

        [Fact]
        public void TryAddEdge_FeedbackLoopEdge_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var testEdge = new Edge(new Vertex(1, 2), new Vertex(1, 2), 0);
            testObject.TryAddVertex(vertexA);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.True(resultAdd);
            Assert.Single(resultEdges);
        }

        [Fact]
        public void TryAddEdge_SetWeight_ValidWeight()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);

            //Act
            testObject.TryAddEdge(testEdge);
            var result = testObject.Edges.First();

            //Assert
            Assert.Equal(2, result.Weight);
        }

        [Fact]
        public void TryAddEdge_ValidEdge_ValidValues()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);

            //Act
            testObject.TryAddEdge(testEdge);
            var result = testObject.Edges.First();

            //Assert
            Assert.Equal(vertexA, result.From);
            Assert.Equal(vertexB, result.To);
            Assert.Equal(2, result.Weight);
        }

        [Fact]
        public void TryAddEdge_AddTheSameEdgeTwice_False()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge = new Edge(new Vertex(1, 2), new Vertex(2, 3), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge);
            var resultEdges = testObject.Edges;

            //Assert
            Assert.False(resultAdd);
            Assert.Single(resultEdges);
        }

        [Fact]
        public void TryAddEdge_EdgeWithSameCoordinatesButDifferentWeight_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge(vertexA, vertexB, 2);
            var testEdge2 = new Edge(vertexA, vertexB, 5);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge1);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge2);
            var resultCount = testObject.Edges.Count();
            var resultEdge = testObject.Edges.ElementAt(1);

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(2, resultCount);
            Assert.Equal(5, resultEdge.Weight);
            Assert.Equal(vertexA, resultEdge.From);
            Assert.Equal(vertexB, resultEdge.To);
        }

        [Fact]
        public void TryAddEdge_EdgesAreDirected_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge(vertexA, vertexB, 2);
            var testEdge2 = new Edge(vertexB, vertexA, 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge1);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge2);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(2, resultCount);
        }

        [Fact]
        public void TryAddEdge_IndirectEdgesWithTheSameCoordinatesButDifferentWeight_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge(vertexA, vertexB, 2);
            var testEdge2 = new Edge(vertexB, vertexA, 5);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge1);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge2);
            var resultCount = testObject.Edges.Count();
            var resultEdge = testObject.Edges.ElementAt(1);

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(2, resultCount);
            Assert.Equal(5, resultEdge.Weight);
            Assert.Equal(vertexB, resultEdge.From);
            Assert.Equal(vertexA, resultEdge.To);
        }

        [Fact]
        public void TryRemoveEdge_NonExistingEdge_False()
        {
            //Arrange
            var testObject = new Graph();

            //Act
            var result = testObject.TryRemoveEdge(new Edge());

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TryRemoveEdge_ExistingEdge_True()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());
            testObject.TryAddEdge(new Edge());

            //Act
            var resultRemove = testObject.TryRemoveEdge(new Edge());
            var resultEdges = testObject.Edges;

            //Assert
            Assert.True(resultRemove);
            Assert.Empty(resultEdges);
        }

        [Fact]
        public void TryRemoveEdge_TwoExistingEdgesRemoveOne_TrueAndOneLeft()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());
            testObject.TryAddVertex(new Vertex(1, 2));
            testObject.TryAddVertex(new Vertex(2, 3));
            testObject.TryAddEdge(new Edge());
            testObject.TryAddEdge(new Edge(new Vertex(1, 2), new Vertex(2, 3), 0));

            //Act
            var resultRemove = testObject.TryRemoveEdge(new Edge());
            var resultEdges = testObject.Edges;

            //Assert
            Assert.True(resultRemove);
            Assert.Single(resultEdges);
        }

        [Fact]
        public void TryRemoveEdge_TwoExistingEdgesRemoveOneInverted_False()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());
            testObject.TryAddVertex(new Vertex(1, 2));
            testObject.TryAddVertex(new Vertex(2, 3));
            testObject.TryAddEdge(new Edge());
            testObject.TryAddEdge(new Edge(new Vertex(1, 2), new Vertex(2, 3), 0));

            //Act
            var resultRemove = testObject.TryRemoveEdge(new Edge(new Vertex(2, 3), new Vertex(1, 2), 0));
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultRemove);
            Assert.Equal(2, resultCount);
        }

        [Fact]
        public void TryRemoveVertex_ConnectedGraph_RemoveVertexAndConnectedEdges()
        {
            //Arrange
            var testObject = new Graph();
            var vertex1 = new Vertex(1, 2);
            var vertexToRemove = new Vertex(2, 3);
            var vertex3 = new Vertex(4, 5);
            var vertex4 = new Vertex(6, 7);

            var edgeShouldBeRemoved1 = new Edge(vertex1, vertexToRemove, 1);
            var edgeShouldBeRemoved2 = new Edge(vertexToRemove, vertex3, 2);
            var edgeShouldBeRemoved3 = new Edge(vertexToRemove, vertex4, 3);
            var edgeShouldStay = new Edge(vertex3, vertex4, 4);

            testObject.TryAddVertex(vertex1);
            testObject.TryAddVertex(vertexToRemove);
            testObject.TryAddVertex(vertex3);
            testObject.TryAddVertex(vertex4);

            testObject.TryAddEdge(edgeShouldBeRemoved1);
            testObject.TryAddEdge(edgeShouldBeRemoved2);
            testObject.TryAddEdge(edgeShouldBeRemoved3);
            testObject.TryAddEdge(edgeShouldStay);

            //Act
            var resultRemove = testObject.TryRemoveVertex(vertexToRemove);
            var resultVerticesCount = testObject.Vertices.Count();
            var resultEdgesCount = testObject.Edges.Count();
            var resultEdge = testObject.Edges.First();

            //Assert
            Assert.True(resultRemove);
            Assert.Equal(3, resultVerticesCount);
            Assert.Equal(1, resultEdgesCount);
            Assert.Equal(4, resultEdge.Weight);
            Assert.Equal(vertex3, resultEdge.From);
            Assert.Equal(vertex4, resultEdge.To);
        }

        [Fact]
        public void FindAdjacentOf_UndirectedVertices_CorrectVertices()
        {
            //Arrange
            var testObject = new Graph();
            var vertex1 = new Vertex(1, 2);
            var vertex2 = new Vertex(3, 4);
            var vertex3 = new Vertex(5, 6);

            testObject.TryAddVertex(vertex1);
            testObject.TryAddVertex(vertex2);
            testObject.TryAddVertex(vertex3);

            testObject.TryAddUndirectedEdge(vertex1, vertex2, 0);
            testObject.TryAddUndirectedEdge(vertex1, vertex3, 0);

            //Act
            var result1 = testObject.FindAdjacentOf(vertex1);
            var result2 = testObject.FindAdjacentOf(vertex2);
            var result3 = testObject.FindAdjacentOf(vertex3);

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
            var testObject = new Graph();
            var vertex1 = new Vertex(1, 2);
            var vertex2 = new Vertex(3, 4);
            var vertex3 = new Vertex(5, 6);

            testObject.TryAddVertex(vertex1);
            testObject.TryAddVertex(vertex2);
            testObject.TryAddVertex(vertex3);

            testObject.TryAddDirectedEdge(vertex1, vertex2, 0);
            testObject.TryAddDirectedEdge(vertex1, vertex3, 0);

            //Act
            var result1 = testObject.FindAdjacentOf(vertex1);
            var result2 = testObject.FindAdjacentOf(vertex2);
            var result3 = testObject.FindAdjacentOf(vertex3);

            //Assert
            Assert.Equal(2, result1.Count());
            Assert.Equal(vertex2, result1.ElementAt(0));
            Assert.Equal(vertex3, result1.ElementAt(1));

            Assert.Empty(result2);
            Assert.Empty(result3);
        }
    }
}
