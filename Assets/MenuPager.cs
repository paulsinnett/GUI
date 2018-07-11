using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPager : MonoBehaviour
{
	public List<MenuElement> pages = new List<MenuElement>();

	void OnEnable()
	{
		if (pages.Count > 0)
		{
			Activate(pages[0]);
		}
		else
		{
			DisablePages();
		}
	}

	void OnDisable()
	{
		DisablePages();
	}

	void DisablePages()
	{
		foreach (var page in pages)
		{
			Enable(page, false);
		}
	}

	void Enable(MenuElement page, bool enable)
	{
		page.Activate(enable);
		page.Show(enable);
	}

	public void Activate(MenuElement page)
	{
		DisablePages();
		Enable(page, true);
	}
}
