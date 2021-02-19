using AlgorithmsDotNet.Graphs.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsDotNet.Graphs.DataStructures
{
    public interface IGraph<TVertex>
        where TVertex : IComparable<TVertex>, IEquatable<TVertex>
    {
        public int VertexCount { get; }
        public int EdgeCount { get; }
        public IEnumerable<TVertex> Vertices { get; }

        IGraph<TVertex> CreateEmptyGraph();
        IList<Edge<TVertex>> GetOutboundEdges(TVertex source);
        void AddVertex(TVertex vertex);
        void AddVertices(IEnumerable<TVertex> vertices);
        void AddEdge(TVertex source, TVertex destination, int weight = 1);
    }
}
