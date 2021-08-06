using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
       inventory = GameObject.FindGameObjectsWithTag("Player").GetComponent<Inventory>(); 
    }

    
}
