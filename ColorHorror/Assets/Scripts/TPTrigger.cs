using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPTrigger : MonoBehaviour
{
    //LevelLoader levelLoader;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BlueTP")
        gameManager.ChangeToBlue();
        Debug.Log("Hit Blue TP");
    }
}
