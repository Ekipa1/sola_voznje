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
        SceneManager.LoadScene("Menu");
    }
}

