using UnityEngine;
using System.Collections;

public class SecondaryHookBehaviour : HookBehaviour {

	void Awake() {
		base.Configure();
	}

	protected override void Update () {
		base.Update ();
	}

	protected override void DestroyHook(){
		Destroy (this.gameObject);
	}
}
