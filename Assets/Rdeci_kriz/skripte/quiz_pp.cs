using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

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
    private Text vprasanje_text;
    [SerializeField]
    private Text odgovori_text;
    [SerializeField]
    private Text odgovori_text2;
    [SerializeField]
    private Text odgovori_text3;
    [SerializeField]
    private Text pravilni_odgovor;

    [SerializeField]
    private float TimeBetweenQuestions = 1.0f;

    // Use this for initialization
    void Start()
    {

        if (neodgovorjeno == null || neodgovorjeno.Count == 0)
        {
            neodgovorjeno = vprasanje.ToList<Question_>();

        }

        SetCurrentQuestion();
        SetCurrentAnswer();
        SetCurrentAnswer2();
        SetCurrentAnswer3();

    }


    void SetCurrentQuestion()
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

    void SetCurrentAnswer()
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
        neodgovorjeno.Remove(current_question);

        yield return new WaitForSeconds(TimeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void pravilini() {

        string od1 = current_question.odgovor1.ToString();

		animator.SetTrigger ("Odg1");
        if (current_question.odgovor1.ToString() == current_question.pravilniodgovor.ToString())
        {
            Debug.Log("CORRECT!");
        }
        else
        {
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionTonextQuestion());

    }

    public void pravilni2() {
		animator.SetTrigger ("Odg2");
        if (current_question.odgovor2.ToString() == current_question.pravilniodgovor.ToString())
        {
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionTonextQuestion());
    }

    public void pravilni3()
	{
		animator.SetTrigger ("Odg3");
        if (current_question.odgovor3.ToString() == current_question.pravilniodgovor.ToString())
        {
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionTonextQuestion());
    }
    



    public void userSelectFirst()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
