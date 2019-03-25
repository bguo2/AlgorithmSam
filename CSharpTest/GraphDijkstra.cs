using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //graph representation: Object/pointers, adjacent matrix, adjacent list
    //object/pointers
    public class Vertex
    {
        public int Index { get; set; }
        public string Label { get; set; }
    }

    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public double Cost { get; set; }
    }

    public class Graph
    {
        public List<Edge> EdgeList { get; set; }
        public void Bfs()
        {

        }
        public void Dfs()
        {

        }
    }


    //adjacent list
    public class Node
    {
        public int Index { get; set; }
        public string Lable { get; set; }
        //node, cost
        public List<Node> Neighbor { get; set; }
        public List<double> Cost { get; set; }
    }

    public class Graph1
    {
        private List<Node> _nodes;
        public void AddNode(Node x)
        {
            _nodes.Add(x);
        }
        public void AddEdge(Node a, Node b, double cost)
        {
            if (a.Neighbor == null)
                a.Neighbor = new List<Node>();
            a.Neighbor.Add(b);
            if (a.Cost == null)
                a.Cost = new List<double>();
            a.Cost.Add(cost);
        }
    }
}
