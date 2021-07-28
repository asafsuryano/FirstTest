using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driving_Guide
{
    //private ArrayList rules = new ArrayList();
    private DrivingDirectionSign current_sign;

    public Driving_Guide()
    {
        current_sign = DrivingDirectionSign.Straight;  // start value
    }

    public DrivingDirectionSign getSign()
    {
        return current_sign;
    }

    public void setSign(DrivingDirectionSign current_sign)
    {
        this.current_sign = current_sign;
    }

    //public object getRule(int index)
    //{
    //    return rules[index];
    //}
}