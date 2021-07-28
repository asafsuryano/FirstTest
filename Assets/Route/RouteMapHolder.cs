using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Route;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class RouteMapHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private RouteMap routeMap;
    private GameObject road;
    private Bounds roadBound;
    private CarDataHolder car_data;
    private RoadHolder roadHolder;
    private TrafficLightsInCity trafficLightsInCity;
    private TitleMenuScript titleMenuScript;
    private user_score userScore;
    private MessageScript message;
    internal RouteMap RouteMap { get => routeMap; set => routeMap = value; }

    void Start()
    {
        this.routeMap = new RouteMap();
        titleMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();
        this.roadHolder = GameObject.Find("Route Map").GetComponent<RoadHolder>();
        this.trafficLightsInCity = GameObject.Find("TrafficLightInCity").GetComponent<TrafficLightsInCity>();
        this.routeMap.Nodes.AddRange(this.roadHolder.AllRoads);
        ReadAllJunctionsFromCsv();
        AddTraficLightsToJunctionLights();
        this.routeMap.NodeIsOn = routeMap.Nodes[0];
        this.car_data = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>();
        this.userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
        if (titleMenuScript.GetRouteChoice() == 1)
        {
            this.routeMap.CreateRouteFromCsvFile("Data/RouteExa");
        }
        else
        {
            this.routeMap.CreateRouteFromCsvFile("Data/RouteExa2");
        }
        this.routeMap.NextArc = this.routeMap.ArcsInRoute.Dequeue();
        message = GameObject.Find("MessageCanvas").GetComponent<MessageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("name is "+this.routeMap.NodeIsOn.Name);
        if (!this.routeMap.NodeIsOn.CheckPosition(this.car_data.User_car.getPosition())) 
        {
            if (this.routeMap.NodeIsOn.Rule == 1 && !car_data.User_car.Stopped)
            {
                userScore.SubtractPoints(5);
                car_data.User_car.ScoreDeducted = true;
                message.enableCanvas();
                message.ShowedMessage = true;
                message.MessageText.text = "!!!!רוצע רורמתב תרצע אל";
                message.MessageText.text += "\n";
                message.MessageText.text += "תודוקנ 5 ךל דרי";
            }
            if (!this.routeMap.changeNodeIsOn(this.car_data.User_car))
            {
                Debug.Log("restarted when node is wrong");
                DontDestroyOnLoad(titleMenuScript);
                message.showMessageToTellTheDriverToRestart();
            }

            car_data.User_car.ScoreDeducted = false;
            car_data.User_car.Stopped = false;
        }
    }
    /*
    public void ReadAllJunctionsFromCsv()
    {
        StreamReader rd;
#if UNITY_EDITOR
        rd = new StreamReader("Assets/Data/Junctions.csv");
#elif UNITY_STANDALONE
        rd = new StreamReader("Resources/Data/Junctions.csv");
#endif
        rd.ReadLine();
        while (!rd.EndOfStream)
        {
            string junctionString = rd.ReadLine();
            string[] junctionDetails = junctionString.Split(',');
            Bounds junctionBounds = GameObject.Find(junctionDetails[0]).GetComponent<Collider>().bounds;
            if (junctionDetails[2] == "yes")
            {
                JunctionLight junction= new JunctionLight(junctionDetails[0], junctionBounds, int.Parse(junctionDetails[1]));
                this.routeMap.Nodes.Add(junction);
            }
            else
            {
                Junction junction = new Junction(junctionDetails[0], junctionBounds, int.Parse(junctionDetails[1]));
                this.routeMap.Nodes.Add(junction);
            }
        }
    }
    */
    public void ReadAllJunctionsFromCsv()
    {
        TextAsset txt = Resources.Load("Data/Junctions") as TextAsset;
        string junctions = txt.text;
        string[] allLines = junctions.Split('\n');
        for (int i=1;i<allLines.Length;i++)
        {
            string[] junctionDetails = allLines[i].Split(',');
            Bounds junctionBounds = GameObject.Find(junctionDetails[0]).GetComponent<Collider>().bounds;
            if (junctionDetails[2] == "yes\r")
            {
                JunctionLight junction = new JunctionLight(junctionDetails[0], junctionBounds, int.Parse(junctionDetails[1]));
                this.routeMap.Nodes.Add(junction);
            }
            else
            {
                Junction junction = new Junction(junctionDetails[0], junctionBounds, int.Parse(junctionDetails[1]));
                this.routeMap.Nodes.Add(junction);
            }
        }
    }
    /*
    public void AddTraficLightsToJunctionLights()
    {
        var rd = new StreamReader("Assets/Data/TrafficLights In Junction.csv");
        rd.ReadLine();
        while (!rd.EndOfStream)
        {
            string details = rd.ReadLine();
            string[] detailsArr = details.Split(',');
            JunctionLight jun = this.routeMap.GetNodeByName(detailsArr[0]) as JunctionLight;
            jun.AddTrafficLight(this.trafficLightsInCity.GetTrafficLightByTrafficLightId(int.Parse(detailsArr[1])));
        }
        rd.Close();
    }
    */
    public void AddTraficLightsToJunctionLights() 
    {
        TextAsset txt = Resources.Load("Data/TrafficLights In Junction") as TextAsset;
        string junctionlights = txt.text;
        string[] allLines = junctionlights.Split('\n');
        for (int i=1;i<allLines.Length;i++)
        {
            string[] detailsArr = allLines[i].Split(',');
            JunctionLight jun = this.routeMap.GetNodeByName(detailsArr[0]) as JunctionLight;
            string[] arr = detailsArr[1].Split('\r');
            jun.AddTrafficLight(this.trafficLightsInCity.GetTrafficLightByTrafficLightId(int.Parse(arr[0])));
        }
    }
}
