using AlgorithmsDotNet.Graphs.DataStructures.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Graphs.DataStructures
{
    /// <summary>
    /// A representation of a sparse directed graph
    /// </summary>
    public class SparseDirectedGraph<TVertex> : IGraph<TVertex>
        where TVertex : IComparable<TVertex>, IEquatable<TVertex>
    {
        private readonly IDictionary<TVertex, IList<Edge<TVertex>>> _adjacencyList;

        public SparseDirectedGraph()
        {
            _adjacencyList = new Dictionary<TVertex, IList<Edge<TVertex>>>();
        }

        internal SparseDirectedGraph(IDictionary<TVertex, IList<Edge<TVertex>>> adjacencyList)
        {
            _adjacencyList = adjacencyList;
        }

        public int VertexCount => _adjacencyList.Count;
        public int EdgeCount => _adjacencyList.Sum(v => v.Value.Count);
        public IEnumerable<TVertex> Vertices => _adjacencyList.Keys;

        public IGraph<TVertex> CreateEmptyGraph()
        {
            return new SparseDirectedGraph<TVertex>();
        }

        public IList<Edge<TVertex>> GetOutboundEdges(TVertex source)
        {
            return _adjacencyList[source];
        }

        public void AddVertex(TVertex vertex)
        {
            _adjacencyList.Add(vertex, new List<Edge<TVertex>>());
        }

        public void AddVertices(IEnumerable<TVertex> vertices)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }
        }

        public void AddEdge(TVertex source, TVertex destination, int weight = 1)
        {
            _adjacencyList[source].Add(new Edge<TVertex>
            {
                Source = source,
                Destination = destination,
                Weight = weight
            });
        }
    }
}
