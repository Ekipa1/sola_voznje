using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu_script : MonoBehaviour {

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
