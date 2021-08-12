using UnityEngine.Audio;
using UnityEngine;
using System;

/**
AudioManager class, taken from https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys
*/
public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    [SerializeField] [Range(0f, 1f)] private float masterVolume;


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
            source.volume = sound.volume * masterVolume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
        }
    }

    void OnEnable()
    {
        AudioPlayer.OnPlay += Play;
        AudioPlayer.OnStop += Stop;
    }

    void onDisable()
    {
        AudioPlayer.OnPlay -= Play;
        AudioPlayer.OnStop -= Stop;
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
    
    [System.Serializable]
    private class Sound
    // i.e. AudioManager.Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}
