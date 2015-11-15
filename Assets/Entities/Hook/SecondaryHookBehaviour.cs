using UnityEngine;
using System.Collections;

public class SecondaryHookBehaviour : HookBehaviour {

	// Use this for initialization
	void Awake() {
		base.Configure();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHandler ();
	}
}
