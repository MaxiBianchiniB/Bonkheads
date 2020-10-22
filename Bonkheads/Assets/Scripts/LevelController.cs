using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    string LevelName;

    [System.Obsolete]
    void Start()
    {
        LevelName = Application.loadedLevelName;
       // LevelName = SceneManager.;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hizo contacto");
            if (LevelName == "Level 1")
            {
                Debug.Log("Este es el level 1");
                SceneManager.LoadScene("Level 2");
            }
            else if (LevelName == "Level 2")
            {
                SceneManager.LoadScene("Menu");////SEGUIR AGREGANDO SEGUN LA CANTIDAD DE NIVELES
            }
        }
    }
 
    public void CargarLevel(string NombreLevel)
    { 
        SceneManager.LoadScene(NombreLevel);
    }
}
