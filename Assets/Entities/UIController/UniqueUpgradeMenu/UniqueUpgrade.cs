using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgrade : MonoBehaviour {
	private ThreshBehaviour thresh;
	public GameObject scoreGameObject;
	
	public GameObject bounceButton;
	public GameObject multipleHookButton;

	private int score;
	private Score scr;
	
	private int bounceCost = 2;
	private int multipleHookCost = 2;

	void Start () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
	}

	public int GetBounceCost(){
		return bounceCost;
	}
	public int GetMultipleHookCost(){
		return multipleHookCost;
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
		if ((score - bounceCost) >= 0) {
			scr.SetScore (score - bounceCost);
			thresh.bounce = true;
			bounceButton.GetComponentInChildren<Button>().interactable = false;
		}
	}

	public void MultipleHooksUpgrade(){
		if (thresh.multipleHooks) {
			return;
		}

		ScoreHandler ();
		if ((score - multipleHookCost) >= 0) {
			scr.SetScore (score - multipleHookCost);
			thresh.multipleHooks = true;
			multipleHookButton.GetComponentInChildren<Button>().interactable = false;
		}
	}
}