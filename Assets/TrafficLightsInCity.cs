using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.IO;

public class TrafficLightsInCity : MonoBehaviour
{
    private List<GameObject> trafficLightsGraphic;
    private List<TrafficLight> trafficLightsInfo;
    //private int numOfTrafficLights = 5;
    internal List<TrafficLight> TrafficLightsInfo { get => trafficLightsInfo; set => trafficLightsInfo = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.trafficLightsGraphic = new List<GameObject>();
        this.trafficLightsInfo = new List<TrafficLight>();
        AddAllTrafficLight();
    }

    // Update is called once per frame
    void Update()
    {
        Renderer redRenderer;
        Renderer yellowRenderer;
        Renderer greenRenderer;
        for (int i=0;i<this.trafficLightsInfo.Count;i++)
        {
            this.trafficLightsInfo[i].CheckAndChangeState();
            greenRenderer = this.trafficLightsGraphic[i].transform.GetChild(4).GetComponent<Renderer>();
            yellowRenderer = this.trafficLightsGraphic[i].transform.GetChild(5).GetComponent<Renderer>();
            redRenderer = this.trafficLightsGraphic[i].transform.GetChild(6).GetComponent<Renderer>();
            switch (this.trafficLightsInfo[i].State)
            {
                case 0:
                    greenRenderer.material.SetColor("_EmissionColor", Color.black);
                    yellowRenderer.material.SetColor("_EmissionColor", Color.black);
                    redRenderer.material.SetColor("_EmissionColor", Color.red);
                    break;
                case 1:
                    greenRenderer.material.SetColor("_EmissionColor", Color.black);
                    yellowRenderer.material.SetColor("_EmissionColor", Color.yellow);
                    redRenderer.material.SetColor("_EmissionColor", Color.red);
                    break;
                case 2:
                    greenRenderer.material.SetColor("_EmissionColor", Color.green);
                    yellowRenderer.material.SetColor("_EmissionColor", Color.black);
                    redRenderer.material.SetColor("_EmissionColor", Color.black);
                    break;
                case 3:
                    greenRenderer.material.SetColor("_EmissionColor", Color.black);
                    yellowRenderer.material.SetColor("_EmissionColor", Color.yellow);
                    redRenderer.material.SetColor("_EmissionColor", Color.black);
                    break;
                default:
                    break;
            }
        }
    }

    public TrafficLight GetTrafficLightByRoadName(string name)
    {
        for (int i=0;i< trafficLightsInfo.Count;i++)
        {
            if(trafficLightsInfo[i].RoadNameConnectedTo==name)
            {
                return trafficLightsInfo[i];
            }
        }
        return null;
    }

    public TrafficLight GetTrafficLightByTrafficLightId(int id)
    {
        for (int i=0;i<this.trafficLightsInfo.Count;i++)
        {
            if (this.trafficLightsInfo[i].Id==id)
            {
                return trafficLightsInfo[i];
            }
        }
        return null;
    }
    /*
    public void AddAllTrafficLight()
    {
        StreamReader rd;
#if UNITY_EDITOR
        rd = new StreamReader("Assets/Data/Traffic lights.csv");
#elif UNITY_STANDALONE_WIN
        rd = new StreamReader("Resources/Data/Traffic lights.csv");
#endif
        rd.ReadLine();
        int i = 0;
        while (!rd.EndOfStream && i<numOfTrafficLights)
        {
            i++;
            string trafficString = rd.ReadLine();
            string[] trafficDetails = trafficString.Split(',');
            TrafficLight light = new TrafficLight(int.Parse(trafficDetails[0]), int.Parse(trafficDetails[1]),
                int.Parse(trafficDetails[2]), int.Parse(trafficDetails[3]), int.Parse(trafficDetails[4])
               , int.Parse(trafficDetails[5]) , trafficDetails[6]);
            if (trafficDetails[7]=="yes")
            {
                this.trafficLightsGraphic.Add(GameObject.Find("TrafficLight "+ trafficDetails[6]+"-1"));
                this.trafficLightsInfo.Add(light);
            }
            else
            {
                this.trafficLightsGraphic.Add(GameObject.Find("TrafficLight " + trafficDetails[6]));
                this.trafficLightsInfo.Add(light);
            }
        }
        rd.Close();
    }
    */
    public void AddAllTrafficLight()
    {
        TextAsset txt = Resources.Load("Data/Traffic lights") as TextAsset;
        string trafficLights = txt.text;
        string[] allLines = trafficLights.Split('\n');
        for (int i=1;i<6;i++)
        {
            string[] trafficDetails = allLines[i].Split(',');
            TrafficLight light = new TrafficLight(int.Parse(trafficDetails[0]), int.Parse(trafficDetails[1]),
                int.Parse(trafficDetails[2]), int.Parse(trafficDetails[3]), int.Parse(trafficDetails[4])
               , int.Parse(trafficDetails[5]), trafficDetails[6]);
            if (trafficDetails[7] == "yes")
            {
                this.trafficLightsGraphic.Add(GameObject.Find("TrafficLight " + trafficDetails[6] + "-1"));
                this.trafficLightsInfo.Add(light);
            }
            else
            {
                this.trafficLightsGraphic.Add(GameObject.Find("TrafficLight " + trafficDetails[6]));
                this.trafficLightsInfo.Add(light);
            }
        }
    }
}
