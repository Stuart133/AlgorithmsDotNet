using AlgorithmsDotNet.Graphs.DataStructures.Common;
using System.Collections.Generic;

namespace AlgorithmsDotNet.Graphs.DataStructures
{
    public interface IGraph<TVertex>
    {
        public int VertexCount { get; }
        public int EdgeCount { get; }
        public IEnumerable<TVertex> Vertices { get; }

        IList<Edge<TVertex>> GetOutboundEdges(TVertex source);
        public void AddVertex(TVertex vertex);
        public void AddEdge(TVertex source, TVertex destination, int weight = 0);
    }
}
