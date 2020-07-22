using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SumCandyControl : MonoBehaviour
{
    public Animator transition;

	public Image candy1Tray1;
	public Image candy2Tray1;
	public Image candy3Tray1;
	public Image candy4Tray1;
	public Image candy5Tray1;

	public Image candy1Tray2;
	public Image candy2Tray2;
	public Image candy3Tray2;
	public Image candy4Tray2;
	public Image candy5Tray2;

    public Image answer1;
    public Image answer2;
    public Image answer3;

    public Image TrayNumber1;
    public Image TrayNumber2;
    public Image TraySum;

    public GameObject Correct;
    public GameObject Incorrect;
    public GameObject Instructions;
    public GameObject Home;

    public GameObject AudioOn;
    public GameObject AudioOff;

    public GameObject OperationMessage;
    public GameObject UnlockingMessage1;
    public GameObject UnlockingMessage2;
    public Text OperationsLeftNumber;

    private Color blank = Color.black;

	public static int[] Tray1 = new int[3];
	public static int[] Tray2 = new int[3];
    public static int[] Sum = new int[3];

    private int[] CandyNumbers = {1, 2, 3, 4, 5, 6};

    private Image[] CandyImages1 = new Image[5];
    private Image[] CandyImages2 = new Image[5];

	public static int numberTray1;
	public static int numberTray2;
    public static int randomPic;
    public static int n0, n1, n2;
    private int[] indexs = new int[3];

    public static bool Correcting = false;
    public static bool correctAnswer;


    void Start()
    {
        blank.a = 0f;

        randomPic = Random.Range(1, 7);

        if (!PartsControl.SceneReloaded2) Instructions.SetActive(true);
        else Instructions.SetActive(false);;

        Shuffle(Tray1); Shuffle(Tray2);

        GenerateChoices(Tray1, Tray2, Sum, indexs);

        numberTray1 = Tray1[0]; numberTray2 = Tray2[0];

        CandyImages1[0] = candy1Tray1;
        CandyImages1[1] = candy2Tray1;
        CandyImages1[2] = candy3Tray1;
        CandyImages1[3] = candy4Tray1;
        CandyImages1[4] = candy5Tray1;

        CandyImages2[0] = candy1Tray2;
        CandyImages2[1] = candy2Tray2;
        CandyImages2[2] = candy3Tray2;
        CandyImages2[3] = candy4Tray2;
        CandyImages2[4] = candy5Tray2;

        ChooseNumber(numberTray1, CandyImages1, randomPic);

        switch(numberTray1)
        {
            case 1:
            CandyImages1[4].rectTransform.sizeDelta = new Vector2(170, 170);
            break;
            case 2:
            CandyImages1[4].rectTransform.sizeDelta = new Vector2(140, 140); CandyImages1[4].rectTransform.anchoredPosition = new Vector2(-140, 85);        
            CandyImages1[3].rectTransform.sizeDelta = new Vector2(140, 140); CandyImages1[3].rectTransform.anchoredPosition = new Vector2(-300, 85);
            break;
            case 3:
            CandyImages1[4].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages1[4].rectTransform.anchoredPosition = new Vector2(-140, 30);        
            CandyImages1[3].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages1[3].rectTransform.anchoredPosition = new Vector2(-300, 30);          
            CandyImages1[2].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages1[2].rectTransform.anchoredPosition = new Vector2(-220, 140);          
            break;
            case 4:
            CandyImages1[4].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages1[4].rectTransform.anchoredPosition = new Vector2(-320, 150);        
            CandyImages1[3].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages1[3].rectTransform.anchoredPosition = new Vector2(-120, 150);
            CandyImages1[2].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages1[2].rectTransform.anchoredPosition = new Vector2(-120, 10);          
            CandyImages1[1].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages1[1].rectTransform.anchoredPosition = new Vector2(-320, 10);          
            break;
            default:
            break;
        }

        ChooseNumber(numberTray2, CandyImages2, randomPic);

        switch(numberTray2)
        {
            case 1:
            CandyImages2[4].rectTransform.sizeDelta = new Vector2(170, 170);
            break;
            case 2:
            CandyImages2[4].rectTransform.sizeDelta = new Vector2(140, 140); CandyImages2[4].rectTransform.anchoredPosition = new Vector2(140, 85);        
            CandyImages2[3].rectTransform.sizeDelta = new Vector2(140, 140); CandyImages2[3].rectTransform.anchoredPosition = new Vector2(300, 85);
            break;
            case 3:
            CandyImages2[4].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages2[4].rectTransform.anchoredPosition = new Vector2(140, 30);        
            CandyImages2[3].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages2[3].rectTransform.anchoredPosition = new Vector2(300, 30);          
            CandyImages2[2].rectTransform.sizeDelta = new Vector2(110, 110); CandyImages2[2].rectTransform.anchoredPosition = new Vector2(220, 140);          
            break;
            case 4:
            CandyImages2[4].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages2[4].rectTransform.anchoredPosition = new Vector2(320, 150);        
            CandyImages2[3].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages2[3].rectTransform.anchoredPosition = new Vector2(120, 150);
            CandyImages2[2].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages2[2].rectTransform.anchoredPosition = new Vector2(120, 10);          
            CandyImages2[1].rectTransform.sizeDelta = new Vector2(80, 80); CandyImages2[1].rectTransform.anchoredPosition = new Vector2(320, 10);          
            break;
            default:
            break;
        }

        n0 = Sum[indexs[0]];
        n1 = Sum[indexs[1]];
        n2 = Sum[indexs[2]];

        ChooseNumberAnswer(answer1, n0); 
        ChooseNumberAnswer(answer2, n1); 
        ChooseNumberAnswer(answer3, n2);

        ChooseNumberAnswer(TrayNumber1, numberTray1); 
        ChooseNumberAnswer(TrayNumber2, numberTray2); 
        ChooseNumberAnswer(TraySum, numberTray1 + numberTray2);
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

    // Update is called once per frame
    void Update()
    {
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

    private void ChooseNumber(int num, Image[] img, int imgNum)
    {
        for (int i = 0; i < img.Length - num; i++)
        {
            img[i].color = blank;
        }

        for (int i = img.Length - num; i < img.Length; i++)
        {
            ChooseCandy(img[i], imgNum);
        }
    }

    public void CloseIncorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Incorrect.SetActive(false);
    }

    public void CloseCorrect()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Correct.SetActive(false);
    }

    public void CloseInstruction()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Instructions.SetActive(false);
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
        StartCoroutine(StartAnimation(0));
    }

    public void ShowHelp()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        Instructions.SetActive(true);
    }

    public void NextMessage()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        OperationMessage.SetActive(false);
        if (PartsControl.OperationsLeft > 1)
        {
            UnlockingMessage1.SetActive(true);
            PartsControl.OperationsLeft--;
            OperationsLeftNumber.text = PartsControl.OperationsLeft.ToString();           
        }
        else
        {
            PartsControl.locked2 = false;
            PartsControl.locked3 = false;
            UnlockingMessage2.SetActive(true);
        }       
    }

    public void ReloadScene()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        PartsControl.SceneReloaded2 = true;
        StartCoroutine(StartAnimation(SceneManager.GetActiveScene().buildIndex));
    }

    public void GoToParts()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
        StartCoroutine(StartAnimation(1));
    }

    private void ChooseCandy(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>("Candy" + index.ToString());// img.rectTransform.sizeDelta = new Vector2(40 * index, 20);
    }

    private void ChooseNumberAnswer(Image img, int index)
    {
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToString());
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
