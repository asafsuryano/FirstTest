using UnityEngine; 

public class CarDriver : MonoBehaviour
{ 
    public float forwardSpeed = 40.0f; 
    public float backwardSpeed = 20.0f; 
    public float rotateSpeed = 80.0f; 

    // Use this for initialization 
    void Start () { 
     
    } 
     
    // Update is called once per frame 
    void Update () { 
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position -= transform.forward * forwardSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * backwardSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate( 0.0f, -rotateSpeed * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate( 0.0f, rotateSpeed * Time.deltaTime, 0.0f);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate( 0.0f, rotateSpeed * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate( 0.0f, -rotateSpeed * Time.deltaTime, 0.0f);
            }
        }
    }
}