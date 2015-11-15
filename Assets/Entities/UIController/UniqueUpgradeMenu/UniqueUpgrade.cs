using UnityEngine;
using System.Collections;

public class UniqueUpgrade : MonoBehaviour {
	private ThreshBehaviour thresh;
	public GameObject scoreGameObject;

	private int score;
	private Score scr;

	// Use this for initialization
	void Start () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ScoreHandler(){
		scr = scoreGameObject.GetComponent<Score> ();
		score = scr.GetScore ();
	}

	public void BounceUpgrade(){
		ScoreHandler ();
		if ((score - 2) >= 0) {
			scr.SetScore (score - 2);
			thresh.bounce = true;
		}
	}

}