using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Avto_premik : MonoBehaviour
{

    public GameObject avto;
    public float speed = 1.5f;
    // Update is called once per frame


    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
		if (Input.GetKeyDown("space")){
			StartCoroutine (setScore ());
			SceneManager.LoadScene("Cestitamo");
		}
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Levo1();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Desno1();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Stop();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Stop();
        }

        if (avto.transform.position.x < -3)
        {
            avto.transform.position = new Vector3(-3, -2, 0);
        }

        if (avto.transform.position.x > 3)
        {
            avto.transform.position = new Vector3(3, -2, 0);
        }

    }

    public void Levo1()
    {
        if ((transform.position.x > -2.97))
        {
            rb.velocity = new Vector2(-speed, 0);
        }


    }

    public void Desno1()
    {
        if ((transform.position.x < 2.95))
        {
            rb.velocity = new Vector2(speed, 0);
        }

    }

    public void Levo()
    {
        float a = avto.transform.position.x;
        if (a > -2.97)
        {
            rb.velocity = new Vector2(-speed, 0);
            a = avto.transform.position.x;
        }
    }

    public void Desno()
    {
        if (this.transform.position.x < 2.95)
        {
            rb.velocity = new Vector2(speed, 0);
        }


    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D Collection)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        PlayerPrefs.SetInt("Delaj", 0);
        //avto.SetActive(false);

        StartCoroutine(Example());

    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(4);
		StartCoroutine (setScore ());
		SceneManager.LoadScene("Cestitamo");
        //SceneManager.LoadScene("Menu");
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

