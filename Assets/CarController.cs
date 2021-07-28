using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleInputNamespace;
using UnityEngine.EventSystems;

public class CarController : MonoBehaviour
{
    private CarDataHolder car_ref;
    private Button driveBtn;
    private Button brakeBtn;
    private bool isDriveBtnPressed;
    private bool isBrakeBtnPressed;
    [SerializeField] public WheelCollider FRWheel;
    [SerializeField] public WheelCollider FLWheel;
    [SerializeField] public WheelCollider RRWheel;
    [SerializeField] public WheelCollider RLWheel;
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private float brakeForce;
    private float axis;
    private float steering;
    private MySteeringWheel wheel;
    private VRConfiguration vrConfiguration;
    // Start is called before the first frame update
    void Start()
    {
        this.brakeForce = 0;
        this.FLWheel = GameObject.Find("WheelFL").GetComponent<WheelCollider>();
        this.FLWheel.gameObject.SetActive(true);
        this.FRWheel = GameObject.Find("WheelFR").GetComponent<WheelCollider>();
        this.FRWheel.gameObject.SetActive(true);
        this.RRWheel = GameObject.Find("WheelRR").GetComponent<WheelCollider>();
        this.RRWheel.gameObject.SetActive(true);
        this.RLWheel = GameObject.Find("WheelRL").GetComponent<WheelCollider>();
        this.RLWheel.gameObject.SetActive(true);
        this.car_ref = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>();
        this.vrConfiguration = GameObject.Find("VRholder").GetComponent<VRConfiguration>();
        this.axis = 0;
        this.steering = 0;
        if (Application.isMobilePlatform)
        {
            this.driveBtn = GameObject.Find("driveBtn").GetComponent<Button>();
            this.brakeBtn = GameObject.Find("brakeBtn").GetComponent<Button>();
            this.wheel = GameObject.Find("SteeringWheel").GetComponent<MySteeringWheel>();
            if (this.vrConfiguration.MainMenuScript.IsVr)
            {
                this.driveBtn.enabled = false;
                this.brakeBtn.enabled = false;
                this.wheel.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                this.brakeForce = 2000f;
            }
            else
            {
                this.brakeForce = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!Application.isMobilePlatform)
        {
            axis = Input.GetAxis("Vertical");
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        }
        else
        {
            if (vrConfiguration.MainMenuScript.IsVr)
            {
                steering = GetSteeringFromAngle(vrConfiguration.SteeringAngle);
            }
            else
            {
                steering = GetSteeringFromAngle(this.wheel.Steering());
            }
        }
        if (car_ref.User_car.GetMode() == 1)
        {
            float motor = maxMotorTorque * axis; 
            this.FLWheel.steerAngle = steering;
            this.FRWheel.steerAngle = steering;
            this.FRWheel.motorTorque = motor;
            this.FLWheel.motorTorque = motor;
            this.RLWheel.motorTorque = motor;
            this.RRWheel.motorTorque = motor;
            this.FRWheel.brakeTorque = this.brakeForce;
            this.FLWheel.brakeTorque = this.brakeForce;
            this.RLWheel.brakeTorque = this.brakeForce;
            this.RRWheel.brakeTorque = this.brakeForce;
        }
        else
        {
            float motor = maxMotorTorque * axis;
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            this.FLWheel.steerAngle = -1*steering;
            this.FRWheel.steerAngle = -1*steering;
            this.FRWheel.motorTorque = -1 * motor;
            this.FLWheel.motorTorque = -1 * motor;
            this.RLWheel.motorTorque = -1 * motor;
            this.RRWheel.motorTorque = -1 * motor;
            this.FRWheel.brakeTorque = this.brakeForce;
            this.FLWheel.brakeTorque = this.brakeForce;
            this.RLWheel.brakeTorque = this.brakeForce;
            this.RRWheel.brakeTorque = this.brakeForce;
        }
    }
    public void Drive()
    {
        axis = 1;
    }
    public void StopDrive()
    {
        axis = 0;
    }
    public void Brake()
    {
        this.brakeForce = 2000f;
    }
    public void StopBrake()
    {
        this.brakeForce = 0;
    }
    public float GetSteeringFromAngle(float angle)
    {
        return angle*maxSteeringAngle;
    }
}
