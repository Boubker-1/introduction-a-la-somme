using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartsControl : MonoBehaviour
{
    public Animator transition;

	public static bool locked2 = true, locked3 = true;
    public static bool SceneReloaded1 = false, SceneReloaded2 = false, SceneReloaded3 = false;
    public static int EquationsLeft = 5, OperationsLeft = 5;
	public GameObject Unlock2Text, Unlock3Text;
	public GameObject Lock2, Lock3;
	public GameObject PartImage2, PartImage3;
	public GameObject Instructions, SubElements;

	private bool animating = false;

    void Start()
    {
        SubElements.SetActive(false);
    	if (!locked2 || !locked3)
        {
            Instructions.SetActive(false);
            Close(0);
        }
        else Instructions.SetActive(true); 
        if (!locked2) Lock2.SetActive(false); else {Lock2.SetActive(true); PartImage2.GetComponent<CanvasGroup>().alpha = 0.5f;}
        if (!locked3) Lock3.SetActive(false); else {Lock3.SetActive(true); PartImage3.GetComponent<CanvasGroup>().alpha = 0.5f;}
    }

    public void LoadPart1()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	StartCoroutine(StartAnimation(2));
    }

    public void LoadPart2()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	if (!locked2) StartCoroutine(StartAnimation(3));
    	else
    	{
    		Unlock3Text.SetActive(false);
    		Unlock2Text.SetActive(true);
    	}
    }

    public void LoadPart3()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	if (!locked3) StartCoroutine(StartAnimation(4));
    	else
    	{
    		Unlock2Text.SetActive(false);
    		Unlock3Text.SetActive(true);
    	}
    }

    public void CloseInstructions()
    {
        FindObjectOfType<SoundManager>().PlaySound("click");
    	Close(0);
    }

    public void Close(int buttonID)
    {
    	if (buttonID == 0)
    	{
	    	Instructions.SetActive(false);    		
	    	SubElements.SetActive(true);
       	}
    }

    public IEnumerator StartAnimation(int index)
    {
        transition.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

/*    public IEnumerator DisplayText(GameObject text)
    {
    	if (!animating) yield return StartCoroutine(FadeInOut(text, 0.5f));
    }

    private IEnumerator FadeInOut(GameObject obj, float duration)
    {
    	animating = true;
    	CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
    	float start = canvasGroup.alpha;
    	float end = (canvasGroup.alpha == 1) ? 0 : 1;
    	for (float t = 0; t < duration; t += Time.deltaTime)
    	{
    		canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
    		yield return null;
    	}
    	canvasGroup.alpha = end;
    	animating = false;
    }
*/
}
