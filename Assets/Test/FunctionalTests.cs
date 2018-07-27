using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FunctionalTests
{
	[UnityTest]
	public IEnumerator TestButtonHasInputFocus()
	{
		yield return SceneManager.LoadSceneAsync("TestMenu");
        yield return null;
        Assert.IsNotNull(EventSystem.current.currentSelectedGameObject, "no button selected");
        yield return SceneManager.UnloadSceneAsync("TestMenu");
	}

	[UnityTest]
	public IEnumerator TestButtonDoesNotLoseInputFocus()
	{
		yield return SceneManager.LoadSceneAsync("TestMenu");
        yield return null;
        yield return null;
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        Assert.IsNotNull(selected, "no button selected");
        CanvasGroup canvasGroup = selected.GetComponentInParent<CanvasGroup>();
        Assert.IsNotNull(canvasGroup, "button is not controlled by a CanvasGroup");
        Assert.IsTrue(canvasGroup.interactable, "CanvasGroup is not interactable");
        AxisEventData axisEvent = new AxisEventData(EventSystem.current);
        axisEvent.moveDir = MoveDirection.Up;
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, axisEvent, ExecuteEvents.moveHandler);
        selected = EventSystem.current.currentSelectedGameObject;
        Assert.AreEqual(selected.GetComponentInParent<CanvasGroup>(), canvasGroup, "the CanvasGroup changed after navigation");
        yield return SceneManager.UnloadSceneAsync("TestMenu");
	}
}
