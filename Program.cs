namespace NumberOperationsMakeNetworkConnected
{
    internal class Program
    {
        public class NumberOperationsMakeNetworkConnected
        {
            private void DFS(Dictionary<int, List<int>> graph, bool[] visited, int node)
            {
                if (visited[node])
                {
                    return;
                }
                if (!graph.ContainsKey(node))
                {
                    return;
                }
                visited[node] = true;
                foreach (int neighbor in graph[node])
                {
                    DFS(graph, visited, neighbor);
                }
            }

            public int MakeConnected(int n, int[][] connections)
            {
                if (n - 1 > connections.Length)
                {
                    return -1;
                }
                int makeConnections = 0;
                Dictionary<int, List<int>> graph = new();
                foreach (int[] connection in connections)
                {
                    if (!graph.ContainsKey(connection[0]))
                    {
                        graph[connection[0]] = new List<int>();
                    }
                    graph[connection[0]].Add(connection[1]);
                    if (!graph.ContainsKey(connection[1]))
                    {
                        graph[connection[1]] = new List<int>();
                    }
                    graph[connection[1]].Add(connection[0]);
                }
                bool[] visited = new bool[n];
                for (int i = 0; i < n; ++i)
                {
                    if (!visited[i])
                    {
                        ++makeConnections;
                        DFS(graph, visited, i);
                    }
                }
                return makeConnections - 1;
            }
        }
        static void Main(string[] args)
        {
            NumberOperationsMakeNetworkConnected numberOperationsMakeNetworkConnected = new();
            Console.WriteLine(numberOperationsMakeNetworkConnected.MakeConnected(4, new int[][] 
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 2 }
            }));
            Console.WriteLine(numberOperationsMakeNetworkConnected.MakeConnected(6, new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 0, 3 },
                new int[] { 1, 2 },
                new int[] { 1, 3 }
            }));
            Console.WriteLine(numberOperationsMakeNetworkConnected.MakeConnected(6, new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 0, 3 },
                new int[] { 1, 2 }
            }));
        }
    }
}