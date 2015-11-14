using UnityEngine;
using System.Collections;

public class ThreshThrow : MonoBehaviour {

	const string HOOK_THROW = "Throwing";

	private ThreshBehaviour thresh;
	private Animator animator;

	void Start(){
		thresh = GetComponentInParent<ThreshBehaviour>();
		animator = GetComponent<Animator>();
		EventManager.AddListener("OnHookDestroyed", this.gameObject);
		EventManager.AddListener("OnHookCreated", this.gameObject);
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
