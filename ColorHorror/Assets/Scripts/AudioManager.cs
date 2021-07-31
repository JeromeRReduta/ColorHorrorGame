using UnityEngine.Audio;
using UnityEngine;
using System;

/**
AudioManager class, taken from https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys
*/
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance; // using Singleton pattern here to have the same AudioManager throughout every scene
    // Note: This is to deal with a problem we don't have yet. Therefore, this is untested. If there are still multiple copies of AudioManagers
    // when we switch to new scenes, it's probably a result of this code
    void Awake ()
    {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject); // destroy this game object to avoid duplicate instances
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            AudioSource source = sound.source;
            Debug.Log("SOUND: " + sound + " SOURCE: " + sound.source);
           
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
        }
    }

    void Start()
    {
        Play("Music");
    }

    public void Play (string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        // Could use null-coalescing (??) operator but I want a log message, as sound should not be null
        if (sound == null) {
            Debug.LogWarning("Warning: sound " + name + " not found - returning");
            return;
        }

        sound.source.Play();
    }

    public void Stop (string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        // Could use null-coalescing (??) operator but I want a log message, as sound should not be null
        if (sound == null) {
            Debug.LogWarning("Warning: sound " + name + " not found - returning");
            return;
        }

        sound.source.Stop();
    }
}
