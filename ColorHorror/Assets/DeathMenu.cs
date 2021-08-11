using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void RestartGame(){
        levelLoader.LoadMain();
        Debug.Log("Game has restarted");
    }

    public void Quit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
