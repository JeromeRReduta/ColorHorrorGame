using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public bool[] isFull;
    public GameObject[] slots;

    void Start()
    {
        isFull = new bool[3];
        slots = new GameObject[3];
        slots[0] = GameObject.FindGameObjectWithTag("Slot1");
        slots[1] = GameObject.FindGameObjectWithTag("Slot2");
        slots[2] = GameObject.FindGameObjectWithTag("Slot3");
    }
}
