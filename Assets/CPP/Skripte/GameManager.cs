﻿using UnityEngine;
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
	private Text AnmOdg1Text;

	[SerializeField]
	private Text AnmOdg2Text;

	[SerializeField]
	private Text AnmOdg3Text;

	[SerializeField]
	private Animator animator;

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
		if(currentQuestion.odg1==currentQuestion.pravilniOdg){
			AnmButton1.image.color = Color.green;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="PRAVILNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="NAPAČNO";
		}else if(currentQuestion.odg2==currentQuestion.pravilniOdg){
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.green;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="PRAVILNO";
			AnmOdg3Text.text="NAPAČNO";
		}else if(currentQuestion.odg3==currentQuestion.pravilniOdg){
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.green;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="PRAVILNO";
		}
	}

	IEnumerator TransitionToNextQuestion(){
		unansweredQuestions.Remove(currentQuestion);

		yield return new WaitForSeconds (timeBetweenQuestions);//cakamo med vprasanji

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void UserSelectAnswer1(){
		animator.SetTrigger ("Odg1");
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer2(){
		animator.SetTrigger ("Odg2");
		StartCoroutine (TransitionToNextQuestion ());
	}
	public void UserSelectAnswer3(){
		animator.SetTrigger ("Odg3");
		StartCoroutine (TransitionToNextQuestion ());
	}
}
