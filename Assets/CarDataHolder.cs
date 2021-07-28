using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataHolder : MonoBehaviour
{
    private GameObject car_ref;
    private Car user_car;
    private Rigidbody car_rigid;

    public Car User_car { get => user_car; set => user_car = value; }

    void Start()
    {
        this.user_car = new Car();
        this.car_ref = GameObject.Find("VPP Sport Coupe");
        this.user_car.setPosition(car_ref.GetComponent<Transform>().position.x, car_ref.GetComponent<Transform>().position.y,
            car_ref.GetComponent<Transform>().position.z);
        this.user_car.setVelocity(0);
    }

    void Update()
    {
        user_car.setPosition(car_ref.GetComponent<Transform>().position.x,
                             car_ref.GetComponent<Transform>().position.y,
                             car_ref.GetComponent<Transform>().position.z);
        user_car.setVelocity(car_ref.GetComponent<Rigidbody>().velocity.magnitude*3.6f);
        user_car.SetVelocityVector(car_ref.GetComponent<Rigidbody>().velocity);
    }
}