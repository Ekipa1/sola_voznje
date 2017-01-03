using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScene()
    {
        //SceneManager.LoadScene("Menu");
		if (PlayerPrefs.GetInt ("Igre") == 1) {
			PlayerPrefs.SetInt ("Igre", 2);
		}else if (PlayerPrefs.GetInt ("Igre") == 2) {
			PlayerPrefs.SetInt ("Igre", 3);
		}else if (PlayerPrefs.GetInt ("Igre") == 3) {
			PlayerPrefs.SetInt ("Igre", 4);
		}else if (PlayerPrefs.GetInt ("Igre") == 4) {
			PlayerPrefs.SetInt ("Igre", 5);
		}else if (PlayerPrefs.GetInt ("Igre") == 5) {
			PlayerPrefs.SetInt ("Igre", 6);
		}else if (PlayerPrefs.GetInt ("Igre") == 6) {
			PlayerPrefs.SetInt ("Igre", 7);
		}else if (PlayerPrefs.GetInt ("Igre") == 7) {
			PlayerPrefs.SetInt ("Igre", 8);
		}
		SceneManager.LoadScene("Voznja");
    }
}
