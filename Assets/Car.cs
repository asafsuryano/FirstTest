using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    //private GameObject car;
    private Vector3 position;
    private float velocity;
    private Vector3 velocityVector;
    private int mode;
    private bool scoreDeducted;
    private bool stopped;

    public bool ScoreDeducted { get => scoreDeducted; set => scoreDeducted = value; }
    public bool Stopped { get => stopped; set => stopped = value; }

    public Car()
    {
        //mode=1- dirve(D), mode=2-reverse(R)
        this.mode = 1;
        this.scoreDeducted = false;
        this.stopped = false;
        //this.accelarationVector = new Vector3(0,0,0);
        //this.velocityVector = new Vector3(0, 0, 0);
        //car = GameObject.Find("VPP Sport Coupe"); // get refference to car object
        //position.Set(car.GetComponent<Transform>().position.x, car.GetComponent<Transform>().position.y, car.GetComponent<Transform>().position.z);
    }

    public Vector3 getPosition()
    {
        return position;
    }

    public void setPosition(float x, float y, float z)
    {
        position.Set(x, y, z);
    }

    public float getVelocity()
    {
        return velocity;
    }

    public void setVelocity(float vel)
    {
        velocity = vel;
    }

    public Vector3 GetVelocityVector()
    {
        return this.velocityVector;
    }

    public void SetVelocityVector(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }
    public void SetMode(int mode)
    {
        this.mode = mode;
    }
    public int GetMode()
    {
        return this.mode;
    }
}