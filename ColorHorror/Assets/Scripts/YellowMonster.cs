using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonster : Monster
{

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */

    public Vector3 FuturePoint {get; private set;}
    float rayCastLength;

    // Movement: Base; Special: Teleport
    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.yellow;
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("YellowMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("YellowMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("YellowMonHit");
    }

    public void PlayTeleportSound()
    {
        base.PlaySound("YellowMonTP");
    }
}
