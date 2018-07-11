using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class MenuElement : MonoBehaviour
{
	public GameObject selection;
	public Graphic graphic;
	public Color selected;
	public Color unselected;
	Canvas canvas;
	CanvasGroup canvasGroup;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.interactable = false;
	}

	public void Activate(bool enable)
	{
		if (canvasGroup.interactable && !enable && EventSystem.current != null)
		{
			selection = EventSystem.current.currentSelectedGameObject;
		}
		canvasGroup.interactable = enable;
		if (enable && EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(selection);
		}
	}

	public void Show(bool show)
	{
		canvas.enabled = show;
	}

	public void Select(bool select)
	{
		graphic.color = select? selected : unselected;
	}
}
