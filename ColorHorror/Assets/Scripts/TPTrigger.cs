using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPTrigger : MonoBehaviour
{
    LevelLoader levelLoader;
    public GameManager gameManager;
    void OnTriggerEnter2D()
    {
        gameManager.CompleteLevel();
    }
}
