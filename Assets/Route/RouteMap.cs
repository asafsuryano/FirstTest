using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Assets.Route
{
    class RouteMap
    {
        private List<Node> nodes;
        private List<Arc> arcs;
        private Node nodeIsOn;
        private Arc nextArc;
        private Arc previousArc;
        private Node destinationNode;
        private Queue<Arc> arcsInRoute;
        private ArcsDataHolder arcsDataHolder;

        public RouteMap()
        {
            this.nodes = new List<Node>();
            this.arcs = new List<Arc>();
            this.arcsInRoute = new Queue<Arc>();
        }

        public RouteMap(string filePath)
        {

        }

        public List<Node> Nodes { get => nodes; set => nodes = value; }
        public Node DestinationNode { get => destinationNode; set => destinationNode = value; }
        internal Node NodeIsOn { get => nodeIsOn; set => nodeIsOn = value; }
        internal Arc PreviousArc { get => previousArc; set => previousArc = value; }
        internal List<Arc> Arcs { get => arcs; set => arcs = value; }
        internal Arc NextArc { get => nextArc; set => nextArc = value; }
        internal Queue<Arc> ArcsInRoute { get => arcsInRoute; set => arcsInRoute = value; }
        internal ArcsDataHolder ArcsDataHolder { get => arcsDataHolder; set => arcsDataHolder = value; }

        public void addNode(Node node)
        {
            this.nodes.Add(node);
        }

        public bool changeNodeIsOn(Car user_Car)
        {
            if (nextArc.Destination.CheckPosition(user_Car.getPosition()))
            {
                nodeIsOn = nextArc.Destination;
                previousArc = nextArc;
                nextArc = arcsInRoute.Dequeue();
                //Debug.Log(nextArc.Source.Name);
                //Random random = new Random();
                //int index = random.Next(0, nodeIsOn.EdgesFrom.Count);
                //nextArc = this.nodeIsOn.EdgesFrom[index];
                return true;
            }
            else
            {
                return false;
            }
        }

        public Node GetNodeByName(string name)
        {
            for (int i = 0; i < this.nodes.Count;i++)
            {
                if (this.nodes[i].Name == name)
                {
                    return this.nodes[i];
                }
            }
            return null;
        }

        /*
        public void CreateRouteFromCsvFile(string filepath)
        {
            this.arcsDataHolder = GameObject.Find("arcs").GetComponent<ArcsDataHolder>();
            var rd = new StreamReader(filepath);
            string nodeName = rd.ReadLine();
            Node node1 = GetNodeByName(nodeName);
            this.nodeIsOn = node1;
            int i = 0;
            Arc arc = new Arc();

            while (!rd.EndOfStream)
            {
                nodeName = rd.ReadLine();
                Node node2 = GetNodeByName(nodeName);
                arcsInRoute.Enqueue(new Arc(i++, node1, node2, 0));  //  the 0 parameter is temporary
                //arc = arcsDataHolder.GetArcBySourceAndDestination(node1, node2);
                //arcsInRoute.Enqueue(arc);  //  the 0 parameter is temporary
                node1 = node2;
            }
            rd.Close();
        }
        */
        public void CreateRouteFromCsvFile(string filepath) 
        {
            TextAsset txt = Resources.Load(filepath) as TextAsset;
            string route = txt.text;
            string[] allLines = route.Split('\n');
            Node node1 = GetNodeByName(allLines[0].Split('\r')[0]);
            this.nodeIsOn = node1;
            Arc arc = new Arc();
            for (int i=1;i<allLines.Length;i++)
            {
                Node node2 = GetNodeByName(allLines[i].Split('\r')[0]);
                arcsInRoute.Enqueue(new Arc(i-1, node1, node2, 0));  //  the 0 parameter is temporary
                //arc = arcsDataHolder.GetArcBySourceAndDestination(node1, node2);
                //arcsInRoute.Enqueue(arc);  //  the 0 parameter is temporary
                node1 = node2;
            }
        }

        public void CalculateRouteByStartPointAndEndPoint(Node start, Node end)
        {
            //todo
        }
    }
}
