using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speak : MonoBehaviour
{
    public Renderer balao;
    // Start is called before the first frame update
    void Start()
    {
        balao.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           balao.GetComponent<Renderer>().enabled = true;
            Destroy(balao.gameObject, 2);
            Destroy(this.gameObject,2);
        }
        
        
    }
}
