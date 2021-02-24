using AlgorithmsDotNet.Graphs.Algorithms;
using AlgorithmsDotNet.Graphs.DataStructures;
using AlgorithmsDotNet.Graphs.DataStructures.Common;
using FsCheck;
using FsCheck.Xunit;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Graphs.Tests.Algorithms
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
