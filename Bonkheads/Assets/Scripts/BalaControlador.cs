using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControlador : MonoBehaviour
{
    public float MaxSpeed;
    public float speed;

    //private Rigidbody2D Bala;

    //public GameObject Player;
    //private GameObject Enemigo;
   // private Transform playertransform;

    private float TiempoMuerte = 3f;

    private void Awake()
    {
        //Bala = GetComponent<Rigidbody2D>();
        //Enemigo = GameObject.FindGameObjectWithLayer("Enemigos");
     //   playertransform = player.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
       /* if (Enemigo.transform.localScale.x > 0)
        {
            Bala.velocity = new Vector2(speed, Bala.position.y);
           // transform.localScale = new Vector3(1f, 1f, 1f);   //para flipear la bala
        }
        else
        {
            Bala.velocity = new Vector2(-speed, Bala.position.y);
           // transform.localScale = new Vector3(-1f, 1f, 1f); // para flipear la bala
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, TiempoMuerte);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Plataforma Movil")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pared")
        {
            Destroy(gameObject);
        }
    }


    public void EliminarBala()
    {
        Destroy(gameObject);
    }
}
