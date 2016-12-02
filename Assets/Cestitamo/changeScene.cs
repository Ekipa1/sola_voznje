using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization

    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
