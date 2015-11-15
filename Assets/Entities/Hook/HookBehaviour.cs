﻿using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {

	protected ThreshBehaviour thresh;
	protected LineRenderer lineRender;
	protected Rigidbody2D thisRigidbody;
	protected GameObject hookHand;
	protected GameObject hookCord;

	protected float speed;
	protected float timeCounter;

	protected void Configure(){
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		hookCord = transform.FindChild("HookLinePoint").gameObject;
		thisRigidbody = GetComponent<Rigidbody2D>();
		lineRender = GetComponent<LineRenderer> ();
		hookHand = thresh.GetHandHook();
		lineRender.SetPosition(0, hookHand.transform.position);
		lineRender.SetPosition (1, hookCord.transform.position);
	}

	void Awake(){
		Configure ();
	}

	public void SetVelocity(float speed){
		if(!thisRigidbody){
			thisRigidbody = GetComponent<Rigidbody2D>();
		}
		this.speed = speed;
		thisRigidbody.velocity = transform.up * speed;
	}
	// Update is called once per frame

	protected void UpdateHandler(){
		MaxRangeDestroy ();
		lineRender.SetPosition (1, hookCord.transform.position);
		float distance = Vector2.Distance(hookHand.transform.position, hookCord.transform.position);
		lineRender.material.mainTextureScale = new Vector2(distance * 2,  1);
	}

	protected void Update () {
		UpdateHandler ();
	}

	protected void OnTriggerEnter2D(Collider2D coll){
		EnemyBehaviour en = coll.GetComponent<EnemyBehaviour>();
		if(en){
			en.DestroyEnemy();
			DestroyHook();
		}
	}

	protected void OnTriggerExit2D(Collider2D coll){
		Wall wall = coll.GetComponent<Wall>();
		if(wall){
			if (thresh.bounce) {
				float angle = 0;
				Vector3 bounds = General.GetCameraSize();
				float topBound = bounds.y / 2;
				float rightBound = bounds.x / 2;

				if(Mathf.Abs(transform.position.y) >= topBound){
					float ang = 90 - transform.eulerAngles.z;
					angle = transform.eulerAngles.z + (2 * ang);
				} else if(Mathf.Abs(transform.position.x) >= rightBound){
					angle = -transform.eulerAngles.z;
				}

				transform.eulerAngles = new Vector3(0, 0, angle);
				SetVelocity(speed);
			} else {
				DestroyHook();
			}
		}
	}

	protected void MaxRangeDestroy(){
		timeCounter += Time.deltaTime;
		float distance = speed * timeCounter;
		if (distance > thresh.maxRange) { 
			DestroyHook ();
		}
	}

	protected void DestroyHook(){
		EventManager.HandleMessage("OnHookDestroyed");
		Destroy (this.gameObject);
	}
}
