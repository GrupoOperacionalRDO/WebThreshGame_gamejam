using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private ThreshBehaviour thresh;
	private GameObject upgradeController;
	private int score;
	private Text scoreTxt;

	public GameObject rangeButton;
	public GameObject speedButton;
	public GameObject incomeButton;

	private Text rangeLevelText;
	private Text speedLevelText;
	private Text incomeLevelText;

	private Text rangeCostText;
	private Text speedCostText;
	private Text incomeCostText;
	
	
	void Awake () {
		EventManager.AddListener ("OnEnemyDestroyed", this.gameObject);
		
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		
		scoreTxt = GameObject.Find ("ScoreText").GetComponent<Text>();
		if(!scoreTxt){
			Debug.LogError("Can't find the ScoreText");
		}
		
		upgradeController = GameObject.Find("UpgradeController");
		if(!upgradeController){
			Debug.LogError("Can't find the UpgradeController");
		}
		SpeedButtonInitialize();
		RangeButtonInitialize();
		IncomeButtonInitialize();
	}

	void SpeedButtonInitialize(){
		Text[] texts = speedButton.GetComponentsInChildren<Text>();
		foreach(Text text in texts){
			switch(text.name){
			case "LevelText":
				speedLevelText = text;
				break;
			case "ValueText":
				speedCostText = text;
				break;
			}
		}
	}
	void RangeButtonInitialize(){
		Text[] texts = rangeButton.GetComponentsInChildren<Text>();
		foreach(Text text in texts){
			switch(text.name){
			case "LevelText":
				rangeLevelText = text;
				break;
			case "ValueText":
				rangeCostText = text;
				break;
			}
		}
	}
	void IncomeButtonInitialize(){
		Text[] texts = incomeButton.GetComponentsInChildren<Text>();
		foreach(Text text in texts){
			switch(text.name){
			case "LevelText":
				incomeLevelText = text;
				break;
			case "ValueText":
				incomeCostText = text;
				break;
			}
		}
	}

	public void SetScore(int scr){
		score = scr;
	}

	public int GetScore(){
		return score;
	}

	private void OnEnemyDestroyed (){
		score += thresh.value; 
	}

	void FixedUpdate(){
		scoreTxt.text = "Score: " + score;
		// Set the cost's value
		UpgradeController uc = upgradeController.GetComponent<UpgradeController>();
		rangeCostText.text = uc.GetRangeCost().ToString();
		speedCostText.text = uc.GetSpeedCost().ToString();
		incomeCostText.text = uc.GetIncomeCost().ToString();
		// Set the level's value
		rangeLevelText.text = uc.GetRangeLevel().ToString();
		speedLevelText.text = uc.GetSpeedLevel().ToString();
		incomeLevelText.text = uc.GetIncomeLevel().ToString();
	}
}
