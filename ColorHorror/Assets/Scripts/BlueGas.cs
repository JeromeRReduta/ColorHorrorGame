using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGas : MonoBehaviour
{
    [SerializeField] GameObject mainLights;
    private AudioPlayer soundSys;
    Camera cam;

    GameObject[] blueGassesLight;
    BlueMonster monster;

    void Start()
    {
        soundSys = this.gameObject.AddComponent<AudioPlayer>();
        blueGassesLight = GameObject.FindGameObjectsWithTag("BlueGasLight");
        monster = GameObject.FindObjectOfType<BlueMonster>();

        if (monster == null) // Case: monster does not have blue monster script attached (note: check blue monster if this runs)
        {
            Debug.LogWarning("Warning - could not find blue monster!");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            soundSys.Play("BreatheGas");
            SetVisibilityTo(false);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            soundSys.Stop("BreatheGas");
            SetVisibilityTo(true);
        }
    }

    private void SetVisibilityTo(bool canSeeBlue)
    {
            mainLights.SetActive(!canSeeBlue);
            this.gameObject.GetComponentInChildren<Camera>().enabled = !canSeeBlue;

            for (int i = 0; i < blueGassesLight.Length; i++)
            {
                blueGassesLight[i].SetActive(canSeeBlue);
                blueGassesLight[i].GetComponentInParent<Animator>().enabled = canSeeBlue;
                blueGassesLight[i].GetComponentInParent<SpriteRenderer>().enabled = canSeeBlue;
            }

            monster.gameObject.SetActive(canSeeBlue);
    }
}
