using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public Animator transition;

	private bool animating = false;

	public GameObject BigTray1;
	public GameObject BigTray2;

	public GameObject Instruction1;
	public GameObject Instruction2;
    public GameObject Home;
    public GameObject rod1;
    public GameObject rod2;
    public GameObject rod3;
    public GameObject rod4;
    public GameObject rod5;

    public GameObject rod1alt;
    public GameObject rod2alt;
    public GameObject rod3alt;
    public GameObject rod4alt;
    public GameObject rod5alt;

    public GameObject tray1;
    public GameObject tray2;

    public GameObject RodPlace1;
    public GameObject RodPlace2;

    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;

    public GameObject Correct;
    public GameObject Incorrect;

    public GameObject SlideText;
    public GameObject Options;
    public GameObject BoardName1;
    public GameObject BoardName2;

    public GameObject EqautionMessage;
    public GameObject UnlockingMessage1;
    public GameObject UnlockingMessage2;
    public Text EquationsLeftNumber;

    public GameObject AudioOn;
    public GameObject AudioOff;

    public Image Rod11;
    public Image Rod12;
    public Image Rod21;
    public Image Rod22;
    public Image Rod31;
    public Image Rod32;

    public Image Rod1C;
    public Image Rod2C;
    public Image RodSumC1;
    public Image RodSumC2;

    public Image Num1C;
    public Image Num2C;
    public Image NumSumC;

    public Image Sum1;
    public Image Sum2;
    public Image Sum3;

    private bool inst2Shown = false;
    private bool waiting = false;
    private int[] Slot1 = new int[3];
    private int[] Slot2 = new int[3];
    private int[] Sum = new int[3];
    private int[] indexs = new int[3];
    private int index1, index2;
    private int num0, num1, num2;
    public static int n0, n1, n2;
    public static bool correctAnswer;
    public static bool Correcting = false;
    public static int slot1, slot2;

    private GameObject[] Rods = new GameObject[5];
    private GameObject[] RodsAlt = new GameObject[5];
    private GameObject[] RodPlaces = new GameObject[2];
    private Image[] images = new Image[6];
    private Image[] imagesSum = new Image[3];

    void Start()
    {   

    	SlideText.SetActive(false);
    	BigTray1.SetActive(false);
    	BigTray2.SetActive(false);
    	
    	if (!PartsControl.SceneReloaded1) Instruction1.SetActive(true);
    	CloseInstruction1();
    	Instruction2.SetActive(false);

        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);

        Rods[0] = rod1; RodsAlt[0] = rod1alt;
        Rods[1] = rod2; RodsAlt[1] = rod2alt;
        Rods[2] = rod3; RodsAlt[2] = rod3alt;
        Rods[3] = rod4; RodsAlt[3] = rod4alt;
        Rods[4] = rod5; RodsAlt[4] = rod5alt;

        images[0] = Rod11;
        images[1] = Rod12;
        images[2] = Rod21;
        images[3] = Rod22;
        images[4] = Rod31;
        images[5] = Rod32;

        imagesSum[0] = Sum1;
        imagesSum[1] = Sum2;
        imagesSum[2] = Sum3;

        GenerateChoices(Slot1, Slot2, Sum, indexs);

        ChooseAnswers(Rod1C, Slot1[0]); ChooseNumber(Num1C, Slot1[0]);
        ChooseAnswersAlt(Rod2C, Slot2[0]); ChooseNumber(Num2C, Slot2[0]);

        ChooseAnswers(RodSumC1, Slot1[0]);
        ChooseAnswersAlt(RodSumC2, Slot2[0]);
        ChooseNumber(NumSumC, Sum[0]);

        ChooseAnswers(images[0], Slot1[indexs[0]]); ChooseAnswersAlt(images[1], Slot2[indexs[0]]); ChooseNumber(imagesSum[0], Sum[indexs[0]]); //Sum1.text = (Slot1[indexs[0]] + Slot2[indexs[0]]).ToString();
        ChooseAnswers(images[2], Slot1[indexs[1]]); ChooseAnswersAlt(images[3], Slot2[indexs[1]]); ChooseNumber(imagesSum[1], Sum[indexs[1]]); //Sum2.text = (Slot1[indexs[1]] + Slot2[indexs[1]]).ToString();
        ChooseAnswers(images[4], Slot1[indexs[2]]); ChooseAnswersAlt(images[5], Slot2[indexs[2]]); ChooseNumber(imagesSum[2], Sum[indexs[2]]); //Sum3.text = (Slot1[indexs[2]] + Slot2[indexs[2]]).ToString();
        
        n0 = Sum[indexs[0]];
        n1 = Sum[indexs[1]];
        n2 = Sum[indexs[2]];

        slot1 = Slot1[0]; slot2 = Slot2[0];

        RodPlaces[0] = RodPlace1;
        RodPlaces[1] = RodPlace2;
        Reset();
    }

    void Update()
    {
        if (PartSlot1.Full && PartSlot2.Full && !inst2Shown)
        {
            FindObjectOfType<SoundManager>().PlaySound("success3");
            if (!waiting) StartCoroutine(Wait());
            SlideText.SetActive(false);
            BoardName1.SetActive(false);
            Instruction2.SetActive(true);
            inst2Shown = true;
        }

        if (Correcting)
        {
            if (correctAnswer)
            {
                FindObjectOfType<SoundManager>().PlaySound("correctanswer");
                Correct.SetActive(true);
            }
            else
            {
                FindObjectOfType<SoundManager>().PlaySound("incorrectanswer");
                Incorrect.SetActive(true);                
            } 
            Correcting = false;          
        }
    }

    public void GenerateChoices(int[] Ops1, int[] Ops2, int[] SumOps, int[] index)
    {
    	Ops1[0] = Random.Range(1, 6);
    	Ops2[0] = Random.Range(1, 6);
        SumOps[0] = Ops1[0] + Ops2[0];

		Ops1[1] = Random.Range(1, 6);
		Ops2[1] = Random.Range(1, 6);
		while(Ops1[1] + Ops2[1] == SumOps[0])
		{
			Ops1[1] = Random.Range(1, 6);
			Ops2[1] = Random.Range(1, 6);
		}

		SumOps[1] = Ops1[1] + Ops2[1];

		Ops1[2] = Random.Range(1, 6);
		Ops2[2] = Random.Range(1, 6);

		while(Ops1[2] + Ops2[2] == SumOps[0] || Ops1[2] + Ops2[2] == SumOps[1])
		{
			Ops1[2] = Random.Range(1, 6);
			Ops2[2] = Random.Range(1, 6);
		} 

		SumOps[2] = Ops1[2] + Ops2[2];

		index[0] = 0; index[1] = 1; index[2] = 2;
        Shuffle(index);
    }

    public void CloseInstruction1()
    {
    	Close(0);
    }

    public void CloseInstruction2()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Close(1);
    }

    public void ShowHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Instruction1.SetActive(true);
    }

    public void CloseHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Instruction1.SetActive(false);
    }

    public void ShowHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Home.SetActive(true);
    }

    public void CloseHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Home.SetActive(false);
    }

    public void GoHome()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Reset();
        StartCoroutine(StartAnimation(0));
    }

    public void Close(int buttonID)
    {
    	if (buttonID == 0)
    	{
	    	BigTray1.SetActive(true);
	    	BigTray2.SetActive(true);
	    	SlideText.SetActive(true);
            Options.SetActive(true);
   		}

    	if (buttonID == 1)
    	{
	    	Instruction2.SetActive(false);

	        for (int i = 0; i < 5; i++)
	        {
	            tray1.SetActive(false);
	            if (i+1 != Slot1[0])
	            {
	            	Rods[i].SetActive(false);
	            } 
	            else
	            {
	                Rods[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Rods[i].GetComponent<RectTransform>().anchoredPosition.y);
	            }

	            if (i+1 != Slot2[0])
	            {
	            	RodsAlt[i].SetActive(false);
	            } 
	            else
	            {
	                RodsAlt[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, RodsAlt[i].GetComponent<RectTransform>().anchoredPosition.y);
	            }
	        }

	        RodPlaces[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, RodPlaces[0].GetComponent<RectTransform>().anchoredPosition.y);
	        RodPlaces[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, RodPlaces[1].GetComponent<RectTransform>().anchoredPosition.y);

	        tray2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, tray2.GetComponent<RectTransform>().anchoredPosition.y);
	        BoardName2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-270, 70);
            Options.GetComponent<RectTransform>().anchoredPosition = new Vector2(Options.GetComponent<RectTransform>().anchoredPosition.x, 120);

	        answer1.SetActive(true);
	        answer2.SetActive(true);
	        answer3.SetActive(true);    		
    	}
    }

    public void CloseIncorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Incorrect.SetActive(false);
    }

    public void NextMessage()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
	    EqautionMessage.SetActive(false);
		if (PartsControl.EquationsLeft > 1)
		{
	    	UnlockingMessage1.SetActive(true);
	    	PartsControl.EquationsLeft--;
	    	EquationsLeftNumber.text = PartsControl.EquationsLeft.ToString();			
		}
		else
		{
			PartsControl.locked2 = false;
			UnlockingMessage2.SetActive(true);
		}    	
    }

    public void CloseCorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Correct.SetActive(false);
    }

    public void ReloadScene()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Reset();
    	PartsControl.SceneReloaded1 = true;
    	StartCoroutine(StartAnimation(SceneManager.GetActiveScene().buildIndex));
    }

    public void GoToParts()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	StartCoroutine(StartAnimation(1));
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

    public void ShuffleGameObjects(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            GameObject temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }

    private IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(1f);
        waiting = false;
    }

    private void ChooseAnswers(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToString() + "-Rod"); img.rectTransform.sizeDelta = new Vector2(40 * index, 20);
    }

    private void ChooseAnswersAlt(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToString() + "-Rod-Alt"); img.rectTransform.sizeDelta = new Vector2(40 * index, 20);
    }

    private void ChooseNumber(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToString());
    }

    public void Reset()
    {
        PartSlot1.Full = false;
        PartSlot2.Full = false;
        DragDropA1.locked = false; DragDropA1.rectTransform.anchoredPosition = DragDropA1.originalPosition1; DragDropA1.gotDragged = false; DragDropA1.correctPlace = false; DragDropA1.canvasGroup.blocksRaycasts = true; 
        DragDropA2.locked = false; DragDropA2.rectTransform.anchoredPosition = DragDropA2.originalPosition1; DragDropA2.gotDragged = false; DragDropA2.correctPlace = false; DragDropA2.canvasGroup.blocksRaycasts = true; 
        DragDropA3.locked = false; DragDropA3.rectTransform.anchoredPosition = DragDropA3.originalPosition1; DragDropA3.gotDragged = false; DragDropA3.correctPlace = false; DragDropA3.canvasGroup.blocksRaycasts = true;
        DragDropA4.locked = false; DragDropA4.rectTransform.anchoredPosition = DragDropA4.originalPosition1; DragDropA4.gotDragged = false; DragDropA4.correctPlace = false; DragDropA4.canvasGroup.blocksRaycasts = true; 
        DragDropA5.locked = false; DragDropA5.rectTransform.anchoredPosition = DragDropA5.originalPosition1; DragDropA5.gotDragged = false; DragDropA5.correctPlace = false; DragDropA5.canvasGroup.blocksRaycasts = true;
        DragDropB1.locked = false; DragDropB1.rectTransform.anchoredPosition = DragDropB1.originalPosition1; DragDropB1.gotDragged = false; DragDropB1.correctPlace = false; DragDropB1.canvasGroup.blocksRaycasts = true; 
        DragDropB2.locked = false; DragDropB2.rectTransform.anchoredPosition = DragDropB2.originalPosition1; DragDropB2.gotDragged = false; DragDropB2.correctPlace = false; DragDropB2.canvasGroup.blocksRaycasts = true; 
        DragDropB3.locked = false; DragDropB3.rectTransform.anchoredPosition = DragDropB3.originalPosition1; DragDropB3.gotDragged = false; DragDropB3.correctPlace = false; DragDropB3.canvasGroup.blocksRaycasts = true;
        DragDropB4.locked = false; DragDropB4.rectTransform.anchoredPosition = DragDropB4.originalPosition1; DragDropB4.gotDragged = false; DragDropB4.correctPlace = false; DragDropB4.canvasGroup.blocksRaycasts = true; 
        DragDropB5.locked = false; DragDropB5.rectTransform.anchoredPosition = DragDropB5.originalPosition1; DragDropB5.gotDragged = false; DragDropB5.correctPlace = false; DragDropB5.canvasGroup.blocksRaycasts = true;
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
