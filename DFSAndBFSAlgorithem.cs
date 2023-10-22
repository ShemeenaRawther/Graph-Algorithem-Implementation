using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    //TODO:initialise the element
    //Graph graph = new Graph(7);
    //        graph.AddEdge(0, 1);
    //        graph.AddEdge(0, 2);
    //        graph.AddEdge(1, 3);
    //        graph.AddEdge(1, 4);
    //        graph.AddEdge(2, 5);
    //        graph.AddEdge(2, 6);
    // call dfs
    //        graph.DoDfs(0);
    // call bfs
    //        graph.DoBFS(0);

    class Graph
    {
        private int numberOfVertices;
        private List<int>[] adjacencyList;
        public Graph(int vertices)
        {
            numberOfVertices = vertices;
            adjacencyList = new List<int>[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int vertice, int edge)
        {
            adjacencyList[vertice].Add(edge);
        }

        private void VisitEdge(int vertice, bool[] visited)
        {
            visited[vertice] = true;
            Console.Write(vertice + " ");
            foreach (int neighbor in adjacencyList[vertice])
            {
                if (!visited[neighbor])
                {
                    VisitEdge(neighbor, visited);
                }
            }
        }

        public void DoDfs(int startVertex)
        {
            var visitedArray = new bool[numberOfVertices];
            VisitEdge(startVertex, visitedArray);
        }

        public void DoBFS(int startVertex)
        {
            var visistedLists = new bool[numberOfVertices];
            Queue<int> queue = new Queue<int>();
            visistedLists[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int currentVertex= queue.Dequeue();
                Console.Write(currentVertex + " ");
                foreach (int vertex in adjacencyList[currentVertex])
                {
                    if (!visistedLists[vertex])
                    {
                        visistedLists[vertex] = true;
                        queue.Enqueue(vertex);
                    }
                }
            }

        }
    }
}
