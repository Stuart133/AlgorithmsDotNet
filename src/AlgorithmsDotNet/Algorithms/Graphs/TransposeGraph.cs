using AlgorithmsDotNet.DataStructures.Graphs;
using System;

namespace AlgorithmsDotNet.Algorithms.Graphs
{
    public static class TransposeGraph
    {
        /// <summary>
        /// Return a new graph with the edges reversed
        /// </summary>
        /// <param name="inputGraph"></param>
        /// <returns></returns>
        public static IGraph<TVertex> Transpose<TVertex>(this IGraph<TVertex> inputGraph)
            where TVertex : IComparable<TVertex>, IEquatable<TVertex>
        {
            var transpose = inputGraph.CreateEmptyGraph();
            transpose.AddVertices(inputGraph.Vertices);

            foreach (var vertex in inputGraph.Vertices)
            {
                foreach (var edge in inputGraph.GetOutboundEdges(vertex))
                {
                    transpose.AddEdge(edge.Destination, edge.Source, edge.Weight);
                }
            }

            return transpose;
        }
    }
}
