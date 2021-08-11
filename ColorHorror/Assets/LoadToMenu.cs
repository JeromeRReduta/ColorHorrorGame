using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void GoToMenu(){
        levelLoader.LoadMainMenu();
        Debug.Log("Going to main menu");
    }
}
