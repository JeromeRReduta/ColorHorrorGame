using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;

    public Transform camera1;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    private Vector3 startPos;
    private float initialDuration;


    // Start is called before the first frame update
    void Start()
    {
        camera1 = Camera.main.transform;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = camera1.localPosition;
        if(shouldShake){
            if(duration > 0){
                camera1.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else{
                shouldShake = false;
                duration = initialDuration;
                // camera1.localPosition = startPos;
            }
        }
    }
}
