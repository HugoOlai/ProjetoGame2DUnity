using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introducao : MonoBehaviour
{
    public float tempo;
    public float trans = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        tempo  +=  Time.deltaTime;
        if(tempo > 10f){            
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, trans -= Time.deltaTime);
            Destroy(this.gameObject, 1);
        }
    }
}
