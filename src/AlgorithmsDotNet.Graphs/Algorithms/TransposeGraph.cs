using AlgorithmsDotNet.Graphs.DataStructures;
using System;

namespace AlgorithmsDotNet.Graphs.Algorithms
{
    public class TransposeGraph<TVertex> : IGraphTransformAlgorithm<TVertex>
        where TVertex : IComparable<TVertex>, IEquatable<TVertex>
    {
        /// <summary>
        /// Return a new graph with the edges reversed
        /// </summary>
        /// <param name="inputGraph"></param>
        /// <returns></returns>
        public IGraph<TVertex> Execute(IGraph<TVertex> inputGraph)
        {
            var transpose = inputGraph.CreateEmptyGraph();
            transpose.AddVertices(inputGraph.Vertices);

            foreach(var vertex in inputGraph.Vertices)
            {
                foreach(var edge in inputGraph.GetOutboundEdges(vertex))
                {
                    transpose.AddEdge(edge.Destination, edge.Source, edge.Weight);
                }
            }

            return transpose;
        }
    }
}
