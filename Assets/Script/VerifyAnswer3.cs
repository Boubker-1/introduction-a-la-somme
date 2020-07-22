using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyAnswer3 : MonoBehaviour
{

	public GameObject Good1, Good2, Good3, Bad1, Bad2, Bad3;

	public void Verify()
	{
		GameControl.Correcting = true;
		if (GameControl.n2 == GameControl.slot1 + GameControl.slot2) GameControl.correctAnswer = true;
		else GameControl.correctAnswer = false;
	}

	public void Verify2()
	{
		SumCandyControl.Correcting = true;
		if (SumCandyControl.n2 == SumCandyControl.numberTray1 + SumCandyControl.numberTray2) SumCandyControl.correctAnswer = true;
		else SumCandyControl.correctAnswer = false;
	}

	public void Verify1E()
	{
		if (!Timer.gameEnded && !EquationControl.verified1 && !EquationControl.controlLoss)
		{
			if (EquationControl.n2 == EquationControl.CorrectInts[0])
			{
				Bad1.SetActive(false);
				Good1.SetActive(true);
				FindObjectOfType<SoundManager>().PlaySound("success3");
				EquationControl.score++;
				EquationControl.verified1 = true;
			}
			else 
			{
				FindObjectOfType<SoundManager>().PlaySound("incorrectanswer");
				Bad1.SetActive(true);
			}			
		}
	}

	public void Verify2E()
	{
		if (!Timer.gameEnded && !EquationControl.verified2 && !EquationControl.controlLoss)
		{
			if (EquationControl.n5 == EquationControl.CorrectInts[1])
			{
				Bad2.SetActive(false);
				Good2.SetActive(true);
				FindObjectOfType<SoundManager>().PlaySound("success3");
				EquationControl.score++;
				EquationControl.verified2 = true;
			}
			else 
			{
				FindObjectOfType<SoundManager>().PlaySound("incorrectanswer");
				Bad2.SetActive(true);
			}
		}
	}

	public void Verify3E()
	{
		if (!Timer.gameEnded && !EquationControl.verified3 && !EquationControl.controlLoss)
		{
			if (EquationControl.n8 == EquationControl.CorrectInts[2])
			{
				Bad3.SetActive(false);
				Good3.SetActive(true);
				FindObjectOfType<SoundManager>().PlaySound("success3");
				EquationControl.score++;
				EquationControl.verified3 = true;
			}
			else 
			{
				FindObjectOfType<SoundManager>().PlaySound("incorrectanswer");
				Bad3.SetActive(true);
			}
		}
	}
}
