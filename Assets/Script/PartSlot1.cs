using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartSlot1 : MonoBehaviour, IDropHandler
{
	public static bool Full = false;
	public static int CorrectSprite, DraggedSprite;
	public static Image img;
	private Sprite rod1, rod2, rod3, rod4, rod5;

	public void Start()
	{
		img = this.GetComponent<Image>();
		CorrectSprite = GameControl.slot1;
        if (CorrectSprite == 1) {img.sprite = Resources.Load<Sprite>("1-Rod-Place"); img.rectTransform.sizeDelta = new Vector2(50 * 1, 25);}
        if (CorrectSprite == 2) {img.sprite = Resources.Load<Sprite>("2-Rod-Place"); img.rectTransform.sizeDelta = new Vector2(50 * 2, 25);}
        if (CorrectSprite == 3) {img.sprite = Resources.Load<Sprite>("3-Rod-Place"); img.rectTransform.sizeDelta = new Vector2(50 * 3, 25);}
        if (CorrectSprite == 4) {img.sprite = Resources.Load<Sprite>("4-Rod-Place"); img.rectTransform.sizeDelta = new Vector2(50 * 4, 25);}
        if (CorrectSprite == 5) {img.sprite = Resources.Load<Sprite>("5-Rod-Place"); img.rectTransform.sizeDelta = new Vector2(50 * 5, 25);}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			if (CorrectSprite == DraggedSprite)
			{
				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
				Full = true;	
				if (!PartSlot2.Full) FindObjectOfType<SoundManager>().PlaySound("completehalf");
				if (DragDropA1.gotDragged)
				{
					if (!DragDropA1.locked)
					{
						DragDropA1.correctPlace = true;
						DragDropA1.locked = true;
					}
				}
				if (DragDropA2.gotDragged)
				{
					if (!DragDropA2.locked)
					{
						DragDropA2.correctPlace = true;
						DragDropA2.locked = true;				
					}
				}
				if (DragDropA3.gotDragged)
				{
					if (!DragDropA3.locked)
					{
						DragDropA3.correctPlace = true;
						DragDropA3.locked = true;				
					}
				}
				if (DragDropA4.gotDragged)
				{
					if (!DragDropA4.locked)
					{
						DragDropA4.correctPlace = true;
						DragDropA4.locked = true;				
					}
				}
				if (DragDropA5.gotDragged)
				{
					if (!DragDropA5.locked)
					{
						DragDropA5.correctPlace = true;
						DragDropA5.locked = true;				
					}
				}
			}
			else
			{
				if (DragDropA1.gotDragged)
				{
					DragDropA1.correctPlace = false;			
				}				
				if (DragDropA2.gotDragged)
				{
					DragDropA2.correctPlace = false;			
				}				
				if (DragDropA3.gotDragged)
				{
					DragDropA3.correctPlace = false;			
				}				
				if (DragDropA4.gotDragged)
				{
					DragDropA4.correctPlace = false;			
				}				
				if (DragDropA5.gotDragged)
				{
					DragDropA5.correctPlace = false;			
				}				
			}

		}
	}
}
