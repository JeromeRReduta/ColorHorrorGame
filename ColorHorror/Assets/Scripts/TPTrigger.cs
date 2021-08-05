using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void Method1()
    {
        gameManager.ChangeToBlue();
        //gameManager.CompleteLevel();
        Debug.Log("Hit Blue TP");
    }
}
