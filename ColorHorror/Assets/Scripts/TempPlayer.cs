using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayer : MonoBehaviour
{

    public static TempPlayer Instance;
    [SerializeField] private float CharacterSpeed = 1.0f;
    [HideInInspector] public Vector2 InputDir;
    
    public Rigidbody2D Playerbody;
    Vector2 movement;
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
    }

    void FixedUpdate()
    {
        Playerbody.MovePosition(Playerbody.position + movement * CharacterSpeed * Time.fixedDeltaTime);
    }
}
