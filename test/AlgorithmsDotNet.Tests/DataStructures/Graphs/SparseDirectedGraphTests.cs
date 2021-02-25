using AlgorithmsDotNet.DataStructures.Graphs;
using FsCheck;
using FsCheck.Xunit;

namespace AlgorithmsDotNet.Graphs.Tests.DataStructures
{
    public class SparseDirectedGraphTests
    {
        [Property]
        public Property VertexCount_AfterAddingVertices_EqualsNumberOfVerticesAdded(int x)
        {
            // Arrange
            var graph = new SparseDirectedGraph<int>();
            for (int i = 0; i < x; i++)
            {
                graph.AddVertex(i);
            }

            // Act
            var vertexCount = graph.VertexCount;

            // Property
            return (x == vertexCount).When(x >= 0);
        }

        [Property]
        public Property EdgeCount_AfterAddingEdges_EqualsNumberOfEdgesAdded(int x)
        {
            // Arrange
            var graph = new SparseDirectedGraph<int>();
            graph.AddVertex(10);
            graph.AddVertex(23);
            for (int i = 0; i < x; i++)
            {
                graph.AddEdge(10, 23);
            }

            // Act
            var edgeCount = graph.EdgeCount;

            //Property
            return (x == edgeCount).When(x >= 0);            
        }
    }
}
