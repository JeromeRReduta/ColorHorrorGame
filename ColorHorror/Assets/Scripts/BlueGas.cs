using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGas : MonoBehaviour
{
    [SerializeField] GameObject mainLights;
    [SerializeField] private AudioManager audioManager;
    Camera cam;

    GameObject[] blueGassesLight;
    GameObject monster;

    void Start()
    {
        blueGassesLight = GameObject.FindGameObjectsWithTag("BlueGasLight");
        monster = GameObject.FindGameObjectWithTag("Monster");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            mainLights.SetActive(true);
            cam = this.gameObject.GetComponentInChildren<Camera>();

            audioManager.Play("BreatheGas");

            for (int i = 0; i < blueGassesLight.Length; i++)
            {
                blueGassesLight[i].SetActive(false);
                blueGassesLight[i].GetComponentInParent<Animator>().enabled = false;
                blueGassesLight[i].GetComponentInParent<SpriteRenderer>().enabled = false;
            }
        
            monster.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
            cam.enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            mainLights.SetActive(false);
            cam = this.gameObject.GetComponentInChildren<Camera>();

            audioManager.Stop("BreatheGas");

            for (int i = 0; i < blueGassesLight.Length; i++)
            {
                blueGassesLight[i].SetActive(true);
                blueGassesLight[i].GetComponentInParent<Animator>().enabled = true;
                blueGassesLight[i].GetComponentInParent<SpriteRenderer>().enabled = true;
            }

            monster.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            cam.enabled = false;
        }
    }
}
