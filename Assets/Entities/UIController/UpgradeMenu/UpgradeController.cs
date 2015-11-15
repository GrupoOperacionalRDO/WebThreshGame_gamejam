using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {
	private ThreshBehaviour thresh;
	public GameObject scoreGameObject;
	private int score;
	private Score scr;

	private int rangeCost = 2;
	private int speedCost = 2;
	private int incomeCost = 2;

	private int rangeLevel = 0;
	private int speedLevel = 0;
	private int incomeLevel = 0;

	void Awake () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
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

	 void ScoreHandler(){
		scr = scoreGameObject.GetComponent<Score> ();
		score = scr.GetScore ();
	}

	public void UpgradeSpeed(){
		ScoreHandler ();
		if ((score - speedCost) >= 0) {
			scr.SetScore (score - speedCost);
			thresh.speed += 0.5f;
			speedLevel++;
		}
	}
	
	public void UpgradeIncome(){
		ScoreHandler ();
		if ((score - incomeCost) >= 0) {
			scr.SetScore (score - incomeCost);
			thresh.value += 1;
			incomeLevel++;
		}
	}

	public void UpgradeRange(){
		ScoreHandler ();
		if ((score - rangeCost) >= 0) {
			scr.SetScore(score - rangeCost);
			thresh.maxRange += 3f;
			rangeLevel++;
		}
	}
}
