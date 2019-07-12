using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    public Animator anim;
    public float vel = 3f;   
    public Transform viraH;
    public bool face = true;
    private bool vivo;
    public Image img;
    public GameObject entrada;
    public bool SuperVel;
    public int p;
    public AudioSource SomAndar;
    public AudioSource SomCorrer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        viraH = GetComponent<Transform>();
        vivo = true;
        SuperVel = false;
        SomAndar.Stop();
        SomCorrer.Stop();


    }
	
	// Update is called once per frame
	void Update () {

        if (vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && face)
            {
                flip();
            }

            if (Input.GetKey(KeyCode.LeftArrow) && !face)
            {
                flip();
            }
        }

            if(SuperVel){
                if(Input.GetKey(KeyCode.Q)){
                    vel = 6;
                SomCorrer.Play();
            }
            else{
                    vel = 3;
                SomCorrer.Stop();
            }
            }
            
            

        if (vivo == true)
        {
            if (p == 1)
            {
                anim.SetBool("paradoCima", true);
                anim.SetBool("HParado", false);
                anim.SetBool("MoveEsquerda", false);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", false);
            }
            else if (p == 2)
            {
                anim.SetBool("HParado", true);
                anim.SetBool("paradoCima", false);
                anim.SetBool("MoveEsquerda", false);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", false);
            }
            else if (p == 3 || p == 4)
            {
                anim.SetBool("HParado", false);
                anim.SetBool("paradoCima", false);
                anim.SetBool("MoveEsquerda", false);
                anim.SetBool("ladoParado", true);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", false);
            }

            if (Input.GetKey(KeyCode.LeftArrow) )
            {
                anim.SetBool("paradoCima", false);
                anim.SetBool("HParado", false);
                anim.SetBool("MoveEsquerda", true);
                anim.SetBool("ladoParado", false);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", false);                
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                p = 4;
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("paradoCima", false);
                anim.SetBool("HParado", false);
                anim.SetBool("MoveEsquerda", true);
                anim.SetBool("ladoParado", false);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", false);
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                p = 3;
                
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("paradoCima", false);
                anim.SetBool("HParado", false);
                anim.SetBool("MoveEsquerda", false);
                anim.SetBool("ladoParado", false);
                anim.SetBool("MoveCima", false);
                anim.SetBool("MoveBaixo", true);
                p = 2;                
                transform.Translate(new Vector2(0, -vel * Time.deltaTime));
                
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("paradoCima", false);
                anim.SetBool("HParado", false);
                anim.SetBool("MoveEsquerda", false);
                anim.SetBool("ladoParado", false);
                anim.SetBool("MoveCima", true);
                anim.SetBool("MoveBaixo", false);
                p = 1;
                transform.Translate(new Vector2(0, vel * Time.deltaTime));
                
            }
            
            if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SomAndar.Play();
            }else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                SomAndar.Stop();
            }
            
           
        }

        if(img.fillAmount == 0){
            vivo = false;
        }
	}

    void flip()
    {
        face = !face;
        Vector3 scala = viraH.localScale;
        scala.x *= -1;
        viraH.localScale = scala;
    }

    public void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.CompareTag("OBJ")){
            vel = 0.06f;
        }     

        
       
    }

    public void OnCollisionExit2D (Collision2D other){
        if(other.gameObject.CompareTag("OBJ")){
            vel = 3f;
        }

                    
    }

     public void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("ativaSuperVEl")){
            SuperVel = true;
        }  
        
        
    }
    
}
