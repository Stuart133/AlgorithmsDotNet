namespace AlgorithmsDotNet.Graphs.DataStructures.Common
{
    public class Edge<TVertex>
    {
        public int Weight { get; init; }
        public TVertex Source { get; init; }
        public TVertex Destination { get; init; }
    }
}
