using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class User
{
    private string username;
    private int points;
    private string drivingLevel;
    private string routeChosen;

    public User(string username, int points, string drivingLevel)
    {
        setUsername(username);
        setPoints(points);
        setDrivingLevel(drivingLevel);
    }

    public User()
    {
        username = "";
        drivingLevel = "";
        routeChosen = "";
        points = 100;
    }

    public int getPoints()
    {
        return points;
    }

    public void setPoints(int points)
    {
        this.points = points;
    }

    public void setUsername(string username)
    {
        this.username = username;
    }

    public string getUsername()
    {
        return this.username;
    }

    public void setDrivingLevel(string drivingLevel)
    {
        this.drivingLevel = drivingLevel;
    }
    public string GetDrivingLevel()
    {
        return drivingLevel;
    }

    public void SetRouteChosen(string routeChosen)
    {
        this.routeChosen = routeChosen;
    }
    public string GetRouteChosen()
    {
        return routeChosen;
    }
}