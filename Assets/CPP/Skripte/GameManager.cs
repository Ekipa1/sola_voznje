using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
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

	[SerializeField]
	private Text questionText;

	[SerializeField]
	private Text odgovor1;

	[SerializeField]
	private Text odgovor2;

	[SerializeField]
	private Text odgovor3;

	[SerializeField]
	private float timeBetweenQuestions = 1f;//1 second delay

	void Start(){
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question>();
		}
		SetCurrentQuestion ();
		//Debug.Log (currentQuestion.question + " is " + currentQuestion.isTrue); //izpis v konzoli
	}


	void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];

		questionText.text = currentQuestion.question;
		odgovor1.text = currentQuestion.odg1;
		odgovor2.text = currentQuestion.odg2;
		odgovor3.text = currentQuestion.odg3;

	}

	IEnumerator TransitionToNextQuestion(){
		unansweredQuestions.Remove(currentQuestion);

		yield return new WaitForSeconds (timeBetweenQuestions);//cakamo med vprasanji

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void UserSelectAnswer1(){
		if (currentQuestion.pravilniOdg == odgovor1.text) {
			Debug.Log (currentQuestion.question + " PRAV JE"); //izpis v konzoli
		} else {
			Debug.Log (currentQuestion.question + " Narobe JE"); //izpis v konzoli
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer2(){
		if (currentQuestion.pravilniOdg == odgovor2.text) {
			Debug.Log (currentQuestion.question + " PRAV JE"); //izpis v konzoli
		} else {
			Debug.Log (currentQuestion.question + " Narobe JE"); //izpis v konzoli
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer3(){
		if (currentQuestion.pravilniOdg == odgovor3.text) {
			Debug.Log (currentQuestion.question + " PRAV JE"); //izpis v konzoli
		} else {
			Debug.Log (currentQuestion.question + " Narobe JE"); //izpis v konzoli
		}
		StartCoroutine (TransitionToNextQuestion ());
	}
}
