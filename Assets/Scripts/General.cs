using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class General : MonoBehaviour {
	/// <summary>
	/// Cast a ray to test if Input.mousePosition is over any UI object in EventSystem.current. This is a replacement
	/// for IsPointerOverGameObject() which does not work on Android in 4.6.0f3
	/// </summary>
	public static bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
	/// <summary>
	/// Cast a ray to test if screenPosition is over any UI object in canvas. This is a replacement
	/// for IsPointerOverGameObject() which does not work on Android in 4.6.0f3
	/// </summary>
	public static bool IsPointerOverUIObject(Canvas canvas, Vector2 screenPosition) {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = screenPosition;
		
		GraphicRaycaster uiRaycaster = canvas.gameObject.GetComponent<GraphicRaycaster>();
		List<RaycastResult> results = new List<RaycastResult>();
		uiRaycaster.Raycast(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}
