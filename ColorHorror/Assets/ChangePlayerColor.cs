using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChangePlayerColor : MonoBehaviour
{
    public float paintTime = 3f;
    public AIPath Path;
    public GameObject RedMonster;
    public GameObject Player;
    //public GameObject BlueMonster;
    //public GameObject YellowMonster;

    public PolygonCollider2D redPool;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "RedPool"){
           StartCoroutine(ChangeColorRed());
        }

        if(col.gameObject.tag == "BluePool"){
           StartCoroutine(ChangeColorBlue());
        }

        if(col.gameObject.tag == "YellowPool"){
           StartCoroutine(ChangeColorYellow());
        }
        
    }

    IEnumerator ChangeColorRed()
    {
        Player.GetComponent<Renderer>().material.color = new Color(176,0,0);
        Debug.Log("HIT RED POOL");

        Path.enabled = false;
        RedMonster.GetComponent<RedMonsterNew>().enabled = false;
        RedMonster.GetComponent<RedMonsterNew>().Rb.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(paintTime);
        transform.GetComponent<Renderer>().material.color = new Color(255,255,255);
        Debug.Log("I AM NO LONGER RED");
        
        RedMonster.GetComponent<RedMonsterNew>().enabled = true;
        Path.enabled = true;
    }

    IEnumerator ChangeColorBlue()
    {
        transform.GetComponent<Renderer>().material.color = new Color(0,189,255);
        Debug.Log("HIT BLUE POOL");

        //Path.enabled = false;  //Figure out how to disable AI path
        //BlueMonster.GetComponent<RedMonsterNew>().enabled = false; //Would have to disable the Monster script due to how the scripts work////

        yield return new WaitForSeconds(paintTime);
        transform.GetComponent<Renderer>().material.color = new Color(255,255,255);
        Debug.Log("I AM NO LONGER BLUE");
        
        //BlueMonster.GetComponent<RedMonsterNew>().enabled = true;
        //Path.enabled = true;
    }

    IEnumerator ChangeColorYellow()
    {
        transform.GetComponent<Renderer>().material.color = new Color(233,236,0); //Figure out color change
        Debug.Log("HIT YELLOW POOL");

        //Path.enabled = false;          //Figure out how to disable AI path
        //BlueMonster.GetComponent<RedMonsterNew>().enabled = false; //Would have to disable the Monster script due to how the scripts work////

        yield return new WaitForSeconds(paintTime);
        transform.GetComponent<Renderer>().material.color = new Color(255,255,255); //Figure out color change
        Debug.Log("I AM NO LONGER YELLOW");
        
        //BlueMonster.GetComponent<RedMonsterNew>().enabled = true;
        //Path.enabled = true;
    }


}
