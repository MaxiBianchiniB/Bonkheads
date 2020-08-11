using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DibujarDestino : MonoBehaviour
{
    public Transform inicio, destino;
    private void OnDrawGizmosSelected()
    {
        if (inicio != null && destino != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(inicio.position, destino.position);
        }
    }
}
