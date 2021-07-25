using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public GameObject m_GotHitScreen;
    public CameraShake cameraShake;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            playerHurt();
            StartCoroutine(cameraShake.Shake(.2f, .4f));
          
        }
    }

    void playerHurt()
    {
       var color =  m_GotHitScreen.GetComponent<Image>().color;
       color.a = 0.8f;

       m_GotHitScreen.GetComponent<Image>().color = color;

    }


    void Update()
    {
        if(m_GotHitScreen != null){
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0){
                var color = m_GotHitScreen.GetComponent<Image>().color;

                color.a -= 0.005f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }
    }
}
