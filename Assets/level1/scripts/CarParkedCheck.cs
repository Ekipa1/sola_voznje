using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarParkedCheck : MonoBehaviour {

    public GameObject avto;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //&& avto.transform.position.x<-200 && avto.transform.position.y<203.4 && avto.transform.position.y > 180
        if (avto.transform.position.x >-143 && avto.transform.position.x < -125.8 && avto.transform.position.y < 587.1 && avto.transform.position.y > 578.8 )
        {
            if((avto.transform.rotation.z > 0.59 && avto.transform.rotation.z < 0.83) || (avto.transform.rotation.z > -0.8 && avto.transform.rotation.z < -0.58))
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
