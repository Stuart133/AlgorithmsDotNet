using AlgorithmsDotNet.Graphs.DataStructures.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Graphs.DataStructures
{
    /// <summary>
    /// A representation of a sparse directed graph
    /// </summary>
    public class SparseDirectedGraph<TVertex> : IGraph<TVertex>
    {
        private readonly IDictionary<TVertex, IList<Edge<TVertex>>> _adjacencyList;

        public SparseDirectedGraph()
        {
            _adjacencyList = new Dictionary<TVertex, IList<Edge<TVertex>>>();
        }

        public int VertexCount => _adjacencyList.Count;
        public int EdgeCount => _adjacencyList.Sum(v => v.Value.Count);

        public void AddVertex(TVertex vertex)
        {
            _adjacencyList.Add(vertex, new List<Edge<TVertex>>());
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
