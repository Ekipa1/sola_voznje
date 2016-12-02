using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class carparkchecked3 : MonoBehaviour {

    public GameObject avto;
    //public Text asd;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //asd.text="x: " + avto.transform.position.x.ToString () + " y: " + avto.transform.position.y.ToString () + " Z: " + avto.transform.rotation.z.ToString ();
        //&& avto.transform.position.x<-200 && avto.transform.position.y<203.4 && avto.transform.position.y > 180
        if (avto.transform.position.x > -215 && avto.transform.position.x < -190 && avto.transform.position.y < 195 && avto.transform.position.y > 185)
        {
            if ((avto.transform.rotation.z < -0.85 && avto.transform.rotation.z > -0.95) || (avto.transform.rotation.z > 0.2 && avto.transform.rotation.z < 0.45))
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
