using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EquationControl : MonoBehaviour
{
    public Animator transition;

	public int[] Choices1 = new int[3];
	public int[] Choices2 = new int[3];
	public int[] Choices3 = new int[3];

	public static int n0, n1, n2, n3, n4, n5, n6, n7, n8;

	public static int[] CorrectInts = new int[3];

	public static bool verified1 = false;
	public static bool verified2 = false;
	public static bool verified3 = false;
    public static bool controlLoss;

	public Image Op1, Op2, Op3, Op4, Op5, Op6;
	public Image An1, An2, An3, An4, An5, An6, An7, An8, An9;

	private bool reset = false;
	public GameObject Continue;
	public GameObject Good1;
	public GameObject Good2;
	public GameObject Good3;
	public GameObject Instructions;
    public GameObject HandGesture;
    public GameObject Home;
    private bool playing = false;

    public GameObject AudioOn;
    public GameObject AudioOff;

	public static int score = 0;
	public Text textScore;
	public Text textScoreWord;
	public Text textHiScore;

    public void Start()
    {
        Timer.gameEnded = false;
        Timer.currentTime = 121f;
        controlLoss = false;
    	Initialization();
        if (!PartsControl.SceneReloaded3) Instructions.SetActive(true);
        else Instructions.SetActive(false);
    }

    public void Update()
    {
    	PlayerPrefs.SetInt("Hi-Score", 10);
    	if (verified1 && verified2 && verified3)
    	{
    		if (!Timer.gameEnded) Continue.SetActive(true);
    	}

    	textScore.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Hi-Score")) PlayerPrefs.SetInt("Hi-Score", score);
    	textHiScore.text = PlayerPrefs.GetInt("Hi-Score").ToString();
        if (Timer.currentTime <= 0)
        {
            if (!playing)
            {
                playing = true;
                FindObjectOfType<SoundManager>().PlaySound("timeup");
            }
            textScoreWord.text = "TERMINÉ!";
        }
    	if (Timer.gameEnded)
        {
            StartCoroutine(StartAnimation(SceneManager.GetActiveScene().buildIndex+1));
        }
    }

    public void Initialization()
    {
        GenerateEquation(Random.Range(1, 6), Random.Range(1, 6), Choices1, 0, Op1, Op2);
        n0 = Choices1[0]; n1 = Choices1[1]; n2 = Choices1[2];
        ChooseNumberAnswer(An1, n0); ChooseNumberAnswer(An2, n1); ChooseNumberAnswer(An3, n2);

    	GenerateEquation(Random.Range(1, 6), Random.Range(1, 6), Choices2, 1, Op3, Op4);
        n3 = Choices2[0]; n4 = Choices2[1]; n5 = Choices2[2];
        ChooseNumberAnswer(An4, n3); ChooseNumberAnswer(An5, n4); ChooseNumberAnswer(An6, n5);

    	GenerateEquation(Random.Range(1, 6), Random.Range(1, 6), Choices3, 2, Op5, Op6);
        n6 = Choices3[0]; n7 = Choices3[1]; n8 = Choices3[2];
        ChooseNumberAnswer(An7, n6); ChooseNumberAnswer(An8, n7); ChooseNumberAnswer(An9, n8);
    }

    public void GenerateEquation(int Ops1, int Ops2, int[] SumOps, int index, Image Opr1, Image Opr2)
    {
        SumOps[0] = Ops1 + Ops2;

        CorrectInts[index] = SumOps[0];

		ChooseNumberAnswer(Opr1, Ops1);        
		ChooseNumberAnswer(Opr2, Ops2);

		SumOps[1] = Random.Range(2, 10);
		while(SumOps[1] == SumOps[0]) SumOps[1] = Random.Range(2, 10);

		SumOps[2] = Random.Range(2, 10);
		while(SumOps[2] == SumOps[0] || SumOps[2] == SumOps[1]) SumOps[2] = Random.Range(2, 10);

        Shuffle(SumOps);
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }

    private void ChooseNumberAnswer(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToString());
    }

    private IEnumerator Wait()
    {
    	yield return new WaitForSeconds(0.75f);
    }

    public void RestartGame()
    {
    	Good1.SetActive(false);
    	Good2.SetActive(false);
    	Good3.SetActive(false);
    	Continue.SetActive(false);
    	Initialization();
    	verified1 = false;
    	verified2 = false;
    	verified3 = false;
    }

    public void ShowHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("idea");
        HandGesture.SetActive(true);
        Timer.pausedGame = true;
    }

    public void CloseHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        HandGesture.SetActive(false);
        Timer.pausedGame = false;
    }

    public void CloseInstructions()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Instructions.SetActive(false);
    	Timer.pausedGame = false;
    }

    public void ShowHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Home.SetActive(true);
        Timer.pausedGame = true;
    }

    public void CloseHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Home.SetActive(false);
        Timer.pausedGame = false;
    }

    public void GoHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        score = 0;
        StartCoroutine(StartAnimation(0));
    }

    public IEnumerator StartAnimation(int index)
    {
        transition.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

    public void PauseAudio()
    {
        AudioListener.pause = true;
        AudioOn.SetActive(false);
        AudioOff.SetActive(true);
    }

    public void PlayAudio()
    {
        AudioListener.pause = false;
        AudioOff.SetActive(false);
        AudioOn.SetActive(true);
    }
}
