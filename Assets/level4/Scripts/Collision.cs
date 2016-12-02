using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{



    // Use this for initialization
    void OnCollisionEnter2D(Collision2D Collection)
    {
        if (Collection.gameObject.name == "prvi_avto")
        {

            SceneManager.LoadScene("Poskusi_znova");

        }
    }


}
