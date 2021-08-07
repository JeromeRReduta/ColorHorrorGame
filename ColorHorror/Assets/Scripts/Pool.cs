using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Pool : MonoBehaviour
{
    public static int paintTimeFrames = 1800;
    private int countDown = paintTimeFrames;
    public Monster whiteMonster; // TODO: Make this any monster later
    public Player player;
    public enum PoolColor {White, Red, Yellow, Blue};
    [SerializeField] public PoolColor color;
    private Color realColor;

    public PolygonCollider2D col;

    public void Awake()
    {
        if (color == PoolColor.White) {
            ChangeColorTo(Color.white);
        }
        else if (color == PoolColor.Red) {
            ChangeColorTo(Color.red);
        }
        else if (color == PoolColor.Yellow) {
            ChangeColorTo(Color.yellow);
        }
        else if (color == PoolColor.Blue) {
            ChangeColorTo(Color.blue);
        }
    }

    public void ChangeColorTo(Color color) {
            realColor = color;
            GetComponent<Renderer>().material.color = color;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("TAG: " + col.gameObject.tag);

        if ( string.Equals(col.gameObject.tag, "Player") )
        {
            player.ChangeColorTo(realColor);
        }

        

        //Player.ChangeColorTo(color);
        /*
            if(col.gameObject.tag == "RedPool"){
            StartCoroutine(ChangeColorRed());
            }

            if(col.gameObject.tag == "BluePool"){
            StartCoroutine(ChangeColorBlue());
            }

            if(col.gameObject.tag == "YellowPool"){
            StartCoroutine(ChangeColorYellow());
        }
        */
    }

/*
    IEnumerator ChangeColorRed()
    {
        Player.GetComponent<SpriteRenderer>().color = Color.red;
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

*/
}
