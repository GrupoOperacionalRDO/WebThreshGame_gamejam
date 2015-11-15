using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {
	private ThreshBehaviour thresh;
	public GameObject scrObject;
	private int score;
	private Score scr;

	// Use this for initialization
	void Awake () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
	}

	void ScoreHandler(){
		scr = scrObject.GetComponent<Score> ();
		score = scr.GetScore ();
	}

	public void OnSpeedButtonPress(){
		ScoreHandler ();
		if ((score - 2) >= 0) {
			scr.SetScore (score - 2);
			thresh.speed += 10;

		}
	}
	
	public void OnSoulButtonPress(){
		ScoreHandler ();
		if ((score - 2) >= 0) {
			scr.SetScore (score - 2);
			thresh.value += 1;
			
		}
	}

	public void OnRangeButtonPress(){
		ScoreHandler ();
		if ((score - 2) >= 0) {
			scr.SetScore(score -2);
			thresh.maxRange -= 0.5f;
		}
	}
}
