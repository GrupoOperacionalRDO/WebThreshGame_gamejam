using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeController : MonoBehaviour {

	private ThreshBehaviour thresh;
	private Score scoreController;
	
	private int bounceCost = 2;
	private int multipleHookCost = 2;

	void Start () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scoreController = GameObject.FindObjectOfType<Score>();
	}

	public int GetBounceCost(){
		return bounceCost;
	}
	public int GetMultipleHookCost(){
		return multipleHookCost;
	}

	public bool BounceUpgrade(){
		if(thresh.bounce){
			return false;
		}
		int score = scoreController.GetScore ();
		if ((score - bounceCost) >= 0) {
			scoreController.SetScore (score - bounceCost);
			thresh.bounce = true;
			return true;
		}
		return false;
	}

	public bool MultipleHooksUpgrade(){
		if (thresh.multipleHooks) {
			return false;
		}
		int score = scoreController.GetScore ();
		if ((score - multipleHookCost) >= 0) {
			scoreController.SetScore (score - multipleHookCost);
			thresh.multipleHooks = true;
			return true;
		}
		return false;
	}
}