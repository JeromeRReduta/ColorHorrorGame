using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMonsterSpawner : MonoBehaviour
{

    /** Ticks down in update(). Once this is 0, spawns exactly one white monster that follows the player around. */
    [SerializeField] private int countdown = 300;
    [SerializeField] private Monster monster; // TODO: Can we make this from GameObject -> WhiteMonster?
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Transform followSpot;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdown > 0) {
            Debug.Log("SPAWNING WHITE MONSTER IN: " + countdown);
            countdown--;
        }
        else if (countdown == 0) {
            audioManager.Play("WhiteMonSpawn"); // TODO: HAVE WHITE MONSTER SPAWN SOUND EFFECT
            monster.Audio = audioManager;
            monster.GetComponent<Pathfinding.AIDestinationSetter>().target = followSpot;
            // TODO: line getComponent method here is unbelieviably unclean - find better implementation of this
            Instantiate(monster, this.transform);

            countdown = -1;
        }

    }



}
