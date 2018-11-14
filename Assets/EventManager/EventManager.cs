using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void Listener ();

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

	public static void HandleMessage(string eventName) {

		if (listenerCallback.ContainsKey(eventName)) {

			foreach (Listener callback in listenerCallback[eventName]) {
				if (callback == null) {
					continue;
				}
				callback();
			}

		}

	}
}
