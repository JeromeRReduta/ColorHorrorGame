using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///This is for the player that is in the main room
public class PlayerLevelLoader : MonoBehaviour
{
   public GameManagerScriptMain gameManager;
   public LevelLoader levelLoader;

   private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "MainRoomLoader"){
            Debug.Log("I Hit Main Room Loader");
            levelLoader.LoadMain();
        }
        if(col.gameObject.tag == "RedTP"){
            Debug.Log("I hit Red TP");
            levelLoader.LoadRedScene();
        }

        if(col.gameObject.tag == "BlueTP"){
            Debug.Log("I Hit Blue TP");
           levelLoader.LoadBlueScene();

        }
        if(col.gameObject.tag == "YellowTP"){
            Debug.Log("I hit the yellow TP");
            levelLoader.LoadYellowScene();
        }
   }
}

