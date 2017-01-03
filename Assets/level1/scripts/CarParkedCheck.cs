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

		StartCoroutine (setScore ());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Cestitamo");
        //DoSomethingElse();
    }
	IEnumerator setScore()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//read();
		//string email = "colic@gmail.com";
		string setScoreURL = "http://31.15.251.14/sola_voznje/set_score_level.php?";
		string post_url = setScoreURL + "email=" + PlayerPrefs.GetString("Name");

		var hs_post = new WWW (post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("Napaka v pošiljanju podatkov: " + hs_post.error);
		}  /*else {
			//Debug.Log ("POSLANO!");
			scoreText.text ="Tockeeee: " + hs_post.text;
			//SceneManager.LoadScene ("Menu");
		}*/

	}
}
