using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    /** Ticks down in update(). Once this is 0, spawns exactly one white monster that follows the player around. */
    [SerializeField] private int countdown = 300;
    [SerializeField] private NewMonster monster;
    

    [SerializeField] private Transform followSpot;
    private AudioPlayer soundSys;

    void Start()
    {
        soundSys = this.gameObject.AddComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdown > 0) {
            Debug.Log("SPAWNING MONSTER IN: " + countdown);
            countdown--;
        }
        else if (countdown == 0) {
            soundSys.Play("WhiteMonSpawn"); // Note: WhiteMonSpawn plays regardless of actual monster spawn type
            monster.GetComponent<Pathfinding.AIDestinationSetter>().target = followSpot;
            Instantiate(monster, this.transform);

            countdown = -1;
        }

    }



}
