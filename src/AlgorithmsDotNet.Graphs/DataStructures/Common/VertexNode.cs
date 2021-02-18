namespace AlgorithmsDotNet.Graphs.DataStructures.Common
{
    public struct VertexNode<TVertex>
    {
        public VertexNode(TVertex vertex)
        {
            White = true;
            Vertex = vertex;
        }

        public bool White { get; set; }
        public TVertex Vertex { get; }
    }
}
