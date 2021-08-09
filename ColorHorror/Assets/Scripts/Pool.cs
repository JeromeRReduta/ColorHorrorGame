using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Pool : MonoBehaviour
{

    public delegate void PoolAction(Color color);
    public static event PoolAction OnEnteringPool;

    public enum PoolColor {Red, Yellow, Blue};
    public PoolColor color;
    private Color realColor;
    public AudioManager audioManager; // TODO: Get rid of these w/ events

    public void Awake()
    {
        if (color == PoolColor.Red) {
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

        // for lit version
        // var block = new MaterialPropertyBlock();
        // block.SetColor("_BaseColor", color);
        // GetComponent<Renderer>().SetPropertyBlock(block);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ENTERING POOL BUT MAYBE NOT PLAYER");
        Debug.Log("NOT POOL TAG: " + col.gameObject.tag);
        if ( string.Equals(col.gameObject.tag, "Player") && OnEnteringPool != null )
        {
            Debug.Log("ENTERING POOL");
            audioManager.Play("EnterPool");

            Debug.Log("POOL CHANGING PLAYER COLOR TO: " + realColor);
            OnEnteringPool(realColor);
        }
    }
}
