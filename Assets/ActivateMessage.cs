using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMessage
{
    public bool show;
    public bool interact;
    public bool highlight;

    ActivateMessage(bool show, bool interact, bool highlight)
    {
        this.show = show;
        this.interact = interact;
        this.highlight = highlight;
    }

	public static ActivateMessage Hide()
	{
		return new ActivateMessage(false, false, false);
	}

    public static ActivateMessage Activate()
    {
        return new ActivateMessage(true, true, false);
    }

    public static ActivateMessage ShowTrail()
    {
        return new ActivateMessage(true, false, false);
    }

    public static ActivateMessage Highlight()
    {
        return new ActivateMessage(true, true, true);
    }
}
