using AlgorithmsDotNet.Graphs.DataStructures.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Graphs.DataStructures
{
    /// <summary>
    /// A representation of a sparse directed graph
    /// </summary>
    public class SparseDirectedGraph<TVertex>
    {
        private readonly IList<IList<VertexNode<TVertex>>> _adjacencyList = new List<IList<VertexNode<TVertex>>>();

        public int VertexCount => _adjacencyList.Count;
        public int EdgeCount => _adjacencyList.Sum(v => v.Count);
    }
}
