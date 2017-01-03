using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;
using System.Net;

public class Menu_Script_2 : MonoBehaviour {
	[SerializeField]
	public Button btnCpp;
	public Color btnBlueColor;
	public Button btnPp;
	public Color btnRedColor;
	public Button btnIgre;
	[SerializeField]
	private Text scoreText;	
	[SerializeField]
	private Text imeText;

	bool povezava = false;
	void Start()
	{
		string[] odg = new string[2];
		odg = PlayerPrefs.GetString ("Name").Split ("@" [0]);
		imeText.text = "Ime: " + odg[0];
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
		preveriPovezavo ();
		while (!povezava) {
			preveriPovezavo ();
			UnityEditor.EditorUtility.DisplayDialog("Opozorilo", "Ni internetne povezave!", "Ok");
		}
		StartCoroutine (getScore ());
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void izpis(){
		/*StreamWriter writer = new StreamWriter("data.txt");
		writer.WriteLine("");
		writer.Close();*/
		PlayerPrefs.DeleteKey("Name");
		PlayerPrefs.DeleteKey("CPP");
		PlayerPrefs.DeleteKey("PP");
		PlayerPrefs.DeleteKey("Igre");
		SceneManager.LoadScene("Login");
	}
	public void reset(){
		PlayerPrefs.DeleteKey("CPP");
		PlayerPrefs.DeleteKey("PP");
		PlayerPrefs.DeleteKey("Igre");
		btnPp.interactable = true;
		btnPp.image.color = btnBlueColor;
		btnCpp.interactable = false;
		btnCpp.image.color = btnRedColor;
		btnIgre.interactable = false;
		btnIgre.image.color = btnRedColor;
	}
	IEnumerator getScore()
	{
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
	public string GetHtmlFromUri(string resource)
	{
		string html = string.Empty;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (resource);
		try {
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse ()) {
				bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
				if (isSuccess) {
					using (StreamReader reader = new StreamReader (resp.GetResponseStream ())) {
						//We are limiting the array to 80 so we don't have
						//to parse the entire html document feel free to 
						//adjust (probably stay under 300)
						char[] cs = new char[80];
						reader.Read (cs, 0, cs.Length);
						foreach (char ch in cs) {
							html += ch;
						}
					}
				}
			}
		} catch {
			return "";
		}
		return html;
	}
	public void preveriPovezavo(){
		string HtmlText = GetHtmlFromUri("http://google.com");
		if(HtmlText == "")
		{
			povezava = false;
			//No connection
		}
		else if(!HtmlText.Contains("schema.org/WebPage"))
		{
			//Redirecting since the beginning of googles html contains that 
			//phrase and it was not found
		}
		else
		{
			povezava = true;
			//success
		}
	}
}
