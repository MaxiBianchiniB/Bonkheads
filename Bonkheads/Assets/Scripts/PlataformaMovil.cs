using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform Destino;
    public float speed;

    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        if (Destino != null)
        {
            Destino.parent = null;
            start = transform.position;
            end = Destino.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Destino != null)
        {
            float fixedspeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Destino.position, fixedspeed);
        }

        if (transform.position == Destino.position)
        {
            Destino.position = (Destino.position == start) ? end : start;
        }
    }
}
