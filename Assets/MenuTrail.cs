using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MenuElement))]
public class MenuTrail : MonoBehaviour 
{
	public List<MenuElement> steps;
	MenuElement element;

	void Awake()
	{
		element = GetComponent<MenuElement>();
	}

	void Start()
	{
		element.onActivateElement.AddListener(() => StartTrail());
	}

	void StartTrail()
	{
		MenuElement firstPage = null;
		if (steps.Count > 0)
		{
			firstPage = steps[0];
		}
		Activate(firstPage);
	}

	void HideSteps()
	{
		foreach (var step in steps)
		{
			step.ActivateElement(ActivateMessage.Hide());
		}
	}

	void ShowToStep(MenuElement current)
	{
		bool show = true;
		foreach (var step in steps)
		{
			step.ActivateElement(show? ActivateMessage.ShowTrail() : ActivateMessage.Hide());
			if (step == current)
			{
				show = false;
			}
		}
	}

	public void Activate(MenuElement step)
	{
		ShowToStep(step);
		step.ActivateElement(ActivateMessage.Activate());
	}
}
