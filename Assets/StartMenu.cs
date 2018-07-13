using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public MenuPager pager;
	public MenuElement initialMenuPage;

    void Start()
    {
		pager.Activate(initialMenuPage);
    }
}
