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
public class Charge : IMonsterSpecial // TODO: 1) Make changing levels disable the old monsters' aggro, complete w/ stopping sounds
    // 2) Make red monster charge not track the player (or at least, so closely)
{

    private Monster monster;
    
    /** AIPath this monster uses */
    public AIPath Path;

    /** Charge speed */
    public int chargeSpeed = 20;

    public static int chargeDefaultCooldown = 325;
    [SerializeField] private int chargeCurrentCooldown;

    /** Whether the monster is NOT charging */
    private bool currentlyCharging;

    /** Adds backwards momentum after hitting a collider */
    [HideInInspector] public Vector3 recoil;
    private int numOfBounces = 0; // TODO: Better name (e.g. numOfBouncesCounter)


    public Charge(Monster monster)
    {
        this.monster = monster;
        Path = monster.gameObject.GetComponent<AIPath>();
        if (Path == null)
        {
            Debug.LogWarning("AAAH - Charge");
        }
        chargeCurrentCooldown = chargeDefaultCooldown;
        currentlyCharging = false;
        recoil = Vector3.zero;
        

    }

    public void Disable()
    {
        // fill in
    }

    public void Enable()
    {
        // TODO: fill in
    }


    /**
    Attempts to charge at player every 4 seconds
    */
    public void Update()
    {
        Debug.Log("CD: " + chargeCurrentCooldown);
        Debug.Log("Currently charging: " + currentlyCharging);
        if (chargeCurrentCooldown > 0)
        {
            chargeCurrentCooldown--;
        }
        else if (chargeCurrentCooldown == 0 && !currentlyCharging)
        {
            RaycastHit2D ThingInLineOfSight = Physics2D.Linecast(monster.Rb.transform.position, Path.destination, LayerMask.GetMask("Walls", "Player"));

            if (ThingInLineOfSight != null
                && ThingInLineOfSight.collider != null
                && ThingInLineOfSight.collider.gameObject != null
                && ThingInLineOfSight.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("CHAAAAAAAAAAAAAAAAAAAAAAARGE");
                Path.enabled = false;
                currentlyCharging = true;
                TryCharge();
            }

        }
        else if (currentlyCharging && numOfBounces > 3)
        {
            monster.Rb.velocity = Vector2.zero; 
            Path.enabled = true;
            currentlyCharging = false;
            chargeCurrentCooldown = chargeDefaultCooldown;

            monster.StopSound("RedMonCharge");
            monster.PlayWalkSound();
        }
    }

    /**
    Charge at player every 4 seconds
    */
    void TryCharge() // TODO: Make red  walk towards player when not charging (low-priority)
    {
        monster.StopWalkSound();
        monster.PlaySound("RedMonCharge");
        Vector3 charge = (Path.destination - monster.gameObject.transform.position).normalized * chargeSpeed;
        numOfBounces = 0;
        recoil = charge.normalized;


        monster.Rb.velocity = new Vector2 (0f, 0f);
        monster.Rb.AddForce(charge, ForceMode2D.Impulse);
    }

    // Was thinking of making it so that each monster has a different response to colliding
    // Like Red Monster has recoil momentum for example
    public void Collide(Collision2D collision)
    {
        if (!currentlyCharging) { return; }

        Debug.Log("RUNNING COLLIDE");

        numOfBounces++;

        if (collision.gameObject.CompareTag("Player"))
        {
            monster.Rb.velocity  = monster.Rb.velocity * -1;
        }
        else
        {
            monster.Rb.velocity = (Path.destination - monster.gameObject.transform.position).normalized * chargeSpeed; // Note: whenever red monster bounces, it attempts to charge towards player
        }
        recoil = monster.Rb.velocity.normalized;
    }
}
