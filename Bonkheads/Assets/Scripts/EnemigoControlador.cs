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



    public Transform puntoinstancia;
    public GameObject Bala;

    private float tiempodisparo;








    // Start is called before the first frame update
    void Start()
    {
        Enemigo = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        tiempodisparo += Time.deltaTime;
    }






    void FixedUpdate()
    {
        if (NumeroEnemigo == 1)
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
        else if (NumeroEnemigo == 2)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }









            

            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 5 && tiempodisparo >= 0.5f)
            {
                Instantiate(Bala, puntoinstancia.position, Quaternion.identity);
                tiempodisparo = 0f;
            }



            // if(player.)
            /* {
                 transform.localScale = new Vector3(1f, 1f, 1f);  // para flipear la bala
             }*/
            /* else
             {
                 transform.localScale = new Vector3(-1f, 1f, 1f); // para flipear la bala
             }*/
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
           // Debug.Log("Player");
            collision.SendMessage("EnemyKnockBack", transform.position.x);
        }

        if (collision.gameObject.tag == "Bala")
        {
            collision.SendMessage("EliminarBala");
            Destroy(gameObject);
        }
    }
}
