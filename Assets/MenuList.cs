using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MenuElement))]
public class MenuList : MonoBehaviour 
{
	public List<MenuElement> options = new List<MenuElement>();
	MenuElement menuElement;

	void Awake()
	{
		menuElement = GetComponent<MenuElement>();
	}

	void Start()
	{
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
		element.SendMessage("ActivateElement", select? ActivateMessage.Highlight() : ActivateMessage.ShowTrail());
	}

	public void ActivateElement(ActivateMessage message)
	{
		if (message.show)
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
		else
		{
			DeselectAll();
		}
	}

	public void Activate(MenuElement option)
	{
		DeselectAll();
		Select(option, true);
	}
}
