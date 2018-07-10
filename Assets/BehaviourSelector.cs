using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BehaviourSelector : MonoBehaviour
{
	public List<Behaviour> pages = new List<Behaviour>();

	void OnEnable()
	{
		if (pages.Count > 0)
		{
			ActivatePage(pages[0]);
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
			page.enabled = false;
		}
	}

	public void ActivatePage(Behaviour page)
	{
		DisablePages();
		page.enabled = true;
	}
}
