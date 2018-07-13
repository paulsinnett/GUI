using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPager : MonoBehaviour
{
	public List<MenuElement> pages = new List<MenuElement>();

	void DisablePages()
	{
		foreach (var page in pages)
		{
			Enable(page, false);
		}
	}

	void Enable(MenuElement page, bool enable)
	{
		page.ActivateElement(enable? ActivateMessage.Activate() : ActivateMessage.Hide());
	}

	public void Activate(MenuElement page)
	{
		DisablePages();
		Enable(page, true);
	}
}
