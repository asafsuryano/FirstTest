using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAndroidRunning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform!=RuntimePlatform.WindowsEditor && Application.platform!=RuntimePlatform.WindowsPlayer)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
