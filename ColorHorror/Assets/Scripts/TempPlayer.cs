using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayer : MonoBehaviour
{

    public static TempPlayer Instance;
    [SerializeField] private float CharacterSpeed = 1.0f;
    [HideInInspector] public Vector2 InputDir;
    
    public Rigidbody2D Playerbody;
    [HideInInspector] public float VertInput;
    [HideInInspector] public float HorInput;

    public GameObject m_GotHitScreen;

    void Start()
    {
        Instance = this;
    }
    
    void Update()
    {
        VertInput = Input.GetAxis("Vertical");
        HorInput = Input.GetAxis("Horizontal");
        InputDir = new Vector2(HorInput, VertInput).normalized;
        Camera.main.transform.position = new Vector3 (Playerbody.transform.position.x, Playerbody.transform.position.y, Camera.main.transform.position.z);
    }

    void FixedUpdate()
    {
        Vector2 WhereAmI = Playerbody.position;
        Vector2 WhereTo = WhereAmI + (InputDir * CharacterSpeed) * Time.fixedDeltaTime;
        Playerbody.MovePosition(WhereTo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHurt();
        }
    }

    void playerHurt()
    {
       var color =  m_GotHitScreen.GetComponent<Image>().color;
       color.a = 0.8f;

       m_GotHitScreen.GetComponent<Image>().color = color;

    }
}
