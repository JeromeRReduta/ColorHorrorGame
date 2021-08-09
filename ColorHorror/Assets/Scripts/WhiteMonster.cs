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
public class WhiteMonster : NewMonster
{
    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.white;
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("WhiteMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("WhiteMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("WhiteMonHit");
    }

    // Note: Must override onenable and ondisable, as white monsters never de-aggro player
    public override void OnEnable()
    {

    }

    public override void OnDisable()
    {

    }
}
