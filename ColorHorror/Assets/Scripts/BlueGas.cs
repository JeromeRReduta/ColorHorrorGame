using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGas : MonoBehaviour
{
    [SerializeField] GameObject mainLights;
    Camera cam;

    void OnTriggerEnter2D()
    {
        mainLights.SetActive(true);
        cam = this.gameObject.GetComponentInChildren<Camera>();
       
        cam.enabled = true;

    }

    void OnTriggerExit2D()
    {
        mainLights.SetActive(false);
        cam = this.gameObject.GetComponentInChildren<Camera>();
        cam.enabled = false;
      
    }
}
