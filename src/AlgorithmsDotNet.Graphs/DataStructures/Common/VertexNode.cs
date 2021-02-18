using System.Collections.Generic;

namespace AlgorithmsDotNet.Graphs.DataStructures.Common
{
    public struct VertexNode<TVertex>
    {
        public VertexNode(TVertex vertex)
        {
            White = true;
            Vertex = vertex;
            Edges = new List<Edge<TVertex>>();
        }

        public bool White { get; set; }
        public TVertex Vertex { get; }
        public IList<Edge<TVertex>> Edges { get; }
    }
}
