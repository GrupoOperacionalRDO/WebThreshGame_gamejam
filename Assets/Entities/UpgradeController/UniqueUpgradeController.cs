using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeController : MonoBehaviour {

	private ThreshBehaviour thresh;
	private Score scoreController;
	
	private int bounceCost = 2;
	private int multipleHookCost = 2;

    public int BounceCost { get { return bounceCost; } }
    public int MultipleHookCost { get { return multipleHookCost; } }

	void Start () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scoreController = GameObject.FindObjectOfType<Score>();
	}

	public bool BounceUpgrade(){
		if(thresh.bounce) return false;
		
		if (scoreController.UseScore(bounceCost)) {
			thresh.bounce = true;
			return true;
		}
		
		return false;
	}

	public bool MultipleHooksUpgrade(){
		if (thresh.multipleHooks) return false;
		
		if (scoreController.UseScore(multipleHookCost)) {
			thresh.multipleHooks = true;
			return true;
		}
		
		return false;
	}
}