using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{
    private PersonajeControlador Jugador;
   // private Rigidbody2D Cuerpo;

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GetComponentInParent<PersonajeControlador>();
        //Cuerpo = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            Jugador.TocandoPiso = true;
        }

        if (collision.gameObject.tag == "Plataforma Movil")
        {
            Jugador.transform.parent = collision.transform;
            Jugador.TocandoPiso = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            Jugador.TocandoPiso = false;
        }

        if (collision.gameObject.tag == "Plataforma Movil")
        {
            Jugador.transform.parent = null;
            Jugador.TocandoPiso = false;
        }
    }
}
