using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuTrail : MonoBehaviour 
{
	public List<MenuElement> steps;

	void OnEnable()
	{
		if (steps.Count > 0)
		{
			Activate(steps[0]);
		}
		else
		{
			DisableSteps();
			HideSteps();
		}
	}

	void OnDisable()
	{
		DisableSteps();
		HideSteps();
	}

	void HideSteps()
	{
		foreach (var step in steps)
		{
			step.Show(false);
		}
	}

	void DisableSteps()
	{
		foreach (var step in steps)
		{
			step.Activate(false);
		}
	}

	void ShowToStep(MenuElement current)
	{
		bool show = true;
		foreach (var step in steps)
		{
			step.Show(show);
			if (step == current)
			{
				show = false;
			}
		}
	}

	public void Activate(MenuElement step)
	{
		DisableSteps();
		ShowToStep(step);
		step.Activate(true);
	}
}
