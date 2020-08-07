using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControlador : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;

    public float FuerzaSalto;
    private bool Saltar;
 
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
           
                Saltar = true;
            
        }
    }

    private void FixedUpdate()
    {
        Vector3 fixedVelocity = Personaje.velocity;
        fixedVelocity.x *= 0.75f;


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
    }
}
