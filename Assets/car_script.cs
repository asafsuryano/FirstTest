using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Route;

public class car_script : MonoBehaviour
{
    private CarDataHolder CarData;
    private RouteMapHolder routeMap;
    public KeyCode driveMode;
    public KeyCode reverseMode;
    private Text speedText;
    private TitleMenuScript titleMenuScript;
    private user_score userScore;
    private MessageScript message;
    
    public void Start()
    {
        this.CarData = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>();
        this.routeMap = GameObject.Find("Route Map").GetComponent<RouteMapHolder>();
        this.speedText = GameObject.Find("SpeedMeterText").GetComponent<Text>();
        titleMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();
        userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
        message = GameObject.Find("MessageCanvas").GetComponent<MessageScript>();
    }

    public void Update()
    {
        if (this.routeMap.RouteMap.NodeIsOn is JunctionLight)
        {
            var j = routeMap.RouteMap.NodeIsOn as JunctionLight;
            
            if (!j.IsDrivingAccordingToLights(routeMap.RouteMap.PreviousArc.Source as Road))
            {
                if (!CarData.User_car.ScoreDeducted)
                {
                    userScore.SubtractPoints(10);
                    CarData.User_car.ScoreDeducted = true;
                    message.enableCanvas();
                    message.ShowedMessage = true;
                    message.MessageText.fontSize = 100;
                    message.MessageText.text = "!!!!םודא רוזמרב תרבע";
                    message.MessageText.text += "\n";
                    message.MessageText.text += "תודוקנ 10 ךל דרי";
                }
            }
        }
        else if (this.routeMap.RouteMap.NodeIsOn is Road)
        {
            var j = routeMap.RouteMap.NodeIsOn as Road;
            if (this.CarData.User_car.getVelocity() > 5)
            {
                if (j.Direction.x == 0)
                {

                    if (Math.Round(this.CarData.User_car.GetVelocityVector().normalized.z) != j.Direction.z)
                    {
                        DontDestroyOnLoad(titleMenuScript);
                        message.showMessageToTellTheDriverToRestart();
                    }
                }
                else if (j.Direction.z == 0)
                {
                    if (Math.Round(this.CarData.User_car.GetVelocityVector().normalized.x) != j.Direction.x)
                    {
                        DontDestroyOnLoad(titleMenuScript);
                        message.showMessageToTellTheDriverToRestart();
                    }
                }
                else
                {
                    if (Math.Round(this.CarData.User_car.GetVelocityVector().normalized.x) != j.Direction.x
                        && Math.Round(this.CarData.User_car.GetVelocityVector().normalized.z) != j.Direction.z)
                    {
                        DontDestroyOnLoad(titleMenuScript);
                        message.showMessageToTellTheDriverToRestart();
                    }
                }
            }
            if (this.CarData.User_car.getVelocity() < 1)
            {
                CarData.User_car.Stopped = true;
            }
        }
        if (Input.GetKey(this.driveMode))
        {
            this.CarData.User_car.SetMode(1);
        }
        else if (Input.GetKey(this.reverseMode))
        {
            this.CarData.User_car.SetMode(2);
        }
        this.speedText.text = (int)this.CarData.User_car.getVelocity() + "\n" + "ש\"מק";  //  קמ"ש
    }

}