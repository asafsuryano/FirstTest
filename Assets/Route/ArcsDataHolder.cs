using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Route
{
    public class ArcsDataHolder : MonoBehaviour
    {
        private List<Arc> arcs;
        private RouteMapHolder routeMap_ref;  // reference to RouteMapHolder for getting the all nodes (junctions and roads)

        internal List<Arc> Arcs { get => arcs; set => arcs = value; }

        public void Start()
        {
            this.arcs = new List<Arc>();
            this.routeMap_ref = GameObject.Find("Route Map").GetComponent<RouteMapHolder>();
            readArcsFromCSV();
        }

        public void Update()
        {

        }
        /*
        private void readArcsFromCSV()
        {
            Node source, destination;
            StreamReader rd;
#if UNITY_EDITOR
            rd = new StreamReader("Assets/Data/Arcs.csv");
#elif UNITY_STANDALONE
            rd = new StreamReader("Resources/Data/Arcs.csv");
#endif
            rd.ReadLine();  // read the first line
            while (!rd.EndOfStream)
            {
                string details = rd.ReadLine();
                string[] detailsArr = details.Split(',');
                if (!(detailsArr[0] == "" || detailsArr[1] == "" || detailsArr[2] == "" || detailsArr[3] == ""))  // if not empty row
                {
                    int arcID = Int32.Parse(detailsArr[0]);
                    string source_name = detailsArr[1];
                    source = this.routeMap_ref.RouteMap.GetNodeByName(source_name);
                    string destination_name = detailsArr[2];
                    destination = this.routeMap_ref.RouteMap.GetNodeByName(destination_name);
                    int ruleID = Int32.Parse(detailsArr[3]);

                    Arc arc = new Arc(arcID, source, destination, ruleID);

                    this.arcs.Add(arc);
                }
            }
            rd.Close();
        }
        */
        private void readArcsFromCSV()
        {
            Node source, destination;
            TextAsset txt = Resources.Load("Data/Arcs") as TextAsset;
            string arcs = txt.text;
            string[] allLines = arcs.Split('\n');
            for (int i=1;i<allLines.Length;i++)
            {
                string[] detailsArr = allLines[i].Split(',');
                if (!(detailsArr[0] == "" || detailsArr[1] == "" || detailsArr[2] == "" || detailsArr[3] == ""))  // if not empty row
                {
                    int arcID = Int32.Parse(detailsArr[0]);
                    string source_name = detailsArr[1];
                    source = this.routeMap_ref.RouteMap.GetNodeByName(source_name);
                    string destination_name = detailsArr[2];
                    destination = this.routeMap_ref.RouteMap.GetNodeByName(destination_name);
                    int ruleID = Int32.Parse(detailsArr[3]);

                    Arc arc = new Arc(arcID, source, destination, ruleID);

                    this.arcs.Add(arc);
                }
            }
        }

        internal Arc GetArcById(int arcId)
        {
            for (int i = 0; i < this.arcs.Count; i++)
            {
                if (this.arcs[i].ArcID == arcId)
                {
                    return this.arcs[i];
                }
            }
            return null;
        }

        internal Arc GetArcBySourceAndDestination(Node source, Node destination)
        {
            for (int i = 0; i < this.arcs.Count; i++)
            {
                if (this.arcs[i].Source.Name == source.Name && this.arcs[i].Destination.Name == destination.Name)
                {
                    return this.arcs[i];
                }
            }
            return null;
        }

        internal void printAllArcs()
        {
            print("print all arcs: ");
            for (int i=0; i< this.arcs.Count; i++)
            {
                print(+ this.arcs[i].ArcID + ", "
                      + this.arcs[i].Source.Name + ", "
                      + this.arcs[i].Destination.Name + ", "
                      + this.arcs[i].RuleID);
            }
        }

    }
}