using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BrakeBtnScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private CarController controller;
    // Start is called before the first frame update
    void Start()
    {
        this.controller = GameObject.Find("VPP Sport Coupe").GetComponent<CarController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        this.controller.Brake();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        this.controller.StopBrake();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
