using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{

    public static TempPlayer Instance;
    [SerializeField] private float CharacterSpeed = 1.0f;
    public AudioManager audioManager;
    public string Color {get; private set;}

    [HideInInspector] public Vector2 InputDir;


    
    Vector2 movement;
    Animator animator;
    public Rigidbody2D Playerbody;
    public Vector3 FuturePoint {get; private set;}

    private int debugCount = 200; // TODO: Delete after testing

    /** Tracks if the player was walking one frame before now */
    private bool wasWalking = false;

    
    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        Color = "Rainbow";

    }
    
    void Update()
    {

        debugCount--;
        if (debugCount == 0 && Color == "White") {
            debugCount = 200;
            Color = "Rainbow";
            Debug.Log("Changing color to: " + Color);
        }
        else if (debugCount == 0) {
            debugCount = 200;
            Color = "White";
            Debug.Log("Changing color to: " + Color);
        }

        Vector3 lineDir = Vector3.zero;

        Camera.main.transform.position = new Vector3 (Playerbody.transform.position.x, Playerbody.transform.position.y, Camera.main.transform.position.z);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("Running", true);
            

            if (!wasWalking) { // if player starts walking, play walking sound
                audioManager.Play("PlayerWalk");
            }

            wasWalking = true;
        }
        else
        {
            animator.SetBool("Running", false);
            if (wasWalking) { // if player stops walking, stop walking sound
                audioManager.Stop("PlayerWalk");
            }

            wasWalking = false;
        }

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            lineDir += Vector3.right;
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            lineDir += Vector3.left;
        }

        if (movement.y > 0) {
            lineDir += Vector3.up;
        }
        else if (movement.y < 0) {
            lineDir += Vector3.down;
        }


        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, lineDir, CharacterSpeed, 
            LayerMask.GetMask("Walls", "Room") );

        if (hit != null) {
            float distance = hit.distance > 0 ? hit.distance : CharacterSpeed;
            FuturePoint = hit.distance > 0 ? (Vector3) hit.point : this.transform.position + CharacterSpeed * lineDir;
        }
    }

    void FixedUpdate()
    {
        Playerbody.MovePosition(Playerbody.position + movement * CharacterSpeed * Time.fixedDeltaTime);
    }

}
