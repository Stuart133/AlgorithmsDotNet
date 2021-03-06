﻿using AlgorithmsDotNet.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Algorithms.Graphs
{
    public static class BreadthFirstSearchGraph
    {
        public static IReadOnlyDictionary<TVertex, BFSVertexData> BreadthFirstSearch<TVertex>(this IGraph<TVertex> graph, TVertex sourceVertex)
            where TVertex : IComparable<TVertex>, IEquatable<TVertex>
        {
            // Load graph vertices and create supplimental data structs
            var vertices = new Dictionary<TVertex, BFSVertexData>(graph.Vertices
                .Select(v => KeyValuePair.Create(v, new BFSVertexData())));

            var vertexQueue = new Queue<TVertex>();
            vertexQueue.Enqueue(sourceVertex);

            while (vertexQueue.Count != 0)
            {
                var vertex = vertexQueue.Dequeue();

                // Check all the edges from the current vertex
                foreach (var edge in graph.GetOutboundEdges(vertex))
                {
                    // Get supplimental data for edge distination vertex
                    var destinationData = vertices[edge.Destination];

                    // Ignore already visited nodes
                    if (!destinationData.Visited)
                    {
                        destinationData.Visited = true;
                        destinationData.Distance = vertices[vertex].Distance + 1;
                        vertexQueue.Enqueue(edge.Destination);
                    }
                }
            }

            return vertices;
        }
    }

    public struct BFSVertexData
    {
        public bool Visited { get; set; }
        public int Distance { get; set; }
    }
}
