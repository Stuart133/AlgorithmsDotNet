namespace AlgorithmsDotNet.DataStructures.Graphs.Common
{
    public class Edge<TVertex>
    {
        public int Weight { get; init; }
        public TVertex Source { get; init; }
        public TVertex Destination { get; init; }
    }
}
