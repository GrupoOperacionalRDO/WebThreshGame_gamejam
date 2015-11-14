using UnityEngine;
using System.Collections;

public class ThreshThrow : MonoBehaviour {

	const string HOOK_THROW = "Throwing";

	private ThreshBehaviour thresh;
	private Animator animator;

	void Start(){
		thresh = GetComponentInParent<ThreshBehaviour>();
		animator = GetComponent<Animator>();
	}

	public void SetThrowing(bool th){
		animator.SetBool(HOOK_THROW, th);
	}

	void HookThrow(){
		thresh.HookThrow();
	}
}
