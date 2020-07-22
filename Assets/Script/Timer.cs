using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public static Text time;
	public static float currentTime;
	public static bool pausedGame = true;
	public static bool gameEnded = false;

	public void Start()
	{
		time = GetComponent<Text>();
	}

    public void Update()
    {
    	if (!pausedGame && !gameEnded)
		{
			currentTime -= Time.deltaTime;
	    	if (currentTime >= 0) FramesToSeconds(currentTime, time);
	    	if (Mathf.Round(currentTime) == 0) EquationControl.controlLoss = true;
	    	if (currentTime < -1) gameEnded = true;
		}

		if (gameEnded)
		{
			if (EquationControl.score > PlayerPrefs.GetInt("Hi-Score")) PlayerPrefs.SetInt("Hi-Score", EquationControl.score);
		}
    }

    public static void FramesToSeconds(float frames, Text givenTime)
    {
			string min, sec;
			sec = Mathf.Floor(frames % 60).ToString("00"); 
			min = Mathf.Floor((frames % 3600)/60).ToString("00");
			givenTime.text = min + ":" + sec;
    }
}
