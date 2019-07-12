using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public bool face = true;
    public Transform viraH;
    public Animator anim;
    public GameObject heroi;
    public float distancia;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        viraH = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.transform.position, heroi.transform.position);

        if (distancia < 3.0f)
        {
            if (transform.position.x > heroi.transform.position.x || transform.position.x < heroi.transform.position.x)
            {
                if (transform.position.x < heroi.transform.position.x && face)
                {
                    flip();
                }
                else if (transform.position.x > heroi.transform.position.x && !face)
                {
                    flip();
                }
                anim.SetBool("VilaoParado", false);
                anim.SetBool("MoveEsquerdaVilao", true);
            }
        }else
            {
                anim.SetBool("VilaoParado", true);
                anim.SetBool("MoveEsquerdaVilao", false);
            }



    }

    void flip()
    {
        face = !face;
        Vector3 scala = viraH.localScale;
        scala.x *= -1;
        viraH.localScale = scala;
    }


}
