using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
	public Animator transition;
	public GameObject Setting;
	private bool control = true;

	public Slider volumeSlider;

	void Start()
	{
		volumeSlider.value = PlayerPrefs.HasKey("volumeLevel") ? PlayerPrefs.GetFloat("volumeLevel") : 1f;
	}

	public void LoadNextScene()
	{
		if (control)
		{
			StartCoroutine(StartAnimation(1));
			FindObjectOfType<SoundManager>().PlaySound("click");			
		}
	}

	public void Exit()
	{
		FindObjectOfType<SoundManager>().PlaySound("click");
		if (control) Application.Quit();
	}

	public void ShowSettings()
	{
		if (control)
		{
			FindObjectOfType<SoundManager>().PlaySound("click");
			Setting.SetActive(true);
			control = false;
		}
	}

	public void CloseSettings()
	{
		FindObjectOfType<SoundManager>().PlaySound("click");
		Setting.SetActive(false);
		control = true;
	}

	public IEnumerator StartAnimation(int index)
	{
		transition.SetTrigger("Fade");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(index);
	}

	public void setVolume(float vol)
	{
		AudioListener.volume = vol;
		PlayerPrefs.SetFloat ("volumeLevel", AudioListener.volume);
	}
}
