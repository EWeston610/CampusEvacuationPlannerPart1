using System;
using System.Collections.Generic;
using System.Linq;

class WeightedList
{
    Dictionary<string, List<(string neighbor, int weight)>> graph = new();

    public void AddEdge(string from, string to, int weight)
    {
        if (!graph.ContainsKey(from))
        {
            graph[from] = new List<(string neighbor, int weight)>();
        }

        if (!graph.ContainsKey(to))
        {
            graph[to] = new List<(string neighbor, int weight)>();
        }

        graph[from].Add((to, weight));
        graph[to].Add((from, weight));
    }

    public void AddExit(string hallwayNode, string exitName, int weight)
    {
        AddEdge(hallwayNode, exitName, weight);
    }

    public void AddSpecialNode(string hallwayNode, string roomName, int weight)
    {
        AddEdge(hallwayNode, roomName, weight);
    }

    public void DisplayAll()
    {
        foreach (var node in graph)
        {
            Console.Write($"{node.Key}: ");

            foreach (var (neighbor, weight) in node.Value)
            {
                Console.Write($"[{neighbor}, w={weight}] ");
            }
            Console.WriteLine();
        }

    }

    public void DisplaySummary()
    {
        foreach (var node in graph)
        {
            Console.WriteLine($"{node.Key} to {node.Value.Count} neighbors");
        }
    }

    public HashSet<string> GetExitNodes()
    {
        var exits = new HashSet<string>();

        foreach (var node in graph.Keys)
        {
            if (node.StartsWith("Exit"))
            {
                exits.Add(node);
            }
        }

        return exits;
    }

    public List<string> GetRoomNodes()
    {
        var rooms = new List<string>();

        foreach (var node in graph.Keys)
        {
            bool isRoom = node.All(char.IsDigit);

            if (isRoom)
            {
                rooms.Add(node);
            }
        }

        return rooms;
    }

    public void FindAndDisplayQuickestExits()
    {
        var rooms = GetRoomNodes();
        var exits = GetExitNodes();

        foreach (var room in rooms)
        {
            var (distance, path) = Dijkstra(room, exits);

            Console.WriteLine($"Room {room}: distance = {distance}, path = ({string.Join(" to ", path)})");
        }
    }

    public (int distance, List<string> path) Dijkstra(string start, HashSet<string> exits)
    {
        var dist = new Dictionary<string, int>();

        foreach (var node in graph.Keys)
        {
            dist[node] = int.MaxValue;
        }

        dist[start] = 0;

        var pq = new PriorityQueue<string, int>();

        pq.Enqueue(start, 0);

        var visited = new HashSet<string>();
        var prev = new Dictionary<string, string>();

        string reachedExit = null;

        while (pq.Count > 0)
        {
            string current = pq.Dequeue();

            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);

            if (exits.Contains(current))
            {
                reachedExit = current;
                break;
            }



            foreach (var (neighbor, weight) in graph[current])
            {
                int newDist = dist[current] + weight;

                if (newDist < dist[neighbor])
                {
                    dist[neighbor] = newDist;
                    prev[neighbor] = current;
                    pq.Enqueue(neighbor, newDist);
                }
            }
        }

        if (reachedExit == null)
        {
            return (int.MaxValue, new List<string>());
        }

        var path = new List<string>();
        string currentNode = reachedExit;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = prev[currentNode];
        }

        path.Add(start);

        path.Reverse();

        int finalDistance = dist[reachedExit];

        return (finalDistance, path);
    }
}
