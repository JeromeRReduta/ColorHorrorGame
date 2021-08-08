using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Class whose sole responsibility is to represent the white monster and its behavior.

WHITE MONSTER BEHAVIOR:
1) After X seconds, spawn at the entrance of the region
2) Chase player indefinitely
3) If it hits player, hurts player for 1 damage and continues chasing
*/
public class WhiteMonster : Monster // TODO: Spawning logic
{

    public AudioManager audioManager;

    public override void Start()
    {
        base.Start();
        Debug.Log("STARTING SOUND");
        audioManager.Play("MonsterWalk");
    }
    /**
    Does nothing, since A* algorithm handles all movement logic 
    */
    public override void Update()
    {
    }




}
