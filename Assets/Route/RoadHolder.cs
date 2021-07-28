using System.Collections.Generic;
using UnityEngine;
using Assets.Route;
using System.IO;

public class RoadHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Road> allRoads;
    private Bounds roadBound;

    public List<Road> AllRoads { get => allRoads; set => allRoads = value; }

    void Start()
    {
        this.allRoads = new List<Road>();
        ReadRoadsFromCsvFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Road GetRoadByName(string name)
    {
        for (int i = 0; i < this.allRoads.Count; i++)
        {
            if (this.allRoads[i].Name == name)
            {
                return this.allRoads[i];
            }
        }
        return null;
    }
    /*
    public void ReadRoadsFromCsvFile()
    {
        StreamReader rd;
#if UNITY_EDITOR
        rd = new StreamReader("Assets/Data/Roads.csv");
#elif UNITY_STANDALONE
        rd = new StreamReader("Resources/Data/Roads.csv");
#endif
        rd.ReadLine();
        while (!rd.EndOfStream)
        {
            string roadString = rd.ReadLine();
            string[] roadDetails = roadString.Split(',');

            string roadName = roadDetails[0];
            int rule = int.Parse(roadDetails[1]);
            float velocityLimit = float.Parse(roadDetails[2]);
            float directionX = float.Parse(roadDetails[3]);
            float directionY = float.Parse(roadDetails[4]);
            float directionZ = float.Parse(roadDetails[5]);

            Bounds roadBound = GameObject.Find(roadName).GetComponent<Collider>().bounds;
            //Road road = new Road(roadDetails[0], roadBound, int.Parse(roadDetails[1]),
            //    float.Parse(roadDetails[2]), float.Parse(roadDetails[3]), float.Parse(roadDetails[4]),
            //    float.Parse(roadDetails[5]));

            Road road = new Road(roadName, roadBound, rule, velocityLimit, directionX, directionY, directionZ);

            this.allRoads.Add(road);
        }
        rd.Close();
    }
    */
    public void ReadRoadsFromCsvFile()
    {
        TextAsset txt = Resources.Load("Data/Roads") as TextAsset;
        string roads = txt.text;
        string[] allLines = roads.Split('\n');
        for (int i=1;i<allLines.Length;i++)
        {
            string[] roadDetails = allLines[i].Split(',');

            string roadName = roadDetails[0];
            int rule = int.Parse(roadDetails[1]);
            float velocityLimit = float.Parse(roadDetails[2]);
            float directionX = float.Parse(roadDetails[3]);
            float directionY = float.Parse(roadDetails[4]);
            float directionZ = float.Parse(roadDetails[5]);

            Bounds roadBound = GameObject.Find(roadName).GetComponent<Collider>().bounds;
            //Road road = new Road(roadDetails[0], roadBound, int.Parse(roadDetails[1]),
            //    float.Parse(roadDetails[2]), float.Parse(roadDetails[3]), float.Parse(roadDetails[4]),
            //    float.Parse(roadDetails[5]));

            Road road = new Road(roadName, roadBound, rule, velocityLimit, directionX, directionY, directionZ);

            this.allRoads.Add(road);
        }
    }
}
