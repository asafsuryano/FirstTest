using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DriveBtnScript : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private CarController controller;
    // Start is called before the first frame update
    void Start()
    {
        this.controller = GameObject.Find("VPP Sport Coupe").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        this.controller.Drive();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.controller.StopDrive();
    }
}
