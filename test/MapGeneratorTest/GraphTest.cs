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
            var result = testObject.Edges.Count();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void TryAddVertex_One_NumberOfVerticesOne()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());

            //Act
            var resultCount = testObject.Vertices.Count();
            var resultVertex = testObject.Vertices.First();

            //Assert
            Assert.Equal(1, resultCount);
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
            var resultCount = testObject.Vertices.Count();

            //Assert
            Assert.True(resultAdd1);
            Assert.False(resultAdd2);
            Assert.Equal(1, resultCount);
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
            testObject.TryAddVertex(new Vertex(1, 2));
            testObject.TryAddVertex(new Vertex(2, 3));

            //Act
            var resultDelete = testObject.TryRemoveVertex(new Vertex(1, 2));
            var resultCount = testObject.Vertices.Count();
            var resultOnlyVertex = testObject.Vertices.First();

            //Assert
            Assert.True(resultDelete);
            Assert.Equal(1, resultCount);
            Assert.Equal((2, 3), (resultOnlyVertex.X, resultOnlyVertex.Y));
        }

        [Fact]
        public void TryAddEdge_AddEmptyEdgeWithoutEmptyVertex_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge();

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultAdd);
            Assert.Equal(0, resultCount);
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
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryAddEdge_AddEdgeToNonExistingVertices_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 0);

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultAdd);
            Assert.Equal(0, resultCount);
        }

        [Fact]
        public void TryAddEdge_OneVertexExistsSecondNot_False()
        {
            //Arrange
            var testObject = new Graph();
            var edge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 0);
            testObject.TryAddVertex(new Vertex(1, 2));

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultAdd);
            Assert.Equal(0, resultCount);
        }

        [Fact]
        public void TryAddEdge_TwoExistingVerticesAndAddedEdge_True()
        {
            //Arrange
            var testObject = new Graph();

            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var edge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 0);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);

            //Act
            var resultAdd = testObject.TryAddEdge(edge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryAddEdge_FeedbackLoopEdge_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var testEdge = new Edge((new Vertex(1, 2), new Vertex(1, 2)), 0);
            testObject.TryAddVertex(vertexA);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultAdd);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryAddEdge_SetWeight_ValidWeight()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
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
            var testEdge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);

            //Act
            testObject.TryAddEdge(testEdge);
            var result = testObject.Edges.First();

            //Assert
            Assert.Equal((1, 2), (result.Vertices.first.X, result.Vertices.first.Y));
            Assert.Equal((2, 3), (result.Vertices.second.X, result.Vertices.second.Y));
            Assert.Equal(2, result.Weight);
        }

        [Fact]
        public void TryAddEdge_AddTheSameEdgeTwice_False()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultAdd);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryAddEdge_EdgeWithSameCoordinatesButDifferentWeight_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testEdge2 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 5);
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
            Assert.Equal((1, 2), (resultEdge.Vertices.first.X, resultEdge.Vertices.first.Y));
            Assert.Equal((2, 3), (resultEdge.Vertices.second.X, resultEdge.Vertices.second.Y));
        }

        [Fact]
        public void TryAddEdge_TheSameEdgesAreIndirect_False()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testEdge2 = new Edge((new Vertex(2, 3), new Vertex(1, 2)), 2);
            testObject.TryAddVertex(vertexA);
            testObject.TryAddVertex(vertexB);
            testObject.TryAddEdge(testEdge1);

            //Act
            var resultAdd = testObject.TryAddEdge(testEdge2);
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.False(resultAdd);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryAddEdge_IndirectEdgesWithTheSameCoordinatesButDifferentWeight_True()
        {
            //Arrange
            var testObject = new Graph();
            var vertexA = new Vertex(1, 2);
            var vertexB = new Vertex(2, 3);
            var testEdge1 = new Edge((new Vertex(1, 2), new Vertex(2, 3)), 2);
            var testEdge2 = new Edge((new Vertex(2, 3), new Vertex(1, 2)), 5);
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
            Assert.Equal((2, 3), (resultEdge.Vertices.first.X, resultEdge.Vertices.first.Y));
            Assert.Equal((1, 2), (resultEdge.Vertices.second.X, resultEdge.Vertices.second.Y));
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
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultRemove);
            Assert.Equal(0, resultCount);
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
            testObject.TryAddEdge(new Edge((new Vertex(1, 2), new Vertex(2, 3)), 0));

            //Act
            var resultRemove = testObject.TryRemoveEdge(new Edge());
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultRemove);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void TryRemoveEdge_TwoExistingEdgesRemoveOneInverted_TrueAndOneLeft()
        {
            //Arrange
            var testObject = new Graph();
            testObject.TryAddVertex(new Vertex());
            testObject.TryAddVertex(new Vertex(1, 2));
            testObject.TryAddVertex(new Vertex(2, 3));
            testObject.TryAddEdge(new Edge());
            testObject.TryAddEdge(new Edge((new Vertex(1, 2), new Vertex(2, 3)), 0));

            //Act
            var resultRemove = testObject.TryRemoveEdge(new Edge((new Vertex(2, 3), new Vertex(1, 2)), 0));
            var resultCount = testObject.Edges.Count();

            //Assert
            Assert.True(resultRemove);
            Assert.Equal(1, resultCount);
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

            var edgeShouldBeRemoved1 = new Edge((vertex1, vertexToRemove), 1);
            var edgeShouldBeRemoved2 = new Edge((vertexToRemove, vertex3), 2);
            var edgeShouldBeRemoved3 = new Edge((vertexToRemove, vertex4), 3);
            var edgeShouldStay = new Edge((vertex3, vertex4), 4);

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
            var (resultEdgeVertices, weight) = testObject.Edges.First();

            //Assert
            Assert.True(resultRemove);
            Assert.Equal(3, resultVerticesCount);
            Assert.Equal(1, resultEdgesCount);
            Assert.Equal(4, weight);
            Assert.Equal(vertex3, resultEdgeVertices.first);
            Assert.Equal(vertex4, resultEdgeVertices.second);
        }
    }
}
