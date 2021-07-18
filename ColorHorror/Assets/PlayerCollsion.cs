using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollsion : MonoBehaviour
{

    public GameObject m_GotHitScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerHurt();
            Debug.Log("I AM HIT");
        }
    }

    void playerHurt()
    {
       var color =  m_GotHitScreen.GetComponent<Image>().color;
       color.a = 0.8f;

       m_GotHitScreen.GetComponent<Image>().color = color;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
