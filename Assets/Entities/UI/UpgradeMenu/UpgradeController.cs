using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {
	[SerializeField] private ThreshBehaviour thresh;
	public Score scr;

	// Use this for initialization
	void Awake () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scr = GameObject.FindObjectOfType<Score> ();
	}

	public void OnSpeedButtonPress(){

		if (scr.score >= 2) {
			thresh.speed += 10;
			scr.score -= 2;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
