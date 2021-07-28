using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics.UI;
using Assets.Route;

namespace traffic_laws
{

    public class pop_up_timer : MonoBehaviour
    {
        private CarDataHolder carData;
        private Text text;
        private RouteMapHolder route;
        Dashboard ds;
        private user_score userScore;

        void Start()
        {
            route = GameObject.Find("Route Map").GetComponent<RouteMapHolder>();
            carData = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>(); // get refference to car object

            text = GameObject.Find("Text_popup").GetComponent<Text>();
            text.text = ""; // initiate the text as empty string

            //text.fontSize = 14;
            ds = GameObject.Find("Dashboard").GetComponent<Dashboard>();
            userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        void Update()
        {
            if (route.RouteMap.NodeIsOn is Road)
            {
                if (carData.User_car.getVelocity() > (route.RouteMap.NodeIsOn as Road).VelocityLimitSize)
                {
                    gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                    text.text = "!תרתומה תוריהמה תא תרבע";
                    text.text += "\n";
                    text.text += "!טאה";
                    if (!carData.User_car.ScoreDeducted)
                    {
                        carData.User_car.ScoreDeducted = true;
                        userScore.SubtractPoints(2);
                    }
                }
                else
                {
                    gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    text.text = "";
                }
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                text.text = "";
            }
        }
    }
}