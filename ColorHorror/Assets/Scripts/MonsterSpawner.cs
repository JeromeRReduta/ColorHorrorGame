using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    /** Ticks down in update(). Once this is 0, spawns exactly one white monster that follows the player around. */
    [SerializeField] private int countdown = 300;
    [SerializeField] private GameObject MonsterPrefab;
    public IMonsterMovement movement;

    public enum TypeOfMovement {BaseMovement};
    public TypeOfMovement movementChoice;

    public enum TypeOfSpecial {NoSpecial, Charge, Teleport};

    public TypeOfSpecial specialChoice;

    public IMonsterSpecial special;
    

    [SerializeField] private Transform followSpot;
    private AudioPlayer soundSys;

    void Start()
    {
        soundSys = this.gameObject.AddComponent<AudioPlayer>();
        MonsterPrefab.GetComponent<Pathfinding.AIDestinationSetter>().target = followSpot;

        // TODO: default w/ null-check: monster or throw error
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
            
            Instantiate(MonsterPrefab, this.transform.position, Quaternion.identity);

            

            countdown = -1;
        }

    }



}
