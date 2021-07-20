using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RedMonScript : MonoBehaviour
{
    public AIPath aiPath;
    Collider2D col;
    Rigidbody2D rb;
    public int chargeSpeed = 20;
    bool completed = true;
    Vector3 recoil;
    [SerializeField] GameObject chargeUp, chargeDown, chargeRight, chargeLeft;

    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 dest = aiPath.destination;
        //RaycastHit2D hit = Physics2D.Linecast(rb.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitUp = Physics2D.Linecast(chargeUp.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitDown = Physics2D.Linecast(chargeDown.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitRight = Physics2D.Linecast(chargeRight.transform.position, dest, LayerMask.GetMask("Walls", "Player"));
        RaycastHit2D hitLeft = Physics2D.Linecast(chargeLeft.transform.position, dest, LayerMask.GetMask("Walls", "Player"));

        if (hitUp.collider != null)
        {
            if (hitUp.collider.gameObject.CompareTag("Player") && hitDown.collider.gameObject.CompareTag("Player") &&
            hitRight.collider.gameObject.CompareTag("Player") && hitLeft.collider.gameObject.CompareTag("Player") && completed == true)
            {
                completed = false;
                StartCoroutine(Wait());
            }
        }
        Debug.DrawLine(chargeUp.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeDown.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeLeft.transform.position, dest, Color.blue);
        Debug.DrawLine(chargeRight.transform.position, dest, Color.blue);
    }

    IEnumerator Wait()
    {
        Vector3 playerLocation = aiPath.destination;
        Vector3 AILocation = gameObject.transform.position;
        aiPath.enabled = false;

        Vector3 newForce2 = playerLocation - AILocation;
        Vector3 temp = newForce2.normalized;
        recoil = new Vector3(temp.x * -1, temp.y * -1, temp.z);

        rb.velocity = new Vector2 (0f, 0f);
        rb.AddForce(temp * 20, ForceMode2D.Impulse);


        yield return new WaitForSeconds(3);
        completed = true;
        aiPath.enabled = true;
    }

    void OnCollisionEnter2D()
    {
        rb.velocity = new Vector2(0f, 0f);
        rb.AddForce(recoil * 100);
        StartCoroutine(Recoil());
    }

    IEnumerator Recoil()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(0f, 0f);
    }
}
