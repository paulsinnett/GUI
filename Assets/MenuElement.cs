using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class MenuElement : MonoBehaviour
{
	public class ActivateElementEvent: UnityEvent<ActivateMessage> {}
	public GameObject selection;
	public Graphic graphic;
	public Color selected;
	public Color unselected;
	public UnityEvent onActivateElement;
	
	Canvas canvas;
	CanvasGroup canvasGroup;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.interactable = false;
	}

	void Interact(bool enable)
	{
		if (canvasGroup.interactable && !enable && EventSystem.current != null)
		{
			selection = EventSystem.current.currentSelectedGameObject;
		}
		canvasGroup.interactable = enable;
		if (enable && EventSystem.current != null)
		{
			Debug.Log("Enable");
			EventSystem.current.SetSelectedGameObject(selection);
		}
	}

	void Show(bool show)
	{
		Debug.Log("Show");
		canvas.enabled = show;
	}

	void Highlight(bool highlight)
	{
		if (graphic != null)
		{
			graphic.color = highlight? selected : unselected;
		}
	}

	public void ActivateElement(ActivateMessage message)
	{
		Show(message.show);
		Interact(message.interact);
		Highlight(message.highlight);
		onActivateElement.Invoke();
	}
}
