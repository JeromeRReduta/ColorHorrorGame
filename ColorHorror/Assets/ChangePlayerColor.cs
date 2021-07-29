using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    public PolygonCollider2D redPool;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "RedPool"){
            ChangeColorRed();
        }
        
    }

    private void ChangeColorRed()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("HIT RED POOL");
    }


}
