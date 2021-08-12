using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    /** Delegate for PlaySoundAction
    @param name name of sound
    */
    public delegate void PlaySoundAction(string name);
    /** OnPlay event */
    public static event PlaySoundAction OnPlay;

    /** Delegate for StopSoundAction
    @param name name of sound
    */
    public delegate void StopSoundAction(string name);
    /** OnStop event */
    public static event StopSoundAction OnStop;

    public void Play(string soundName)
    {
        if (OnPlay != null)
        {
            OnPlay(soundName);
        }
    }

    public void Stop(string soundName)
    {
        if (OnStop != null)
        {
            OnStop(soundName);
        }

    }
}

