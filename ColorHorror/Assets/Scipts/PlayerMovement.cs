using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Four Directions Using Unity Animator 
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    //public Animator animator;
    Vector2 movement;
    void Update()
    {
        Camera.main.transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y, Camera.main.transform.position.z);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.x);

        */
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
