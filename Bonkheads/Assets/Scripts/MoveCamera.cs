using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject seguir;

    public UnityEngine.Vector2 MinCamPos, MaxCamPos;

    public float SmoothTime;

    private UnityEngine.Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velocity.x, SmoothTime);// seguir.transform.position.x;
        float posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velocity.y, SmoothTime);// seguir.transform.position.y;

        transform.position = new UnityEngine.Vector3( Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x), Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y), transform.position.z);
    }
}
