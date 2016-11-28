using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;

public class Menu_script : MonoBehaviour {
	[SerializeField]
	public Button btnCpp;
	public Color btnColor;
	void Start()
	{

	}
	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if (GlobalVariables.opravilPP == true) {
			btnCpp.interactable = true;
			btnCpp.image.color = btnColor;
			GlobalVariables.opravilPP = false;
			//btntext.text = "dada";
		}
	}
	public void ChangeScene (string sceneName){
		SceneManager.LoadScene(sceneName);
	}
	public void izpis(){
		StreamWriter writer = new StreamWriter("data.txt");
		writer.WriteLine("");
		writer.Close();
		SceneManager.LoadScene("Login");
	}
}
