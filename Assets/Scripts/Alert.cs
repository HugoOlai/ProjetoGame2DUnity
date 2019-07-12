using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public float Tempo;
    public bool PlacaAtiva = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(PlacaAtiva){
            Tempo += 1 * Time.deltaTime;            
        }

        if(Tempo > 1){
                gameObject.GetComponent<Renderer>().enabled = false;
                PlacaAtiva = false;
                Tempo  = 0f;
            }
        
    }
    
    public void OnTriggerEnter2D (Collider2D other ){
        if(other.gameObject.CompareTag("Player")){
          gameObject.GetComponent<Renderer>().enabled = true;
           PlacaAtiva = true;
        }
    }
}
