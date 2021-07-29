using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChangePlayerColor : MonoBehaviour
{
    public float paintTime = 10f;
    public AIPath Path;
    //public GameObject RedMonster;

    public PolygonCollider2D redPool;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "RedPool"){
           StartCoroutine(ChangeColorRed());
        }
        
    }

    IEnumerator ChangeColorRed()
    {
        transform.GetComponent<Renderer>().material.color = new Color(0,0,0);
        Debug.Log("HIT RED POOL");
        //Path.enabled = false;

        this.GetComponent<RedMonsterNew>().enabled = false;

        yield return new WaitForSeconds(paintTime);
        transform.GetComponent<Renderer>().material.color = new Color(255,255,255);
        Debug.Log("I AM NO LONGER RED");
        
        this.GetComponent<RedMonsterNew>().enabled = true;
        //Path.enabled = true;
    }


}
