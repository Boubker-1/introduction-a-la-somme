using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Results : MonoBehaviour
{
    public Animator transition;

	private int hiScore;
	public Text hiScoreString;
    public Text endingMessage;
    private string sound;
	public GameObject Object1;
	public GameObject Object2;
	public GameObject Object3;
	public GameObject Object4;

    IEnumerator Start()
    {
    	hiScore = PlayerPrefs.GetInt("Hi-Score");
        if (hiScore <= 10)
        {
            sound = "loss";
            endingMessage.text = "AWW!! VOUS N'AVEZ PAS CREER UN NOUVEAU NOMBRE D'ADDITIONS!!\nESSAYEZ A NOUVEAU!!";
    	}
        else sound = "win";
        Object1.SetActive(false);
    	Object2.SetActive(false);
    	Object3.SetActive(false);
    	Object4.SetActive(false);
    	yield return new WaitForSeconds(0.5f);
    	Object1.SetActive(true);
    	yield return new WaitForSeconds(1f);
    	Object2.SetActive(true);
        yield return StartCoroutine(CalculateTotalAttempt(hiScoreString, hiScore));
    	yield return new WaitForSeconds(0.5f);
        Object3.SetActive(true);
        FindObjectOfType<SoundManager>().PlaySound(sound);
    	yield return new WaitForSeconds(1f);
    	Object4.SetActive(true);
    }

    public IEnumerator CalculateTotalAttempt(Text attemptString, int attempt)
	{
		float step = attempt / 60f;
		float counting = 0;
		int tempAttempt;
    	float duration = 0.75f;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			counting += step;
			tempAttempt = (int)counting;
			if (tempAttempt <= attempt)
            {
                attemptString.text = tempAttempt.ToString();
                FindObjectOfType<SoundManager>().PlaySound("scorecount");
			}
            yield return new WaitForSeconds(Time.deltaTime / 60f);
		}
		attemptString.text = attempt.ToString();
        FindObjectOfType<SoundManager>().PlaySound("scorecount");
	}

    public void GoToParts()
    {
        EquationControl.score = 0;
        StartCoroutine(StartAnimation(1));
        PartsControl.SceneReloaded3 = true;
    }

    public IEnumerator StartAnimation(int index)
    {
        transition.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
}
