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
public class BlueMonster : Monster // TODO: Spawning logic
{

    public Player player;

    public override void Start()
    {
        base.Start();
        base.color = Color.blue;
    }
    /**
    Does nothing, since A* algorithm handles all movement logic 
    */
    public override void Update()
    {

        if (base.color == player.currentColor)
        {
            GetComponent<TempEnemyScript>().aiPath.enabled = false;
        }

        GetComponent<TempEnemyScript>().aiPath.enabled = true;
    }

    public override void PlayWalkSound()
    {
        Debug.Log("AUDIO: " + base.Audio != null ? "null" : base.Audio.ToString());
        base.Audio.Play("BlueMonWalk");
    }

    public override void StopWalkSound()
    {
        base.Audio.Stop("BlueMonWalk");
    }

    public override void PlayHitSound()
    {
        base.Audio.Play("BlueMonHit");
    }






}
