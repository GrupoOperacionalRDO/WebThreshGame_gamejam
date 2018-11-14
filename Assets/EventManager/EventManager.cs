using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void Listener ();

	private static Dictionary<string, List<GameObject>> listenerGameObject = null;
	private static Dictionary<string, List<Listener>> listenerCallback = null;

	public static void AddListener(string eventName, Listener callback) {
		if (listenerCallback == null) {
			listenerCallback = new Dictionary<string, List<Listener>>();
		}

		if (!listenerCallback.ContainsKey(eventName)) {
			listenerCallback.Add(eventName, new List<Listener>());
		}
		// If already 
		if (listenerCallback[eventName].Contains(callback)) {
			return;
		}
		listenerCallback[eventName].Add(callback);
	}

	public static void RemoveListener(string eventName, Listener callback) {
		if (listenerCallback == null) {
			return;
		}

		if (!listenerCallback.ContainsKey(eventName)) {
			return;
		}
		// If already 
		listenerCallback[eventName].Remove(callback);
	}

	// public static void AddListener(string methodName, GameObject listener) {
	// 	if (listenerGameObject == null) {
	// 		listenerGameObject = new Dictionary<string, List<GameObject>>();
	// 	}

	// 	if (!listenerGameObject.ContainsKey(methodName)) {
	// 		listenerGameObject.Add(methodName, new List<GameObject>());
	// 	}
	// 	// If already 
	// 	if (listenerGameObject[methodName].Contains(listener)) {
	// 		return;
	// 	}
	// 	listenerGameObject[methodName].Add(listener);
	// }

	public static void HandleMessage(string methodName) {
		if (listenerGameObject.ContainsKey(methodName)) {

			foreach (GameObject go in listenerGameObject[methodName]) {
				if (go == null) {
					continue;
				}
				go.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
			}

		}

		if (listenerCallback.ContainsKey(methodName)) {

			foreach (Listener callback in listenerCallback[methodName]) {
				if (callback == null) {
					continue;
				}
				callback();
			}

		}
	}
}
