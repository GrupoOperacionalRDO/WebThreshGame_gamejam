﻿using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {

	private ThreshBehaviour thresh;
	private LineRenderer lineRender;
	private ThreshThrow throwHook;

	void Configure(){
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		throwHook = thresh.GetComponentInChildren<ThreshThrow>();
		lineRender = GetComponent<LineRenderer> ();
		GameObject hookHand = thresh.GetHandHook();
		lineRender.SetPosition(0, hookHand.transform.position);
		lineRender.SetPosition (1, transform.position);
	}

	void Start(){
		Configure ();
	}
	// Update is called once per frame
	void Update () {
		lineRender.SetPosition (1, transform.position);
	}

	void OnTriggerEnter2D(Collider2D coll){
		EnemyBehaviour en = coll.GetComponent<EnemyBehaviour>();
		if(en){
			Destroy (coll.gameObject);
			DestroyHook();
		}
	}

	void OnBecameInvisible(){
		DestroyHook();
	}

	void DestroyHook(){
		throwHook.SetThrowing(false);
		Destroy (this.gameObject);
	}
}
