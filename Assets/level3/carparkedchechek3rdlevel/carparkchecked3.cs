using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class carparkchecked3 : MonoBehaviour {

    public GameObject avto;
    Rigidbody2D rb;
    //public Text asd;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //asd.text="x: " + avto.transform.position.x.ToString () + " y: " + avto.transform.position.y.ToString () + " Z: " + avto.transform.rotation.z.ToString ();
        //x: -88.05576 y: 579.7932 Z: 0.7085215
        // || (avto.transform.rotation.z > 0.2 && avto.transform.rotation.z < 0.45)

        if (avto.transform.position.x > -89 && avto.transform.position.x < -55 && avto.transform.position.y < 590 && avto.transform.position.y > 546)
        {
            if ((avto.transform.rotation.z < 0.80 && avto.transform.rotation.z > 0.55) || (avto.transform.rotation.z > 0.2 && avto.transform.rotation.z < 0.45))
            {
                StartCoroutine(MyCoroutine());

            }
            //Debug.Log("DELA");
        }
        // Debug.Log(avto.transform.rotation.z);
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        // SceneManager.LoadScene("Cestitamo");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Cestitamo");
        //DoSomethingElse();
    }
}
