using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour // TODO: Make abstract class that all mobs inherit from?
{
    /** RigidBody2D */
    public Rigidbody2D Rb {get; private set;}

    /** Collider2D */
    public Collider2D Col {get; private set;}

    /** Animator */
    public Animator Anim {get; private set;}

    /** This mob's current color */
    public Color CurrentColor {get; set;}

    private AudioPlayer soundSys;

    /** Start function. Sets the rigidbody, collider, and animator.
    Note that when overriding this Start() method, you'll also need to
    set the color */
    public virtual void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Col = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        soundSys = this.gameObject.AddComponent<AudioPlayer>();
        Debug.Log("soundsys null IN START?" + (soundSys == null));
    }

    /** Plays this mob's walk sound */
    public abstract void PlayWalkSound();

    /** Stops this mob's walk sound */
    public abstract void StopWalkSound();

    /** Play's this mob's hit sound */
    public abstract void PlayHitSound();

    /** Subscribes this mob to whatever events you want */
    public abstract void OnEnable();

    /** Unsubscribes this mob to whatever events you want. According to https://www.youtube.com/watch?v=k4JlFxPcqlg&ab_channel=Unity,
        if you don't unsubscribe from the events you subscribe to, this will cause memory leaks and faulty functionality */
    public abstract void OnDisable();

    /** Collision logic
    @param collision collision data
    */
    public abstract void OnCollisionEnter2D(Collision2D collision);

    /** Update */
    public virtual void Update()
    {
    }

    /** FixedUpdate */
    public virtual void FixedUpdate()
    {
    }

    // TODO: For each mob, just make PlayWalkSound, PlayHitSound, etc. just call the proper PlaySound(name) name
    public void PlaySound(string name)
    {
        Debug.Log("sound sys null?: " + (soundSys == null));
        Debug.Log("string is: " + name);
        soundSys.Play(name);
    }

    public void StopSound(string name)
    {
        soundSys.Stop(name);
    }
}
