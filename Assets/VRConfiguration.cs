using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;

public class VRConfiguration : MonoBehaviour
{
    private TitleMenuScript mainMenuScript;
    private CarController controller;
    private float steeringAngle;

    public float SteeringAngle { get => steeringAngle; set => steeringAngle = value; }
    public TitleMenuScript MainMenuScript { get => mainMenuScript; set => mainMenuScript = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GameObject.Find("VPP Sport Coupe").GetComponent<CarController>();
        mainMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();
        if (mainMenuScript.IsVr)
        {
            StartCoroutine(StartXR());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenuScript.IsVr)
        {
            Api.UpdateScreenParams();
        }
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19) // the number of characters in ps4 controller name
            {
                print("PS4 CONTROLLER IS CONNECTED");
                if (Input.GetButton("Fire1"))
                {
                    this.controller.Drive();
                    this.controller.StopBrake();
                }
                else if (Input.GetButton("Fire2"))
                {
                    this.controller.StopDrive();
                    this.controller.Brake();
                }
                else
                {
                    this.controller.StopDrive();
                    this.controller.StopBrake();
                }
                steeringAngle=Input.GetAxis("Horizontal");
            }
        }
    }
    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }
}
