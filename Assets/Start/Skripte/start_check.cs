using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;
public class start_check : MonoBehaviour {

	string user;
	bool neki=false;
	// Use this for initialization
	void Start () {
		//write ();
		read ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void write(){
		//Demonstrates how to create and write to a text file.
		StreamWriter writer = new StreamWriter("data.txt");
		writer.WriteLine("");
		writer.Close();
	}
	void read(){
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
		if (user != "") {
			SceneManager.LoadScene ("Menu");
		} else {
			SceneManager.LoadScene ("Login");
		}
	}
}
