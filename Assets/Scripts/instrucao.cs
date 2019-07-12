using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrucao : MonoBehaviour
{
    public GameObject seta;
    public GameObject seta1;
    public GameObject seta2;
    public GameObject seta3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            Destroy(this.gameObject,2);
        }
    }
}
