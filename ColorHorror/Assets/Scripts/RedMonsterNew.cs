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

    public static int chargeDefaultCooldown = 3000;
    [SerializeField] private int chargeCurrentCooldown;

    /** Whether the monster is NOT charging */
    private bool currentlyCharging;

    /** Stores the locations of the origins of the raycasts */
    [SerializeField] GameObject chargeUp, chargeDown, chargeRight, chargeLeft;

    /** Adds backwards momentum after hitting a collider */
    [HideInInspector] public Vector3 recoil;
    private int numOfBounces = 0; // TODO: Better name (e.g. numOfBouncesCounter)

    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.red;
        chargeCurrentCooldown = chargeDefaultCooldown;
        currentlyCharging = false;
    }

    public override void DisableAggro()
    {
        base.DisableAggro();
        base.Rb.velocity = Vector2.zero;
        currentlyCharging = false;
        StopWalkSound();
        StopChargeSound();
    }

    public override void EnableAggro()
    {
        base.EnableAggro();
        PlayWalkSound();
        currentlyCharging = true;
    }

    /**
    Attempts to charge at player every 4 seconds
    */
    public override void Update()
    {
        if (chargeCurrentCooldown > 0)
        {
            chargeCurrentCooldown--;
        }
        else if (chargeCurrentCooldown == 0 && !currentlyCharging)
        {
            RaycastHit2D ThingInLineOfSight = Physics2D.Linecast(base.Rb.transform.position, Path.destination, LayerMask.GetMask("Walls", "Player"));

            if (ThingInLineOfSight != null
                && ThingInLineOfSight.collider != null
                && ThingInLineOfSight.collider.gameObject != null
                && ThingInLineOfSight.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("CHAAAAAAAAAAAAAAAAAAAAAAARGE");
                Path.enabled = false;
                currentlyCharging = true;
                Charge();
            }

        }
        else if (currentlyCharging && numOfBounces > 3)
        {
            base.Rb.velocity = new Vector2 (0f, 0f); 
            Path.enabled = true;
            currentlyCharging = false;
            chargeCurrentCooldown = chargeDefaultCooldown;
        }
    }

    /**
    Charge at player every 4 seconds
    */
    void Charge() // TODO: Make red monster walk towards player when not charging (low-priority)
    {
        StopWalkSound();
        PlayChargeSound();
        Vector3 charge = (Path.destination - gameObject.transform.position).normalized * chargeSpeed;
        numOfBounces = 0;
        recoil = charge.normalized;


        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.AddForce(charge, ForceMode2D.Impulse);

        
    }

    // Was thinking of making it so that each monster has a different response to colliding
    // Like Red Monster has recoil momentum for example
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        PlayHitSound(); // plays hit sound no matter what it collides with
        if (currentlyCharging)
        {
            numOfBounces++;
        }
        base.Rb.velocity = (Path.destination - gameObject.transform.position).normalized * chargeSpeed; // Note: whenever red monster bounces, it attempts to charge towards player
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