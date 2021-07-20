using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TempEnemyScript : MonoBehaviour
{
    public AIPath aiPath;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (this.gameObject.GetComponentInParent<RedMonsterNew>().recoil.x >= 0.01f && this.gameObject.GetComponentInParent<RedMonsterNew>().recoiling == true)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (this.gameObject.GetComponentInParent<RedMonsterNew>().recoil.x <= 0.01f && this.gameObject.GetComponentInParent<RedMonsterNew>().recoiling == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x >= 0.01f || rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f || rb.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else 
        {
            return;
        }

        float distX = Mathf.Abs(gameObject.transform.position.x - aiPath.destination.x);
        float distY = Mathf.Abs(gameObject.transform.position.y - aiPath.destination.y);
        if (distX <= 1.2f || distY <= 1.2f)
        {
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }
    }
}
