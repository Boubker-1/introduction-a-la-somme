using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartSlot2 : MonoBehaviour, IDropHandler
{
	public static bool Full = false;
	public static int CorrectSprite, DraggedSprite;
	public static Image img;
	private Sprite rod1, rod2, rod3, rod4, rod5;

	public void Start()
	{
		img = this.GetComponent<Image>();
		CorrectSprite = GameControl.slot2;
        if (CorrectSprite == 1) {img.sprite = Resources.Load<Sprite>("1-Rod-Place-Alt"); img.rectTransform.sizeDelta = new Vector2(50 * 1, 25);}
        if (CorrectSprite == 2) {img.sprite = Resources.Load<Sprite>("2-Rod-Place-Alt"); img.rectTransform.sizeDelta = new Vector2(50 * 2, 25);}
        if (CorrectSprite == 3) {img.sprite = Resources.Load<Sprite>("3-Rod-Place-Alt"); img.rectTransform.sizeDelta = new Vector2(50 * 3, 25);}
        if (CorrectSprite == 4) {img.sprite = Resources.Load<Sprite>("4-Rod-Place-Alt"); img.rectTransform.sizeDelta = new Vector2(50 * 4, 25);}
        if (CorrectSprite == 5) {img.sprite = Resources.Load<Sprite>("5-Rod-Place-Alt"); img.rectTransform.sizeDelta = new Vector2(50 * 5, 25);}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			if (CorrectSprite == DraggedSprite)
			{
				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
				Full = true;	
				if (!PartSlot1.Full) FindObjectOfType<SoundManager>().PlaySound("completehalf");
				if (DragDropB1.gotDragged)
				{
					if (!DragDropB1.locked)
					{
						DragDropB1.correctPlace = true;
						DragDropB1.locked = true;
					}
				}
				if (DragDropB2.gotDragged)
				{
					if (!DragDropB2.locked)
					{
						DragDropB2.correctPlace = true;
						DragDropB2.locked = true;				
					}
				}
				if (DragDropB3.gotDragged)
				{
					if (!DragDropB3.locked)
					{
						DragDropB3.correctPlace = true;
						DragDropB3.locked = true;				
					}
				}
				if (DragDropB4.gotDragged)
				{
					if (!DragDropB4.locked)
					{
						DragDropB4.correctPlace = true;
						DragDropB4.locked = true;				
					}
				}
				if (DragDropB5.gotDragged)
				{
					if (!DragDropB5.locked)
					{
						DragDropB5.correctPlace = true;
						DragDropB5.locked = true;				
					}
				}
			}
			else
			{
				if (DragDropB1.gotDragged)
				{
					DragDropB1.correctPlace = false;
				}				
				if (DragDropB2.gotDragged)
				{
					DragDropB2.correctPlace = false;
				}				
				if (DragDropB3.gotDragged)
				{
					DragDropB3.correctPlace = false;
				}				
				if (DragDropB4.gotDragged)
				{
					DragDropB4.correctPlace = false;
				}				
				if (DragDropB5.gotDragged)
				{
					DragDropB5.correctPlace = false;
				}				
			}

		}
	}
}
