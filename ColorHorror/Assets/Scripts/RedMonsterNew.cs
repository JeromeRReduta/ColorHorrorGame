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
public class RedMonsterNew : Monster
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
    [HideInInspector] public bool recoiling;

    /**
    Attempts to charge at player every 2 seconds
    */
    public override void Update()
    {
        Vector3 dest = Path.destination;
        RaycastHit2D hit = Physics2D.Linecast(base.Rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitUp = Physics2D.Linecast(chargeUp.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitDown = Physics2D.Linecast(chargeDown.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitRight = Physics2D.Linecast(chargeRight.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitLeft = Physics2D.Linecast(chargeLeft.transform.position, dest, LayerMask.GetMask("Walls", "Player"));

        if (hit.collider != null && hitUp.collider.gameObject.CompareTag("Player") && hitDown.collider.gameObject.CompareTag("Player") &&
            hitRight.collider.gameObject.CompareTag("Player") && hitLeft.collider.gameObject.CompareTag("Player") && completed)
        {
            completed = false;
            StartCoroutine(Charge());
        }
        
        Debug.DrawLine(chargeUp.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeDown.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeLeft.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeRight.transform.position, dest, Color.blue);
    }

    /**
    Charge at player every 2 seconds
    */
    IEnumerator Charge() // TODO: Make red monster walk towards player when not charging (low-priority)
    {
        Vector3 charge = (Path.destination - gameObject.transform.position).normalized * chargeSpeed;
        recoil = new Vector3 (charge.x * -1, charge.y * -1, charge.z).normalized;

        Path.enabled = false;

        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.AddForce(charge, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(2);

        StartCoroutine(FollowPlayerInBetweenCharges());
        
    }

    IEnumerator FollowPlayerInBetweenCharges()
    {
        Path.enabled = true;
        recoiling = false;
        yield return new WaitForSeconds(2);
        completed = true;
    }

    // Was thinking of making it so that each monster has a different response to colliding
    // Like Red Monster has recoil momentum for example
    void OnCollisionEnter2D()
    {
        base.Rb.velocity = new Vector2 (0f, 0f);
        recoiling = true;
        base.Rb.AddForce(recoil * 100f);
        StartCoroutine(Recoil());

    }
    IEnumerator Recoil()
    {
        yield return new WaitForSeconds(1);
        base.Rb.velocity = new Vector2(0f, 0f);
    }
}