namespace AlgorithmsDotNet.Graphs.DataStructures
{
    public interface IGraph<TVertex>
    {
        public int VertexCount { get; }
        public int EdgeCount { get; }

        public void AddVertex(TVertex vertex);
        public void AddEdge(TVertex source, TVertex destination, int weight = 0);
    }
}
