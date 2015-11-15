using UnityEngine;
using System.Collections;

public class SecondaryHookBehaviour : HookBehaviour {
	private HookBehaviour[] hook;
	// Use this for initialization
	void Awake() {
		base.Configure();
	}
	void ParentInstance(){
		if (hook.Length < 3) {
			this.DestroyHook();
		}
	}
	// Update is called once per frame
	void Update () {
		base.Update ();
		hook = GameObject.FindObjectsOfType<HookBehaviour> ();
		ParentInstance ();
	}
}
