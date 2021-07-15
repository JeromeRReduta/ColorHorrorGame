using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RedMonScript : MonoBehaviour
{
    public AIPath aiPath;
    Collider2D col;
    Rigidbody2D rb;
    public int chargeSpeed = 200;
    bool completed = true;

    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 dest = aiPath.destination;
        RaycastHit2D hit = Physics2D.Linecast(rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") && completed == true)
            {
                // Debug.Log("dest: " + dest);
                // rb.AddForce(player.position, ForceMode2D.Impulse);
                completed = false;
                StartCoroutine(Wait());
            }
        }
        Debug.DrawLine(gameObject.transform.position, dest, Color.blue);
    }

    IEnumerator Wait()
    {
        Vector3 playerLocation = aiPath.destination;
        Vector3 AILocation = gameObject.transform.position;
        aiPath.enabled = false;

        Vector3 newForce2 = playerLocation - AILocation;
        Vector3 temp = newForce2.normalized;

        rb.velocity = new Vector2 (0f, 0f);
        rb.AddForce(temp * 10, ForceMode2D.Impulse);


        Debug.Log("coordinate of player: " + playerLocation);
        Debug.Log("force: " + newForce2);
        Debug.Log("---------");
        yield return new WaitForSeconds(2);
        completed = true;
        aiPath.enabled = true;
    }

    void OnCollisionEnter()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
}
