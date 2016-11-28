using UnityEngine;
using System.Collections;
using System.Collections.Generic;// za list
using System.Linq;//za unansweredQuestions = questions.ToList<Question>();
using UnityEngine.UI;// za text
using UnityEngine.SceneManagement;//
using System.IO;

public class quiz_pp : MonoBehaviour {

    private Button theButton;
    private ColorBlock theColor;

    public Question_[] vprasanje;
    //public Question odgovor;
    private static List<Question_> neodgovorjeno;
    //private static List<Question> nomarksanswer;

    private Question_ current_question;
    private Question_ current_answer;
	//za animacjo
	[SerializeField]
	private Text AnmOdg1Text;

	[SerializeField]
	private Text AnmOdg2Text;

	[SerializeField]
	private Text AnmOdg3Text;

	public Button AnmButton1;
	public Color AnmColorRed;
	public Button AnmButton2;
	public Color AnmColorGreen;
	public Button AnmButton3;

	[SerializeField]
	private Animator animator;
	//do tu

	[SerializeField]
	private Text scoreText;

    [SerializeField]
    private Text vprasanje_text;
    [SerializeField]
    private Text odgovori_text;
    [SerializeField]
    private Text odgovori_text2;
    [SerializeField]
    private Text odgovori_text3;
    /*[SerializeField]
    private Text pravilni_odgovor;*/


    [SerializeField]
    private float TimeBetweenQuestions = 1.0f;

	string praviOdg;
	string user;

    // Use this for initialization
    void Start()
    {

       /* if (neodgovorjeno == null || neodgovorjeno.Count == 0)
        {
            neodgovorjeno = vprasanje.ToList<Question_>();

        }

        SetCurrentQuestion();
        SetCurrentAnswer();
        SetCurrentAnswer2();
        SetCurrentAnswer3();*/
		if (GlobalVariables.stVprasanjaPP < 1) {
			StartCoroutine (getScore ());
			StartCoroutine (newQuestion ());
		} else {
			GlobalVariables.opravilPP = true;
			SceneManager.LoadScene ("Menu");
		}

    }


    /*void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, neodgovorjeno.Count);
        current_question = neodgovorjeno[randomQuestionIndex];

        vprasanje_text.text = current_question.vprasanje_;
		if (current_question.odgovor1.ToString() == current_question.pravilniodgovor.ToString())
		{
			AnmButton1.image.color = Color.green;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="PRAVILNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="NAPAČNO";
			Debug.Log("CORRECT!");
		}
		if (current_question.odgovor2.ToString() == current_question.pravilniodgovor.ToString())
		{
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.green;
			AnmButton3.image.color = Color.red;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="PRAVILNO";
			AnmOdg3Text.text="NAPAČNO";
			Debug.Log("CORRECT");
		}
		if (current_question.odgovor3.ToString() == current_question.pravilniodgovor.ToString())
		{
			AnmButton1.image.color = Color.red;
			AnmButton2.image.color = Color.red;
			AnmButton3.image.color = Color.green;
			AnmOdg1Text.text="NAPAČNO";
			AnmOdg2Text.text="NAPAČNO";
			AnmOdg3Text.text="PRAVILNO";
			Debug.Log("CORRECT");
		}
        neodgovorjeno.RemoveAt(randomQuestionIndex);
    }

    /* public void UserSelectAnswer()
     {
         if(current_question.isTrue) {
             Debug.Log("CORRECT!");
         } else
         {
             Debug.Log("Wrong!");
         }
     }*/

   /* void SetCurrentAnswer()
    {
        odgovori_text.text = current_question.odgovor1;
    }

    void SetCurrentAnswer2()
    {
        odgovori_text2.text = current_question.odgovor2;
    }

    void SetCurrentAnswer3()
    {
        odgovori_text3.text = current_question.odgovor3;
    }

    /*public void naprej()
    {
        StartCoroutine(TransitionTonextQuestion());
    }*/

    IEnumerator TransitionTonextQuestion()
    {
        //neodgovorjeno.Remove(current_question);
		//vprasanje_text.text="";
        yield return new WaitForSeconds(TimeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void pravilini() {

        //string od1 = current_question.odgovor1.ToString();

		animator.SetTrigger ("Odg1");
		if (odgovori_text.text == praviOdg)
        {
            //Debug.Log("CORRECT!");
			StartCoroutine (setScore ());
        }

        StartCoroutine(TransitionTonextQuestion());

    }

    public void pravilni2() {
		animator.SetTrigger ("Odg2");
		if (odgovori_text2.text == praviOdg)
		{
			//Debug.Log("CORRECT!");
			StartCoroutine (setScore ());
		}

		StartCoroutine(TransitionTonextQuestion());
       /* if (current_question.odgovor2.ToString() == current_question.pravilniodgovor.ToString())
        {
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("WRONG!");
        }*/

        StartCoroutine(TransitionTonextQuestion());
    }

    public void pravilni3()
	{
		animator.SetTrigger ("Odg3");
		if (odgovori_text3.text == praviOdg)
		{
			//Debug.Log("CORRECT!");
			StartCoroutine (setScore ());
		}
       /* if (current_question.odgovor3.ToString() == current_question.pravilniodgovor.ToString())
        {
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("WRONG!");
        }*/

        StartCoroutine(TransitionTonextQuestion());
    }
    



    public void userSelectFirst()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	//baza
	IEnumerator getScore()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		//string email = "colic@gmail.com";
		read();
		string getScoreURL = "http://31.15.251.14/sola_voznje/get_score.php?";
		string post_url = getScoreURL + "email=" + user;

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

	IEnumerator setScore()
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		read();
		//string email = "colic@gmail.com";
		string setScoreURL = "http://31.15.251.14/sola_voznje/set_score.php?";
		string post_url = setScoreURL + "email=" + user;

		var hs_post = new WWW (post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("Napaka v pošiljanju podatkov: " + hs_post.error);
		}  /*else {
			//Debug.Log ("POSLANO!");
			scoreText.text ="Tockeeee: " + hs_post.text;
			//SceneManager.LoadScene ("Menu");
		}*/

	}

	//baza
	IEnumerator newQuestion()
	{
		GlobalVariables.stVprasanjaPP++;
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//string hash = MD5Test.Md5Sum(name + score + secretKey);
		read();
		string kviz="PP";
		//string user = "colic@gmail.com";
		string dobiVprasanje = "http://31.15.251.14/sola_voznje/question.php?";
		string post_url = dobiVprasanje + "kviz=" + kviz + "&email=" + user;
		string data;
		var hs_post = new WWW (post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("Napaka v pošiljanju podatkov: " + hs_post.error);
		}  else {
			//Debug.Log ("POSLANO!");
			//questionText.text= hs_post.text;
			data=hs_post.text;
			string[] podatki=new string[3];
			podatki=data.Split("*"[0]);  
			vprasanje_text.text = podatki [0];
			string[] odg = new string[3];
			odg = podatki [1].Split (";" [0]);
			odgovori_text.text = odg [0];
			odgovori_text2.text = odg [1];
			odgovori_text3.text = odg [2];
			/*bool ena = false, dva=false, nic=false, obstaja=true;
			int[] tab=new int[3];
			for (int x = 0; x < 3; x++) {
				tab [x] = -1;
			}
			int y = 0;
			for (;;) {
				int rand = Random.Range (0, 2);
				for (int x = 0; x < 3; x++) {
					if (tab [x] != rand) {
						tab [y] = rand;
						y++;
						break;
						obstaja = false;
					}
				}
				if (obstaja = false) {
					if (nic==false) {
						odgovor1.text = odg [rand];
						nic=true;
					} else if (ena == false) {
						odgovor2.text = odg [rand];
						ena=true;
					} else if (dva == false) {
						odgovor3.text = odg [rand];
						dva=true;
					}
					if (nic == true && ena == true && dva == true) {
						break;
					}
					obstaja = true;
				}
			}*/
			praviOdg = podatki [2];
			if(odg[0]==praviOdg){
				AnmButton1.image.color = Color.green;
				AnmButton2.image.color = Color.red;
				AnmButton3.image.color = Color.red;
				AnmOdg1Text.text="PRAVILNO";
				AnmOdg2Text.text="NAPAČNO";
				AnmOdg3Text.text="NAPAČNO";
			}else if(odg[1]==praviOdg){
				AnmButton1.image.color = Color.red;
				AnmButton2.image.color = Color.green;
				AnmButton3.image.color = Color.red;
				AnmOdg1Text.text="NAPAČNO";
				AnmOdg2Text.text="PRAVILNO";
				AnmOdg3Text.text="NAPAČNO";
			}else if(odg[2]==praviOdg){
				AnmButton1.image.color = Color.red;
				AnmButton2.image.color = Color.red;
				AnmButton3.image.color = Color.green;
				AnmOdg1Text.text="NAPAČNO";
				AnmOdg2Text.text="NAPAČNO";
				AnmOdg3Text.text="PRAVILNO";
			}
			//SceneManager.LoadScene ("Menu");
		}

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
	}
}
