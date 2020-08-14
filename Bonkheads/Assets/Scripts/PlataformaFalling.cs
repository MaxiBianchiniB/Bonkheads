using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour
{
    public float temporizador;
    public float RespawnTemporizador;

    private UnityEngine.Vector3 start;

    private Rigidbody2D Plataforma;
    private BoxCollider2D colisionador;
    // Start is called before the first frame update
    void Start()
    {
        Plataforma = GetComponent<Rigidbody2D>();
        colisionador = GetComponent<BoxCollider2D>();

        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Caida", temporizador);
            Invoke("Respawn", temporizador + RespawnTemporizador);
        }
    }

    void Caida()
    {
        Plataforma.isKinematic = false;
        colisionador.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = start;
        Plataforma.isKinematic = true;
        Plataforma.velocity = UnityEngine.Vector3.zero;
        colisionador.isTrigger = false;

    }
}
