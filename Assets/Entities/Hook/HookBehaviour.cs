using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {

	private ThreshBehaviour thresh;
	private LineRenderer lineRender;
	private GameObject hookHand;
	private GameObject hookCord;

	void Configure(){
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		hookCord = GameObject.Find("HookLinePoint");
		lineRender = GetComponent<LineRenderer> ();
		hookHand = thresh.GetHandHook();
		lineRender.SetPosition(0, hookHand.transform.position);
		lineRender.SetPosition (1, hookCord.transform.position);
	}

	void Start(){
		Configure ();
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
		if (transform.position.y < thresh.maxRange) { 
			DestroyHook ();
		}
	}

	void DestroyHook(){
		EventManager.HandleMessage("OnHookDestroyed");
		Destroy (this.gameObject);
	}
}
