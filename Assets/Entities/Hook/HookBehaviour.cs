using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {
	private ThreshBehaviour thresh;
	private LineRenderer lineRender;
	public int[] elements;

	void Configure(){
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		lineRender = GetComponent<LineRenderer> ();
 		lineRender.SetPosition(0, thresh.transform.position);
		lineRender.SetPosition (1, transform.position);
	}

	void Start(){
		Configure ();
	}
	// Update is called once per frame
	void Update () {
		lineRender.SetPosition (1, transform.position);

	}
		
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
