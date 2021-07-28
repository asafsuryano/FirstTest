using UnityEngine;
using Assets.Route;
using UnityEngine.UI;
using System.Collections;
using System;

public class driving_guide_script : MonoBehaviour
{
    private Driving_Guide drivingGuide;
    private GameObject drivingGuideGameObject;
    private ArcsPairDataHolder arcsDataHolder;
    private RouteMapHolder routeMapHolder;
    private Arc currentArc, nextArc;
    private Sprite leftSign, rightSign, straightSign, backwardSign;
    private Image signImage;
    private DrivingDirectionSign old_drivingDirectionSign;
    private Text textGuide;
    private bool theDrivingIsStarted;
    private CarDataHolder CarData;

    void Start()
    {
        drivingGuide = new Driving_Guide();
        drivingGuideGameObject = GameObject.Find("Driving_Guide");

        arcsDataHolder = GameObject.Find("arcs").GetComponent<ArcsPairDataHolder>();
        routeMapHolder = GameObject.Find("Route Map").GetComponent<RouteMapHolder>();

        currentArc = this.routeMapHolder.RouteMap.NextArc;  // take the first arc of the routh.
        nextArc = this.routeMapHolder.RouteMap.ArcsInRoute.Peek();  // take arc from RouteMapHolder queue.

        // add image to drivingGuideGameObject:
        signImage = drivingGuideGameObject.GetComponent<Image>();
        old_drivingDirectionSign = DrivingDirectionSign.Straight;

        leftSign = Resources.Load<Sprite>("DrivingDirectionSign/left_arrow");
        rightSign = Resources.Load<Sprite>("DrivingDirectionSign/right_arrow");
        straightSign = Resources.Load<Sprite>("DrivingDirectionSign/straight_arrow");
        backwardSign = Resources.Load<Sprite>("DrivingDirectionSign/U_turn_left_arrow");

        signImage.sprite = straightSign;

        textGuide = GameObject.Find("text_guide").GetComponent<Text>();

        CarData = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>();
        theDrivingIsStarted = false;
    }

    void Update()
    {
        if (!checkIfTheDrivingIsFinished())
            checkNextRouthToDrive();
        showSignOnDashboard(drivingGuide.getSign());
        if (!theDrivingIsStarted)
            checkIfDrivingIsStated();
    }

    private bool checkIfTheDrivingIsFinished()
    {
        if (routeMapHolder.RouteMap.ArcsInRoute.Count <= 1)
        {
            if (routeMapHolder.RouteMap.ArcsInRoute.Count == 0)
                textGuide.text = "המייתסה העיסנה";  //  הנסיעה הסתיימה
            return true;
        }
        return false;
    }

    private void checkIfDrivingIsStated()
    {
        if (CarData.User_car.getVelocity() > 5)
        {
            theDrivingIsStarted = true;
            textGuide.text = "";
        }
    }

    private void checkNextRouthToDrive()
    {        
        for (int i = 0; i < arcsDataHolder.ArcsPairs.Count ; i++)
        {
            if (compareArcsBySourceAndDestination(currentArc, arcsDataHolder.ArcsPairs[i].getArcSource())
                && compareArcsBySourceAndDestination(nextArc, arcsDataHolder.ArcsPairs[i].getArcDestination())
                && drivingGuide.getSign() != arcsDataHolder.ArcsPairs[i].getDirectionSign())
            {
                setSignForNextRouth(arcsDataHolder.ArcsPairs[i].getDirectionSign());
            }
        }
        updateTheCurrectAndNextArcs();        
    }

    private void updateTheCurrectAndNextArcs()
    {
        if (this.routeMapHolder.RouteMap.ArcsInRoute.Count > 0 &&
            nextArc != this.routeMapHolder.RouteMap.ArcsInRoute.Peek())
        {
            currentArc = nextArc;
            nextArc = routeMapHolder.RouteMap.ArcsInRoute.Peek();
        }
    }

    private void setSignForNextRouth(DrivingDirectionSign drivingDirectionSign)
    {
        //print(drivingDirectionSign);
        drivingGuide.setSign(drivingDirectionSign);
    }

    private void showSignOnDashboard(DrivingDirectionSign drivingDirectionSign)
    {
        if (old_drivingDirectionSign != drivingDirectionSign)
        {
            old_drivingDirectionSign = drivingDirectionSign;
            switch (drivingDirectionSign)
            {
                case DrivingDirectionSign.Right:
                    signImage.sprite = rightSign;
                    break;
                case DrivingDirectionSign.Left:
                    signImage.sprite = leftSign;
                    break;
                case DrivingDirectionSign.Backward:
                    signImage.sprite = backwardSign;
                    break;
                case DrivingDirectionSign.Straight:
                    signImage.sprite = straightSign;
                    break;
            }
        }
    }

    private bool compareArcsBySourceAndDestination(Arc arc1, Arc arc2)
    {
        if (arc1.Source.Name == arc2.Source.Name && arc1.Destination.Name == arc2.Destination.Name)
            return true;
        else return false;
    }

}
