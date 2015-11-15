using UnityEngine;
using System.Collections;

public class UniqueUpgrade : MonoBehaviour {
	private ThreshBehaviour thresh;
	public GameObject scoreGameObject;

	private int score;
	private Score scr;
	
	private int bounceCost = 2;

	void Start () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
	}

	public int GetBounceCost(){
		return bounceCost;
	}

	void ScoreHandler(){
		scr = scoreGameObject.GetComponent<Score> ();
		score = scr.GetScore ();
	}

	public void BounceUpgrade(){
		if(thresh.bounce){
			return;
		}
		ScoreHandler ();
		if ((score - 2) >= 0) {
			scr.SetScore (score - 2);
			thresh.bounce = true;
		}
	}

}