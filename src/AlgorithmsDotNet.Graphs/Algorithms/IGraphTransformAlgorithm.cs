using AlgorithmsDotNet.Graphs.DataStructures;
using System;

namespace AlgorithmsDotNet.Graphs.Algorithms
{
    public interface IGraphTransformAlgorithm<TVertex>
        where TVertex : IComparable<TVertex>, IEquatable<TVertex>
    {
        IGraph<TVertex> Execute(IGraph<TVertex> inputGraph);
    }
}
