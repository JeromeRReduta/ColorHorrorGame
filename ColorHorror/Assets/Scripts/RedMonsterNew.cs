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
public class RedMonsterNew : NewMonster // TODO: 1) Make changing levels disable the old monsters' aggro, complete w/ stopping sounds
    // 2) Make red monster charge not track the player (or at least, so closely)
{
    /** AIPath this monster uses */
    public AIPath Path;

    /** Charge speed */
    public int chargeSpeed = 20;

    /** Whether the monster is NOT charging */
    private bool completed = true;

    /** Stores the locations of the origins of the raycasts */
    [SerializeField] GameObject chargeUp, chargeDown, chargeRight, chargeLeft;

    /** Adds backwards momentum after hitting a collider */
    [HideInInspector] public Vector3 recoil;
    private int slowDown = 0;

    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.red;
    }

    public override void DisableAggro()
    {
        base.DisableAggro();
        StopCoroutine( Charge() );
        completed = true;
        StopWalkSound();
        StopChargeSound();
    }

    public override void EnableAggro()
    {
        base.EnableAggro();
        PlayWalkSound();
        completed = false;
    }

    /**
    Attempts to charge at player every 4 seconds
    */
    public override void Update()
    {

        Vector3 dest = Path.destination;
        RaycastHit2D hit = Physics2D.Linecast(base.Rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitUp = Physics2D.Linecast(chargeUp.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitDown = Physics2D.Linecast(chargeDown.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitRight = Physics2D.Linecast(chargeRight.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitLeft = Physics2D.Linecast(chargeLeft.transform.position, dest, LayerMask.GetMask("Walls", "Player"));

        if (hit.collider != null && hitUp.collider.gameObject.CompareTag("Player") && hitDown.collider.gameObject.CompareTag("Player") && // error - bug here
            hitRight.collider.gameObject.CompareTag("Player") && hitLeft.collider.gameObject.CompareTag("Player") && completed)
        {
            completed = false;
            StartCoroutine(Charge());
        }
        if (slowDown > 3)
            {
                base.Rb.velocity = new Vector2 (0f, 0f); 
                Path.enabled = true;
            }
        
        Debug.DrawLine(chargeUp.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeDown.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeLeft.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeRight.transform.position, dest, Color.blue);
    }

    /**
    Charge at player every 4 seconds
    */
    IEnumerator Charge() // TODO: Make red monster walk towards player when not charging (low-priority)
    {
        StopWalkSound();
        PlayChargeSound();
        Vector3 charge = (Path.destination - gameObject.transform.position).normalized * chargeSpeed;
        slowDown = 0;
        recoil = charge.normalized;

        Path.enabled = false;

        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.AddForce(charge, ForceMode2D.Impulse);
        yield return new WaitForSeconds(4);
        PlayWalkSound(); // TODO: Put this before or after wait?
        StopChargeSound();
        completed = true;
        Path.enabled = true;
        // StartCoroutine(FollowPlayerInBetweenCharges());
        
    }

    IEnumerator FollowPlayerInBetweenCharges()
    {
        Path.enabled = true;
        yield return new WaitForSeconds(1);
        completed = true;
    }

    // Was thinking of making it so that each monster has a different response to colliding
    // Like Red Monster has recoil momentum for example
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        PlayHitSound(); // plays hit sound no matter what it collides with
        Vector3 reflectVector = collision.contacts[0].normal;
        slowDown++;
        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.velocity = Vector3.Reflect(recoil, reflectVector) * 20;
        recoil = base.Rb.velocity.normalized;

    }

    public void PlayChargeSound()
    {
        base.PlaySound("RedMonCharge");
    }

    public void StopChargeSound()
    {
        base.StopSound("RedMonCharge");
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("RedMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("RedMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("RedMonHit");
    }

}