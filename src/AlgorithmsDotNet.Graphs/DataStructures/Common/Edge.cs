namespace AlgorithmsDotNet.Graphs.DataStructures.Common
{
    public class Edge<TVertex>
    {
        public int Weight { get; init; }
        public TVertex Start { get; init; }
        public TVertex End { get; init; }
    }
}
