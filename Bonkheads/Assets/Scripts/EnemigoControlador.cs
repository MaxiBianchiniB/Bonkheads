using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControlador : MonoBehaviour
{
    public float MaxSpeed = 1f;
    public float speed = 1f;
    public float NumeroEnemigo;

    private Rigidbody2D Enemigo;

    private GameObject player;

    private GameObject Balas;

    public Transform puntoinstancia;
    public GameObject Bala;

    private float tiempodisparo;

    private float h;
    public float Posicion;

    // Start is called before the first frame update
    void Start()
    {
        Enemigo = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");


        Posicion = Enemigo.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        tiempodisparo += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (NumeroEnemigo == 1)///////////////////////////
        {
            Enemigo.AddForce(Vector2.right * speed);

            float LimitSpeed = Mathf.Clamp(Enemigo.velocity.x, -MaxSpeed, MaxSpeed);
            Enemigo.velocity = new Vector2(LimitSpeed, Enemigo.velocity.y);

            if (Enemigo.velocity.x > -0.01f && Enemigo.velocity.x < 0.01f)
            {
                speed = -speed;
                Enemigo.velocity = new Vector2(speed, Enemigo.velocity.y);
            }

             if (speed > 0f)
             {
                 transform.localScale = new Vector3(1f, 1f, 1f);
             }

             if (speed < 0f)
             {
                 transform.localScale = new Vector3(-1f, 1f, 1f);
             }

        }
        else if (NumeroEnemigo == 2)//////////////////////////
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                h = 1;
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);

                h = -1;
            }


            if (Mathf.Abs(player.transform.position.x - transform.position.x)  < 5f && tiempodisparo >= 0.5f)
            {
                Balas = Instantiate(Bala, puntoinstancia.position,Quaternion.identity);
                Balas.GetComponent<Rigidbody2D>().velocity = new Vector2(h * 3 , Balas.GetComponent<Rigidbody2D>().position.y);
                tiempodisparo = 0f;
            }
        }
        else if(NumeroEnemigo == 3) ////////////////////
        {
            Enemigo.AddForce(Vector2.right * speed);

            float LimitSpeed = Mathf.Clamp(Enemigo.velocity.x, -MaxSpeed, MaxSpeed);
            Enemigo.velocity = new Vector2(LimitSpeed, Enemigo.velocity.y);
            Enemigo.velocity = new Vector2(speed, Enemigo.velocity.y);

            if (Enemigo.position.x > Posicion + 5f || Enemigo.position.x < Posicion - 5f)
            {
                speed = -speed;
                Enemigo.velocity = new Vector2(speed, Enemigo.velocity.y);
            }

            if (speed > 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if (speed < 0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }


           // Vector2 direccion = player.transform.position - transform.position;

            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 5f && tiempodisparo >= 0.5f)
            {
                Balas = Instantiate(Bala, puntoinstancia.position, Quaternion.identity);
               Balas.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 3, Balas.GetComponent<Rigidbody2D>().position.y);/// pasarlo a la bala
               // Balas.GetComponent<Rigidbody2D>().d


                tiempodisparo = 0f;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    { 
        

        if (collision.gameObject.tag == "BalaPlayer")
        {
            collision.SendMessage("EliminarBala");
            Destroy(gameObject);
        }
    }

}
