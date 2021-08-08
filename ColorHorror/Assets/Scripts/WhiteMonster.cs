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
    /**
    Does nothing, since A* algorithm handles all movement logic 
    */
    public override void Update()
    {
    }

    public override void PlayWalkSound()
    {
        Debug.Log("AUDIO: " + base.Audio != null ? "null" : base.Audio.ToString());
        base.Audio.Play("WhiteMonWalk");
    }

    public override void StopWalkSound()
    {
        base.Audio.Stop("WhiteMonWalk");
    }

    public override void PlayHitSound()
    {
        base.Audio.Play("WhiteMonHit");
    }






}
