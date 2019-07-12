using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public bool marteloPego = false;
    public Renderer E;
    public Renderer balao;
    public Light myLight; 
    public AudioSource musica;

    // Start is called before the first frame update
    void Start()
    {
        E.GetComponent<Renderer>().enabled = false;
        balao.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false; 
        musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(marteloPego){
            if(Input.GetKey(KeyCode.E)){
              gameObject.GetComponent<Renderer>().enabled = true;
              myLight.GetComponent<Light>().enabled = false;
              balao.GetComponent<Renderer>().enabled = true; 
                             
            }

            if(gameObject.GetComponent<Renderer>().enabled == true)
                musica.volume = musica.volume - 0.2f * Time.deltaTime;

              if(musica.volume < 0.2 && gameObject.GetComponent<Renderer>().enabled == true){
                musica.Stop();
                Destroy(balao.gameObject, 3f);
                Destroy(E.gameObject, 3f);
                Destroy(this.gameObject,3f); 
              }
        }
        
    }

    public void OnTriggerEnter2D (Collider2D other )
    {
        if(other.gameObject.CompareTag("Player"))
        {
            E.GetComponent<Renderer>().enabled = true;
            marteloPego = true;
        }
    }
}
