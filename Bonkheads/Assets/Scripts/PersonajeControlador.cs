using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControlador : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;

    public bool TocandoPiso;
    public bool TocandoPared;

    public float FuerzaSalto;
    private bool Saltar;
    public bool DobleSaltar;

    public GameObject Pies;
    private bool Slash;



    private bool movimiento = true;

    private Rigidbody2D Personaje;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TocandoPiso || TocandoPared)
            {
                Saltar = true;
                DobleSaltar = true;

            }
            else if (DobleSaltar)
            {
                Saltar = true;
                DobleSaltar = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Slash = true;
        }
    }

    private void FixedUpdate()
    {
        ComprobarSuelo();

        Vector3 fixedVelocity = Personaje.velocity;
        fixedVelocity.x *= 0.75f;

        if (TocandoPiso)
        {
            Personaje.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        if (!movimiento) h = 0;

        Personaje.AddForce(Vector2.right * Speed * h);

        float LimitSpeed = Mathf.Clamp(Personaje.velocity.x, -MaxSpeed, MaxSpeed);
        Personaje.velocity = new Vector2(LimitSpeed, Personaje.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Saltar)
        {
            Personaje.velocity = new Vector2(Personaje.velocity.x, 0);
            Personaje.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
            Saltar = false;
        }

        if (Slash)
        {
            Personaje.velocity = new Vector2(Personaje.velocity.x, 0);
            Personaje.AddForce(Vector2.right * 80 * h, ForceMode2D.Impulse);
            Slash = false;
        }
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(-7, 0, 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            TocandoPared = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            TocandoPared = false;
        }
    }

    void ComprobarSuelo()
    {
        RaycastHit2D colision = Physics2D.Raycast(new Vector2(Pies.transform.position.x, Pies.transform.position.y), new Vector2(0, -1), 0.05f);
        if(colision != null && colision.collider != null)
        {
            //Debug.Log(colision.collider.name);
            if(colision.transform.tag == "Plataforma")
            {
                TocandoPiso = true;
            }

            if (colision.transform.tag == "Plataforma Movil")
            {
                Personaje.velocity = new Vector3(0f, 0f, 0f);
                transform.parent = colision.transform;
                TocandoPiso = true;
            }

        }
        else
        {
            TocandoPiso = false;
            transform.parent = null;
        }
    }
}
