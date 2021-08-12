using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mob
{
    public delegate void ChangeColorAction(Color color);
    public static event ChangeColorAction OnColorChange;

    int health = 2;
    bool recentlyHit = false;
    public static Player Instance;
    public float CharacterSpeed = 14f;
    public Rigidbody2D Playerbody;
    [HideInInspector] public Vector2 movement;
    private bool wasWalking = false;

    public Color defaultColor = Color.white;

    public int paintFrames = 1800;
    private int paintCountDown = 0;
    public LevelLoader levelLoader;

    public override void Start()
    {
        base.Start();
        base.CurrentColor = defaultColor;
        Instance = this;
    }

    public override void OnEnable()
    {
        Pool.OnEnteringPool += ChangeColorTo;
    }

    public override void OnDisable()
    {
        Pool.OnEnteringPool -= ChangeColorTo;
    }
    
    public override void Update()
    
    {
        if (paintCountDown > 0)
        {
            //Debug.Log("Returning to default color (" + defaultColor.ToString() + ") in " + paintCountDown + " frames");
            //Debug.Log("Current color: " + base.CurrentColor + " default color: " + defaultColor);
            paintCountDown--;
        }
        else if (paintCountDown == 0 && base.CurrentColor != defaultColor)
        {
            //Debug.Log("Returning to default color(" + defaultColor.ToString() + ")");
            ChangeColorTo(defaultColor);
        }

        Camera.main.transform.position = new Vector3 (Playerbody.transform.position.x, Playerbody.transform.position.y, Camera.main.transform.position.z);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            base.Anim.SetBool("Running", true);

            
            if (!wasWalking) { // if player starts walking, play walking sound
                PlayWalkSound();
            }

            wasWalking = true;

        }
        else
        {
            base.Anim.SetBool("Running", false);

            if (wasWalking) { // if player stops walking, stop walking sound
                StopWalkSound();
            }

            wasWalking = false;
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

    public override void FixedUpdate()
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

    public override void PlayWalkSound()
    {
        base.PlaySound("PlayerWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("PlayerWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("PlayerHit");
    }


    IEnumerator TakeDamage()
    {
        PlayHitSound();
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

        levelLoader.LoadDeathScene();
        Debug.Log("Player theoretically died.");
        health = 2;
    }

    public void ChangeColorTo(Color color) // Note: Kind of hard to see color change in harsh red light - maybe change material into default when changing back, and change material into lit-default when changing into another color?
    {
        Debug.Log("CHANGING COLOR FROM: " + base.CurrentColor + " TO: " + color);
        base.CurrentColor = color;
        Debug.Log("Renderer color before: " + GetComponent<Renderer>().material.color);
        GetComponent<Renderer>().material.color = color;
        Debug.Log("Renderer color after: " + GetComponent<Renderer>().material.color);
        paintCountDown = paintFrames;

        if (OnColorChange != null)
        {
            OnColorChange(CurrentColor);
        }
        
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }


}