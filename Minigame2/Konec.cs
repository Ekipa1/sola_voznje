using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Konec : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "avto")
        {
            if (PlayerPrefs.GetFloat("cas") < 28)
            {
                SceneManager.LoadScene("Cestitamo");

            }
            else
            {
                SceneManager.LoadScene("M2Znova");
            }
        }
            

    }
}
