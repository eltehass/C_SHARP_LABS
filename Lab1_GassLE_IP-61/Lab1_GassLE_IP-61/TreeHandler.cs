using System;

namespace Lab1_GassLE_IP_61
{
    public struct Vertex
    {
        public bool isVisited;              
        public int quantity;                // Number of adjacent vertices
        public int[,] related;              // Adjacent vertices and the weight of the edges leading to them
    };

    /* A class that contains a method that implements the finding of 
     * a distance matrix from adjacency matrices 
     * by the Dextree algorithm
     * */
    public class TreeHandler
    {
        // Algorithm Dextree
        public static int[] FindByDextree(Vertex[] array, int point)
        {
            // Distances from start to other vertices
            int[] distances = new int[array.GetLength(0)];

            // Initial initialization of distances
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                if (i == point) distances[i] = 0;
                else distances[i] = Int32.MaxValue;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (!array[i].isVisited)
                {
                    // Search for the element with the minimum distance among unvisited
                    int minIndex = i;
                    for (int j = 0; j < array.GetLength(0); j++)
                        if (!array[j].isVisited && distances[j] < distances[minIndex])
                            minIndex = j;

                    array[minIndex].isVisited = true;

                    for (int j = 0; j < array[minIndex].quantity; j++)
                    {
                        if (!array[array[minIndex].related[0, j]].isVisited)
                        {
                            if (distances[array[minIndex].related[0, j]] > distances[minIndex] +
                              array[minIndex].related[1, j])
                            {
                                distances[array[minIndex].related[0, j]] = distances[minIndex] +
                                  array[minIndex].related[1, j];
                            }
                        }
                    }
                }
            }

            // Reset attendance
            for (int i = 0; i < array.GetLength(0); i++)
                array[i].isVisited = false;

            return distances;
        }

        // Fill in the graph according to Dextra's algorithm
        public static Vertex[] FillGraph(int[,] array)
        {
            Vertex[] vertexes = new Vertex[array.GetLength(0)];
            for (int i = 0; i < vertexes.GetLength(0); i++)
            {
                vertexes[i].isVisited = false;
                vertexes[i].related = new int[2, vertexes.GetLength(0)];
            }

            for (int i = 0; i < vertexes.GetLength(0); i++)
            {
                vertexes[i].quantity = 0;
                for (int j = 0; j < vertexes.GetLength(0); j++)
                {
                    if (array[i, j] != -1)
                    {
                        vertexes[i].related[0, vertexes[i].quantity] = j;
                        vertexes[i].related[1, vertexes[i].quantity] = array[i, j];
                        vertexes[i].quantity++;
                    }
                }
            }

            return vertexes;
        }

        /*
         * Obtaining the matrix of extrinsicities from the adjacency matrix
         * */
        public static int[,] FindDistances(int[,] array)
        {

            // Creating a Graph
            Vertex[] graph = FillGraph(array);

            // Creating a Distance Matrix
            int[,] result = new int[array.GetLength(0), array.GetLength(0)];
            int[] littleRes;

            // Filling the distance matrix
            for (int i = 0; i < array.GetLength(0); i++)
            {
                littleRes = FindByDextree(graph, i);
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    result[i, x] = littleRes[x];
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (Math.Abs(result[i, j]) >= Int32.MaxValue - 1000) { result[i, j] = result[j, i]; }
                    if (Math.Abs(result[i, j]) >= Int32.MaxValue - 1000) { result[i, j] = -1; }
                }
            }

            return result;
        }
    }

}
 