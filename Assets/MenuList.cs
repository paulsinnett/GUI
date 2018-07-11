using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuList : MonoBehaviour 
{
	public List<MenuElement> options = new List<MenuElement>();

	void OnEnable()
	{
		if (options.Count > 0)
		{
			Activate(options[0]);
		}
		else
		{
			DeselectAll();
		}
	}

	void OnDisable()
	{
		DeselectAll();
	}

	void DeselectAll()
	{
		foreach (var option in options)
		{
			Select(option, false);
		}
	}

	void Select(MenuElement element, bool select)
	{
		element.Activate(select);
		element.Select(select);
	}

	public void Activate(MenuElement option)
	{
		DeselectAll();
		Select(option, true);
	}
}
