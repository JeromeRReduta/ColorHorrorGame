using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 2;
    bool recentlyHit = false;
    public static Player Instance;
    public float CharacterSpeed = 14f;
    [HideInInspector] public Vector2 InputDir;
    public Rigidbody2D Playerbody;
    [HideInInspector] public Vector2 movement;
    Animator animator;

    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        
    }
    
    void Update()
    {
        Camera.main.transform.position = new Vector3 (Playerbody.transform.position.x, Playerbody.transform.position.y, Camera.main.transform.position.z);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        CollideWithMonster();
    }

    void FixedUpdate()
    {
        Playerbody.MovePosition(Playerbody.position + movement * CharacterSpeed * Time.fixedDeltaTime);
    }

    void CollideWithMonster()
    {
        if (Playerbody.IsTouchingLayers(LayerMask.GetMask("Monster")) && recentlyHit == false)
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        recentlyHit = true;
        health--;
        if (health > 0)
        {
            Debug.Log("Took damage.");
        }
        else
        {
            PlayerDeath();
        }
        yield return new WaitForSeconds(2);
        recentlyHit = false;
    }

    void PlayerDeath()
    {
        Debug.Log("Player theoretically died.");
        health = 2;
    }
}
