using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControlador : MonoBehaviour
{
    public float MaxSpeed;
    public float speed;

    private float TiempoMuerte = 3f;
   // private Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
       // rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, TiempoMuerte);
    }

    void fixedUpdate()
    {
     //   rgb.velocity = new Vector2(speed * 3, rgb.position.y);
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
