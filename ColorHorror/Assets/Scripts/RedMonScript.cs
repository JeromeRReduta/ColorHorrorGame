using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RedMonScript : Monster
{
    public AIPath Path;
    public int chargeSpeed = 200;
    bool completed = true;

    public override void Update()
    {
        Vector3 dest = Path.destination;
        RaycastHit2D hit = Physics2D.Linecast(base.Rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") && completed)
            {
                completed = false;
                StartCoroutine(Wait());
            }
        }
        Debug.DrawLine(gameObject.transform.position, dest, Color.blue);
    }

    IEnumerator Wait()
    {
        Vector3 charge = (Path.destination - gameObject.transform.position).normalized * chargeSpeed;
        Path.enabled = false;

        base.Rb.velocity = new Vector2 (0f, 0f);
        base.Rb.AddForce(charge, ForceMode2D.Impulse);
        Debug.Log("coordinate of player: " + Path.destination);
        Debug.Log("force (charge): " + charge);
        Debug.Log("---------");
        yield return new WaitForSeconds(2);
        completed = true;
        Path.enabled = true;
    }

    void OnCollisionEnter()
    {
        base.Rb.velocity = new Vector2(0f, 0f);
    }
    
}
