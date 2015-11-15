using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	private static Dictionary<string, List<GameObject>> listenerDic = null;

	public static void AddListener(string methodName, GameObject listener){
		if(listenerDic == null){
			listenerDic = new Dictionary<string, List<GameObject>>();
		}

		if(!listenerDic.ContainsKey(methodName)){
			listenerDic.Add(methodName, new List<GameObject>());
		}
		// If already 
		if(listenerDic[methodName].Contains(listener)){
			return;
		}
		listenerDic[methodName].Add(listener);
	}

	public static void HandleMessage(string methodName){
		if(!listenerDic.ContainsKey(methodName)){
			return;
		}
		foreach(GameObject go in listenerDic[methodName]){
			go.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
			print ("Method: " + methodName + " Ob:" + go.name);
		}
	}
}
