using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
Class whose sole responsibility is to represent the red monster.

Red monster behavior:
1) Move towards player indefinitely
2) Every 2 seconds, charge towards player location in a straight line until it hits something
*/ 
public class RedMonster : Monster
{
    /** AIPath this monster uses */
    public AIPath Path;

    /** Charge speed */
    public int chargeSpeed = 200;

    /** Whether the monster is NOT charging */
    private bool completed = true;

    /**
    Attempts to charge at player every 2 seconds
    */
    public override void Update()
    {
        Vector3 dest = Path.destination;
        RaycastHit2D hit = Physics2D.Linecast(base.Rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") && completed)
        {
            completed = false;
            StartCoroutine(Charge());
        }
        
        Debug.DrawLine(gameObject.transform.position, dest, Color.blue);
    }

    /**
    Charge at player every 2 seconds
    */
    IEnumerator Charge() // TODO: Make red monster walk towards player when not charging (low-priority)
    {
        Vector3 charge = (Path.destination - gameObject.transform.position).normalized * chargeSpeed;
        Path.enabled = false;

        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.AddForce(charge, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(1);

        Path.enabled = true;
        completed = true;
        
    }

    public override void PlayWalkSound()
    {
        base.Audio.Play("RedMonWalk");
    }

        public override void StopWalkSound()
    {
        base.Audio.Stop("RedMonWalk");
    }

    public override void PlayHitSound()
    {
        base.Audio.Play("RedMonHit");
    }
}
