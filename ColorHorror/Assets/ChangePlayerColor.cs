using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    public PolygonCollider2D redPool;
    private void OnTriggerEnter2D()
    {
        if(redPool.isTrigger){
            ChangeColorRed();
        }
        
    }

    private void ChangeColorRed()
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
        Debug.Log("HIT RED POOL");
    }


}
