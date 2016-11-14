using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour {

	public void ChangeScene (string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
