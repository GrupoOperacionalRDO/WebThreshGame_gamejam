using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {

	private ThreshBehaviour thresh;
	private LineRenderer lineRender;
	private Rigidbody2D thisRigidbody;
	private GameObject hookHand;
	private GameObject hookCord;

	private float speed;
	private float timeCounter;

	void Configure(){
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		hookCord = GameObject.Find("HookLinePoint");
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
	void Update () {
		MaxRangeDestroy ();
		lineRender.SetPosition (1, hookCord.transform.position);
		float distance = Vector2.Distance(hookHand.transform.position, hookCord.transform.position);
		lineRender.material.mainTextureScale = new Vector2(distance * 2,  1);
	}

	void OnTriggerEnter2D(Collider2D coll){
		EnemyBehaviour en = coll.GetComponent<EnemyBehaviour>();
		if(en){
			en.DestroyEnemy();
			DestroyHook();
		}
	}

	void MaxRangeDestroy(){
		timeCounter += Time.deltaTime;
		float distance = speed * timeCounter;
		if (distance > thresh.maxRange) { 
			DestroyHook ();
		}
	}

	void DestroyHook(){
		EventManager.HandleMessage("OnHookDestroyed");
		Destroy (this.gameObject);
	}
}
