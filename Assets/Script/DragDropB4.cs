using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropB4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	[SerializeField] private Canvas canvas;

	public static CanvasGroup canvasGroup;
	public static RectTransform rectTransform;
	public static bool gotDragged;
	public static bool correctPlace;
	public static bool locked = false;
	public static Vector2 originalPosition1;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		originalPosition1 = rectTransform.anchoredPosition;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!locked)
		{
			canvasGroup.alpha = .5f;
			canvasGroup.blocksRaycasts = false;
			gotDragged = true;	
			PartSlot2.DraggedSprite = 4;	
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!locked)
		{
			rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!locked)
		{
			canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;
			if (!correctPlace)
			{
				FindObjectOfType<SoundManager>().PlaySound("backtoplace");
				rectTransform.anchoredPosition = originalPosition1;
				gotDragged = false;
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!locked)
		{
			FindObjectOfType<SoundManager>().PlaySound("click2");
			canvasGroup.alpha = .5f;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!locked)
		{
			canvasGroup.alpha = 1f;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (!locked)
		{
			throw new System.NotImplementedException();
		}
	}
}
