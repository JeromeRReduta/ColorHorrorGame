using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelLoader : MonoBehaviour
{
   public GameManagerScriptMain gameManager;

   private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "MainRoomLoader"){
            Debug.Log("I Hit Main Room Loader");
           gameManager.ChangeToMain();
        }
        if(col.gameObject.tag == "RedTP"){
            Debug.Log("I hit Red TP");
            gameManager.ChangeToMain();
        }

        if(col.gameObject.tag == "BlueTP"){
            Debug.Log("I Hit Blue TP");
           gameManager.ChangeToBlue();

    }
}
}
