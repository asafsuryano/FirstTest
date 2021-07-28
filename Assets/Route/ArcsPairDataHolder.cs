using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Route
{
    public class ArcsPairDataHolder : MonoBehaviour
    {
        private List<ArcsPair> arcsPairs;
        private ArcsDataHolder arcsDataHolder;

        internal List<ArcsPair> ArcsPairs { get => arcsPairs; set => arcsPairs = value; }

        public void Start()
        {
            arcsPairs = new List<ArcsPair>() ;
            arcsDataHolder = GameObject.Find("arcs").GetComponent<ArcsDataHolder>();
            readArcsPairsFromCSV();
        }

        public void Update()
        {

        }
        /*
        private void readArcsPairsFromCSV()
        {
            StreamReader rd;
#if UNITY_EDITOR
            rd = new StreamReader("Assets/Data/pairs of arcs.csv");
#elif UNITY_STANDALONE
            rd = new StreamReader(res);
#endif
            rd.ReadLine();  // read the first line
            while (!rd.EndOfStream)
            {
                string details = rd.ReadLine();
                string[] detailsArr = details.Split(',');
                if (!(detailsArr[0] == "" || detailsArr[1] == "" || detailsArr[2] == "" || detailsArr[3] == ""))
                {
                    int pairID = Int32.Parse(detailsArr[0]);
                    int arcSourceID = Int32.Parse(detailsArr[1]);
                    Arc arcSource = arcsDataHolder.GetArcById(arcSourceID);
                    int arcDestinationID = Int32.Parse(detailsArr[2]);
                    Arc arcDestination = arcsDataHolder.GetArcById(arcDestinationID);
                    Enum.TryParse(detailsArr[3], out DrivingDirectionSign directionSignID);

                    ArcsPair arcPair = new ArcsPair(pairID, arcSource, arcDestination, directionSignID);

                    arcsPairs.Add(arcPair);
                }

            }
            rd.Close();
        }
        */
        private void readArcsPairsFromCSV()
        {
            TextAsset txt = Resources.Load("Data/pairs of arcs") as TextAsset;
            string arcpairs = txt.text;
            string[] allLines = arcpairs.Split('\n');
            for (int i = 1; i < allLines.Length; i++)
            {
                string[] detailsArr = allLines[i].Split(',');
                if (!(detailsArr[0] == "" || detailsArr[1] == "" || detailsArr[2] == "" || detailsArr[3] == ""))
                {
                    int pairID = Int32.Parse(detailsArr[0]);
                    int arcSourceID = Int32.Parse(detailsArr[1]);
                    Arc arcSource = arcsDataHolder.GetArcById(arcSourceID);
                    int arcDestinationID = Int32.Parse(detailsArr[2]);
                    Arc arcDestination = arcsDataHolder.GetArcById(arcDestinationID);
                    Enum.TryParse(detailsArr[3], out DrivingDirectionSign directionSignID);

                    ArcsPair arcPair = new ArcsPair(pairID, arcSource, arcDestination, directionSignID);

                    arcsPairs.Add(arcPair);
                }
            }
        }
    }
}
