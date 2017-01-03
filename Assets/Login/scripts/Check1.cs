using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class Check1 : MonoBehaviour {

    public InputField mail;
    public InputField geslo;
    public Text email_obstaja;
    public Text email;
    public Text neujemanje1;


    public void poslji()
    {
        StartCoroutine(PostScores(mail.text, geslo.text));
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string email, string geslo)
    {

     
        // Post the URL to the site and create a download object to get the result.

        string highscoreURL = "http://31.15.251.14/sola_voznje/login.php?" + "email=" + email + "&geslo=" + geslo;
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("Napaka pri preverjanju emaila: " + hs_get.error);
        }
        else if (hs_get.text == "Neobstaja!")
        {
            Debug.Log("Neobstoječ e-naslov!");
            email_obstaja.enabled = false;
            Debug.Log(highscoreURL);
        }
        else
        {
			//write ();
			PlayerPrefs.SetString("Name", mail.text);
            SceneManager.LoadScene("Start");
        
        }

    }
	/*void write(){
		//Demonstrates how to create and write to a text file.
		StreamWriter writer = new StreamWriter("data.txt");
		writer.WriteLine(mail.text);
		writer.Close();
	}*/

	public void naloziReg(){
		SceneManager.LoadScene("Registracija");
	}
}
