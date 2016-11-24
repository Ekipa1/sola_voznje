using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HSController : MonoBehaviour
{
	//public string addScoreURL = "http://31.15.251.14/sola_voznje/registration.php?"; //be sure to add a ? to your url

	public InputField mail;
	public InputField geslo;
	public InputField geslo_ponovno;
	public Dropdown kat;
	public Text email;
	public Text neujemanje1;
	public Text neujemanje2;
	public Text prekratko;
	public Text email_obstaja;

	public void naloziLog(){
		SceneManager.LoadScene ("Login");
	}

	public void poslji(){
		email.enabled = false;
		neujemanje1.enabled = false;
		neujemanje2.enabled = false;
		prekratko.enabled = false;
		bool napaka = false;
		email_obstaja.enabled = false;
		string k = null;
		if (kat.value == 0) {
			k = "B";
		}
		if (kat.value == 1) {
			k = "A";
		}
		if (kat.value == 2) {
			k = "C";
		}

		int dolzinaGesla = geslo.text.Length;

		if (mail.text == "" || mail.text.Length<5 || mail.text.Contains("@") != true || mail.text.Contains(".") != true) {
			email.enabled = true;
			napaka = true;
		}
		if (geslo.text != geslo_ponovno.text) {
			if (prekratko.enabled == false) {
				neujemanje1.enabled = true;
				neujemanje2.enabled = true;
				napaka = true;
			}
		} 
		if (dolzinaGesla < 5) {
			if (neujemanje1.enabled == false && neujemanje2.enabled == false) {
				prekratko.enabled = true;
				napaka = true;
			}
		}
		if(napaka==false){
			StartCoroutine (PostScores(mail.text,geslo.text,k));
		}
	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string email, string geslo, string kat)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//string kat="B";
		string ui = "KlemenKac";
		//string geslo = "kac3";
		//string email = "xklemenx@gmail.com";
		string datum = "10.11.2016";
		string addScoreURL = "http://31.15.251.14/sola_voznje/registration.php?";
		string post_url = addScoreURL + "kat=" + kat + "&ui=" + ui + "&geslo=" + geslo + "&email=" + email + "&datum=" + datum;

		//string izpisi = addScoreURL + "kat=" + kat + "&ui=" + ui + "&geslo=" + geslo + "&email=" + email + "&datum=" + datum;
		//print (izpisi);
		// Post the URL to the site and create a download object to get the result.

		string highscoreURL = "http://31.15.251.14/sola_voznje/check_email.php?" + "email=" + email;
		WWW hs_get = new WWW (highscoreURL);
		yield return hs_get;

		if (hs_get.error != null) {
			print ("Napaka pri preverjanju emaila: " + hs_get.error);
		} else if (hs_get.text != "Neobstaja!") {
			//Debug.Log ("EMAIL ZE OBSTAJA");
			email_obstaja.enabled = true;
		} else {
			
			WWW hs_post = new WWW (post_url);
			yield return hs_post; // Wait until the download is done

			if (hs_post.error != null) {
				print ("Napaka v pošiljanju podatkov: " + hs_post.error);
			} else {
				//Debug.Log ("POSLANO!");
				SceneManager.LoadScene ("Menu");
			}
		}

	}
}