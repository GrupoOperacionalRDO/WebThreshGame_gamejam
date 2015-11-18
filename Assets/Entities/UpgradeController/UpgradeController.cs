using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {

	private ThreshBehaviour thresh;
	private Score scoreController;

	private int rangeCost = 2;
	private int speedCost = 2;
	private int incomeCost = 2;

	private int rangeLevel = 0;
	private int speedLevel = 0;
	private int incomeLevel = 0;

	void Awake () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scoreController = GameObject.FindObjectOfType<Score>();
	}

	public int GetRangeCost(){
		return rangeCost;
	}
	public int GetSpeedCost(){
		return speedCost;
	}
	public int GetIncomeCost(){
		return incomeCost;
	}
	
	public int GetRangeLevel(){
		return rangeLevel;
	}
	public int GetSpeedLevel(){
		return speedLevel;
	}
	public int GetIncomeLevel(){
		return incomeLevel;
	}

	public bool UpgradeSpeed(){
		int score = scoreController.GetScore();
		if ((score - speedCost) >= 0) {
			scoreController.SetScore (score - speedCost);
			thresh.speed += 0.5f;
			speedLevel++;
			return true;
		}
		return false;
	}
	
	public bool UpgradeIncome(){
		int score = scoreController.GetScore();
		if ((score - incomeCost) >= 0) {
			scoreController.SetScore (score - incomeCost);
			thresh.value += 1;
			incomeLevel++;
			return true;
		}
		return false;
	}

	public bool UpgradeRange(){
		int score = scoreController.GetScore();
		if ((score - rangeCost) >= 0) {
			scoreController.SetScore(score - rangeCost);
			thresh.maxRange += 3f;
			rangeLevel++;
			return true;
		}
		return false;
	}
}
