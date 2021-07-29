using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        ChangeColorRed();
    }

    private void ChangeColorRed()
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
        Debug.Log("HIT RED POOL");
    }


}
