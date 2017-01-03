using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;

public class Igre_Skript : MonoBehaviour {
	[SerializeField]
	public Button btnLvl1;
	public Button btnLvl2;
	public Button btnLvl3;
	public Button btnLvl4;
	public Button btnMG1;
	public Button btnMG2;
	public Button btnMG3;
	public Button btn3D;
	public Color btnBlueColor;
	public Color btnRedColor;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
		if (PlayerPrefs.GetInt ("Igre") == 1) {
			btnLvl1.interactable = true;
			btnLvl1.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 2) {
			btnLvl1.interactable = false;
			btnLvl1.image.color = btnRedColor;
			btnLvl2.interactable = true;
			btnLvl2.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 3) {
			btnLvl2.interactable = false;
			btnLvl2.image.color = btnRedColor;
			btnLvl3.interactable = true;
			btnLvl3.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 4) {
			btnLvl3.interactable = false;
			btnLvl3.image.color = btnRedColor;
			btnLvl4.interactable = true;
			btnLvl4.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 5) {
			btnLvl4.interactable = false;
			btnLvl4.image.color = btnRedColor;
			btnMG1.interactable = true;
			btnMG1.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 6) {
			btnMG1.interactable = false;
			btnMG1.image.color = btnRedColor;
			btnMG2.interactable = true;
			btnMG2.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 7) {
			btnMG2.interactable = false;
			btnMG2.image.color = btnRedColor;
			btnMG3.interactable = true;
			btnMG3.image.color = btnBlueColor;
		}else if (PlayerPrefs.GetInt ("Igre") == 8) {
			btnMG3.interactable = false;
			btnMG3.image.color = btnRedColor;
			btn3D.interactable = true;
			btn3D.image.color = btnBlueColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void resetIgra(){
		PlayerPrefs.DeleteKey("Igre");
		/*btnLvl1.interactable = true;
		btnLvl1.image.color = btnBlueColor;
		btnLvl2.interactable = false;
		btnLvl2.image.color = btnRedColor;
		btnLvl3.interactable = false;
		btnLvl3.image.color = btnRedColor;
		btnLvl4.interactable = false;
		btnLvl4.image.color = btnRedColor;
		btnMG1.interactable = false;
		btnMG1.image.color = btnRedColor;
		btnMG2.interactable = false;
		btnMG2.image.color = btnRedColor;
		btnMG3.interactable = false;
		btnMG3.image.color = btnRedColor;
		btn3D.interactable = false;
		btn3D.image.color = btnRedColor;*/
		SceneManager.LoadScene("Menu");
	}
}
