using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Proga : MonoBehaviour {
    GameObject avto;
    void Start()
    {
        avto = GameObject.Find("avto");
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        SceneManager.LoadScene("Znova1");
    }
}
