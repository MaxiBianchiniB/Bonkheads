using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public Transform puntoinstancia;
    public GameObject Bala;

    private float tiempodisparo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempodisparo += Time.deltaTime;

        if (Input.GetKey(KeyCode.S) && tiempodisparo >= 1f)
        {
            Instantiate(Bala, puntoinstancia.position, Quaternion.identity);
            tiempodisparo = 0f;
        }
    }
}
