using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDoor : MonoBehaviour
{
    public Renderer parede;
    public bool paredeVisivel = true;
    public int  volta = 0;
    // Start is called before the first frame update
    void Start()
    {
        volta = 0;
           //parede =  GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(!paredeVisivel && volta ==1){
            gameObject.GetComponent<Renderer>().enabled = false;  
            parede.GetComponent<Renderer>().enabled = false;                   
        }

         if(paredeVisivel && volta == 0){
            gameObject.GetComponent<Renderer>().enabled = true;  
            parede.GetComponent<Renderer>().enabled = true;                   
        }
         
    }

    public void OnTriggerEnter2D (Collider2D other ){
        if(other.gameObject.CompareTag("Player") && volta == 0){ 
            paredeVisivel = false;   
            volta += 1;                       
        }else if(other.gameObject.CompareTag("Player") && volta == 1){ 
            paredeVisivel = true;   
            volta -= 1;             
        }
    }
    public void OnTriggerExit2D (Collider2D other ){
        
    }
}
