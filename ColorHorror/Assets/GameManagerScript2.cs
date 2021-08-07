using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript2 : MonoBehaviour
{
   public LevelLoader levelLoader;
   public void CompleteLevel ()
   {
       levelLoader.LoadNextLevel();
   } 

   public void ChangeToBlue ()
   {
       levelLoader.LoadBlueScene();
   }

   public void ChangeToMain()
   {
       levelLoader.LoadMain();
   } 
}
