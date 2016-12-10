using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrikazSekund : MonoBehaviour {

    public Text text;
	
	// Update is called once per frame
	void Update () {
        int a = PlayerPrefs.GetInt("Tocke");
        string b = a.ToString();

        text.text = b;
	}
}
