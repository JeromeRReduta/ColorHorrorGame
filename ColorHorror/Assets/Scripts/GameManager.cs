using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LevelLoader levelLoader;
   public void CompleteLevel ()
   {
       levelLoader.LoadNextLevel();
   } 
}
