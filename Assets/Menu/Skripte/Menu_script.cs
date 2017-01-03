using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;

public class Menu_script : MonoBehaviour {
	/*[SerializeField]
	public Button btnCpp;
	public Color btnBlueColor;
	public Button btnPp;
	public Color btnRedColor;
	public Button btnIgre;
	void Start()
	{
		if (PlayerPrefs.HasKey ("CPP") && PlayerPrefs.HasKey ("PP")) {
			btnCpp.interactable = false;
			btnCpp.image.color = btnRedColor;
			btnPp.interactable = false;
			btnPp.image.color = btnRedColor;
			btnIgre.interactable = true;
			btnIgre.image.color = btnBlueColor;
			if (!PlayerPrefs.HasKey ("Igre")) {
				PlayerPrefs.SetInt("Igre", 1);
			}
		}else{
			if (PlayerPrefs.HasKey ("PP")) {
				btnCpp.interactable = true;
				btnCpp.image.color = btnBlueColor;
				btnPp.interactable = false;
				btnPp.image.color = btnRedColor;
			}
			if (PlayerPrefs.HasKey ("CPP")) {
				btnCpp.interactable = false;
				btnCpp.image.color = btnRedColor;
				btnPp.interactable = false;
				btnPp.image.color = btnRedColor;
			}
		}
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
	}*/
	public void ChangeScene (string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
