using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRed : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "RedPool"){
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
