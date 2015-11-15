using UnityEngine;
using System.Collections;

public class ThrowHookSpace : MonoBehaviour {

	private ThreshBehaviour tresh;

	void Start () {
		tresh = GameObject.FindObjectOfType<ThreshBehaviour>();
	}

	void OnMouseDown(){
		if(CanCreateHook()){
			tresh.StartHookThrow();
		}
	}
	
	bool CanCreateHook(){
		if(GameObject.FindObjectsOfType<HookBehaviour>().Length > 0){
			return false;
		}
		return true;
	}

}
