using UnityEngine;
using System.Collections;

public class Sekunde : MonoBehaviour {

    int sec;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Tocke", 0);
        PlayerPrefs.SetInt("Delaj", 1);
    }

    int delaj = 1;
	// Update is called once per frame
	void Update () {

        if (delaj == 1)
        {
            StartCoroutine(Example());
        }
        
    }

    IEnumerator Example()
    {
        delaj = 0;
        yield return new WaitForSeconds(1);
        int getTocke = PlayerPrefs.GetInt("Tocke");
        if (PlayerPrefs.GetInt("Delaj") == 1)
        {
            PlayerPrefs.SetInt("Tocke", getTocke + 1);
        }
        
        delaj = 1;
    }
}
