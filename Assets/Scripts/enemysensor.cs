using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysensor : MonoBehaviour
{
    public Light myLight;  
    public bool reP = true;
    public AudioSource musica;
   
    private Transform playerPos;  
    public float vel;
    private float morte = 10;
    public bool playerNaArea = false;
    public bool apertandoQ = false;
    public float distancia;
    public GameObject heroi;
    public GameObject vilao;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        musica.volume = 0f;
        musica.Stop(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(vilao.transform.position, heroi.transform.position);

        if (myLight.GetComponent<Light>().enabled)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            transform.position = new Vector2(3.2f, -6.47f);
        }
        else if (!myLight.GetComponent<Light>().enabled && reP)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            transform.position = new Vector2(3.2f, -1.17f);
            musica.Play();
            reP = false;
        }

        if (musica.volume < 5f && !reP)
        {            
          musica.volume = musica.volume + 0.2f * Time.deltaTime;
        }

        if (musica.volume > 5f && !reP)
        {
            musica.volume = 5f;
        }

        if (distancia < 3.0f)
        {

            if (playerNaArea && !apertandoQ)
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, vel * Time.deltaTime);
            
        }
           
    }

     public void OnTriggerEnter2D (Collider2D other )
    {
        if(other.gameObject.CompareTag("Player"))
        {            
            playerNaArea = true;            
        }
        
    }
}
