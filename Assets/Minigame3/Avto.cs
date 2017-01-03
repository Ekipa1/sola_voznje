using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Avto : MonoBehaviour {

    public GameObject navodila;
    int cp = 0;
    public Text cas;
    float timeLeft = 0;
    float speed = 10f;
    float torque = -2f;
    public static Avto instace;
    public int dol = 0;
    public int gor = 0;
    public int levo = 0;
    public int desno = 0;
    // Use this for initialization
    void Start () {
        instace = this;
        PlayerPrefs.SetInt("Ura", 0);
        timeLeft = 0;
        navodila = GameObject.Find("navodila");
        PlayerPrefs.SetInt("izvedi", 0);
        StartCoroutine(Example());
    }
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown("space")){
			StartCoroutine (setScore ());
			SceneManager.LoadScene("Cestitamo");
		}
        if (PlayerPrefs.GetInt("izvedi") == 1)
        {

        
        if (transform.position.y > -17.23 && transform.position.y < -13.7 && transform.position.x < 3 && transform.position.x > 1)
        {
            cp = 1;
            
        }

        if (transform.position.y > -17.23 && transform.position.y < -13.7 && transform.position.x < 9.1 && transform.position.x > 8.42)
        {
            PlayerPrefs.SetInt("Ura", 1);
           // timeLeft = 0;

            if (cp == 1)
            {
                if (timeLeft < 40)
                {
                    SceneManager.LoadScene("Cestitamo");
                }
                else
                {
                    SceneManager.LoadScene("Znova1");
                }
               // Debug.Log("Konec");
                timeLeft = 0;
                cp = 0;
            }
        }
        if (PlayerPrefs.GetInt("Ura") == 1)
        {
            timeLeft += Time.deltaTime;
            double rounded = Math.Round(timeLeft, 1);
            cas.text = rounded.ToString();
        }
        }
    }

    void FixedUpdate ()
    {
        if (PlayerPrefs.GetInt("izvedi") == 1)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.UpArrow) || gor == 1)
            {
                rb.AddForce(transform.right * speed);
            }

            if (Input.GetKey(KeyCode.DownArrow) || dol == 1)
            {
                rb.AddForce(transform.right * -speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || levo == 1)
            {
                rb.AddTorque(-torque);
            }

            if (Input.GetKey(KeyCode.RightArrow) || desno == 1)
            {
                rb.AddTorque(torque);
            }
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        navodila.SetActive(false);
        yield return new WaitForSeconds(1);
        navodila.SetActive(true);
        yield return new WaitForSeconds(1);
        navodila.SetActive(false);
        PlayerPrefs.SetInt("izvedi", 1);
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
