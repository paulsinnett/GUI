using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class MenuPage : MonoBehaviour
{
	public GameObject selection;
	Canvas canvas;
	CanvasGroup canvasGroup;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.interactable = false;
	}

	void Enable(bool enable)
	{
		if (!enable && EventSystem.current != null)
		{
			selection = EventSystem.current.currentSelectedGameObject;
		}
		canvas.enabled = enable;
		canvasGroup.interactable = enable;
		if (enable)
		{
			EventSystem.current.SetSelectedGameObject(selection);
		}
	}

	void OnEnable()
	{
		Enable(true);
	}

	void OnDisable()
	{
		Enable(false);
	}
}
