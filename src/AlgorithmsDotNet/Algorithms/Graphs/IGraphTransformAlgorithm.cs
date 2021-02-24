using AlgorithmsDotNet.DataStructures.Graphs;
using System;

namespace AlgorithmsDotNet.Algorithms.Graphs
{
    public interface IGraphTransformAlgorithm<TVertex>
        where TVertex : IComparable<TVertex>, IEquatable<TVertex>
    {
        IGraph<TVertex> Execute(IGraph<TVertex> inputGraph);
    }
}
