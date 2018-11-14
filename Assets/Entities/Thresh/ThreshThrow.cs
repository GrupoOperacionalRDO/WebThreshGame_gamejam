using System.Collections;
using UnityEngine;

public class ThreshThrow : MonoBehaviour {

	const string HOOK_THROW = "Throwing";

	private ThreshBehaviour thresh;
	private Animator animator;

	void Awake() {
		thresh = GetComponentInParent<ThreshBehaviour>();
		animator = GetComponent<Animator>();
		
		EventManager.AddListener("OnHookCreated", this.OnHookCreated);
		EventManager.AddListener("OnHookDestroyed", this.OnHookDestroyed);
	}

	void OnDisable() {
		EventManager.RemoveListener("OnHookCreated", this.OnHookCreated);
		EventManager.RemoveListener("OnHookDestroyed", this.OnHookDestroyed);
	}

	void OnHookCreated(){
		animator.SetBool(HOOK_THROW, true);
	}

	void OnHookDestroyed(){
		animator.SetBool(HOOK_THROW, false);
	}

	void HookThrow(){
		thresh.HookThrow();
	}
}
