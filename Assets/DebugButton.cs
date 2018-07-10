using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
	public void DebugMessage(string message)
	{
		Debug.LogFormat("Message {0}", message);
	}
}
