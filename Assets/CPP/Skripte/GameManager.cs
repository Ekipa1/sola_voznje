using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;
public class GameManager : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}*/

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;

	public Button AnmButton1;
	public Color AnmColorRed;
	public Button AnmButton2;
	public Color AnmColorGreen;
	public Button AnmButton3;

	[SerializeField]
	private Text questionText;

	[SerializeField]
	private Text odgovor1;

	[SerializeField]
	private Text odgovor2;

	[SerializeField]
	private Text odgovor3;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text AnmOdg1Text;

	[SerializeField]
	private Text AnmOdg2Text;

	[SerializeField]
	private Text AnmOdg3Text;

	[SerializeField]
	private Animator animator;

	string praviOdg;
	string user;


	[SerializeField]
	private float timeBetweenQuestions = 1f;//1 second delay


	string    winDir=System.Environment.GetEnvironmentVariable("windir");

	void Start(){
		/*if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question>();
		}*/
		//SetCurrentQuestion ();
		if (GlobalVariables.stVprasanjaCPP < 1) {
			StartCoroutine (getScore ());
			StartCoroutine (newQuestion ());
		} else {
			//GlobalVariables.opravilCPP = true;
			GlobalVariables.stVprasanjaCPP=0;
			PlayerPrefs.SetInt("CPP", 1);
			SceneManager.LoadScene ("Menu");
		}
		//Debug.Log (currentQuestion.question + " is " + currentQuestion.isTrue); //izpis v konzoli
	}
	void SetCurrentQuestion(){
		/*int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];

		questionText.text = currentQuestion.question;
		odgovor1.text = currentQuestion.odg1;
		odgovor2.text = currentQuestion.odg2;
		odgovor3.text = currentQuestion.odg3;
		/*StartCoroutine (newQuestion ());
		if(odgovor1.text==praviOdg){
			AnmButton1.image.color = Color.green;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="PRAVILNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="NAPAČNO";
		}else if(odgovor2.text==praviOdg){
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.green;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="PRAVILNO";
			AnmOdg3Text.text="NAPAČNO";
		}else if(odgovor3.text==praviOdg){
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.green;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="PRAVILNO";
		}*/
	}

	IEnumerator TransitionToNextQuestion(){
		//unansweredQuestions.Remove(currentQuestion);
		questionText.text="";
		yield return new WaitForSeconds (timeBetweenQuestions);//cakamo med vprasanji

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void UserSelectAnswer1(){
		animator.SetTrigger ("Odg1");
		if (odgovor1.text == praviOdg) {
			StartCoroutine (setScore ());
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer2(){
		animator.SetTrigger ("Odg2");
		if (odgovor2.text == praviOdg) {
			StartCoroutine (setScore ());
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer3(){
		animator.SetTrigger ("Odg3");
		if (odgovor3.text == praviOdg) {
			StartCoroutine (setScore ());
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	IEnumerator getScore()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//string email = "colic@gmail.com";
		//read();
		string getScoreURL = "http://31.15.251.14/sola_voznje/get_score.php?";
		string post_url = getScoreURL + "email=" + PlayerPrefs.GetString("Name");

		var hs_post = new WWW (post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("Napaka v pošiljanju podatkov: " + hs_post.error);
		}  else {
			//Debug.Log ("POSLANO!");
			scoreText.text ="Tocke: " + hs_post.text;
			//SceneManager.LoadScene ("Menu");
		}

	}

	IEnumerator setScore()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//read();
		//string email = "colic@gmail.com";
		string setScoreURL = "http://31.15.251.14/sola_voznje/set_score.php?";
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

	//baza
	IEnumerator newQuestion()
	{
		GlobalVariables.stVprasanjaCPP++;
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//read();
		string kviz="CPP";
		//string user = "colic@gmail.com";
		string dobiVprasanje = "http://31.15.251.14/sola_voznje/question.php?";
		string post_url = dobiVprasanje + "kviz=" + kviz + "&email=" + PlayerPrefs.GetString("Name");
		string data;
		var hs_post = new WWW (post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("Napaka v pošiljanju podatkov: " + hs_post.error);
		}  else {
			//Debug.Log ("POSLANO!");
			//questionText.text= hs_post.text;
			data=hs_post.text;
			string[] podatki=new string[3];
			podatki=data.Split("*"[0]);  
			questionText.text = podatki [0];
			string[] odg = new string[3];
			odg = podatki [1].Split (";" [0]);
			odgovor1.text = odg [0];
			odgovor2.text = odg [1];
			odgovor3.text = odg [2];
			/*bool ena = false, dva=false, nic=false, obstaja=true;
			int[] tab=new int[3];
			for (int x = 0; x < 3; x++) {
				tab [x] = -1;
			}
			int y = 0;
			for (;;) {
				int rand = Random.Range (0, 2);
				for (int x = 0; x < 3; x++) {
					if (tab [x] != rand) {
						tab [y] = rand;
						y++;
						break;
						obstaja = false;
					}
				}
				if (obstaja = false) {
					if (nic==false) {
						odgovor1.text = odg [rand];
						nic=true;
					} else if (ena == false) {
						odgovor2.text = odg [rand];
						ena=true;
					} else if (dva == false) {
						odgovor3.text = odg [rand];
						dva=true;
					}
					if (nic == true && ena == true && dva == true) {
						break;
					}
					obstaja = true;
				}
			}*/
			praviOdg = podatki [2];
			if(odg[0]==praviOdg){
				AnmButton1.image.color = Color.green;
				AnmButton2.image.color = Color.red;
				AnmButton3.image.color = Color.red;
				AnmOdg1Text.text="PRAVILNO";
				AnmOdg2Text.text="NAPAČNO";
				AnmOdg3Text.text="NAPAČNO";
			}else if(odg[1]==praviOdg){
				AnmButton1.image.color = Color.red;
				AnmButton2.image.color = Color.green;
				AnmButton3.image.color = Color.red;
				AnmOdg1Text.text="NAPAČNO";
				AnmOdg2Text.text="PRAVILNO";
				AnmOdg3Text.text="NAPAČNO";
			}else if(odg[2]==praviOdg){
				AnmButton1.image.color = Color.red;
				AnmButton2.image.color = Color.red;
				AnmButton3.image.color = Color.green;
				AnmOdg1Text.text="NAPAČNO";
				AnmOdg2Text.text="NAPAČNO";
				AnmOdg3Text.text="PRAVILNO";
			}
			//SceneManager.LoadScene ("Menu");
		}

	}
	/*void read(){
		//How to read a text file.
		//try...catch is to deal with a 0 byte file.
		StreamReader reader = new StreamReader("data.txt");
		try {
			do {
				user=reader.ReadLine();
			}
			while (reader.Peek() != -1);
		}
		catch {
		}
		reader.Close ();
	}*/


}
