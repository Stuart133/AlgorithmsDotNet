using AlgorithmsDotNet.Algorithms.Graphs;
using AlgorithmsDotNet.DataStructures.Graphs;
using FsCheck;
using FsCheck.Xunit;

namespace AlgorithmsDotNet.Tests.Algorithms.Graphs
{
    public class TransposeGraphTests
    {
        [Property]
        public Property TransposeGraph_HasSameNumberOfEdgesAndVertices(SparseDirectedGraph<int> graph)
        {
            // Act
            var transponse = TransposeGraph<int>.Algorithm.Execute(graph);

            // Property
            return (transponse.VertexCount == graph.VertexCount)
                .And(transponse.EdgeCount == graph.EdgeCount);
        }
    }
}
