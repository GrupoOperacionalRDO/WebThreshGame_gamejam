using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButton : MonoBehaviour {
	
	private GameObject upgradeController;
	
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
		InitializeButtonsText();

		upgradeController = GameObject.Find("UpgradeController");
		if(!upgradeController){
			Debug.LogError("Can't find the UpgradeController");
		}
	}
	
	bool InitializeButtonsText(){
		bool getData = false;
		if(rangeButton.gameObject.activeInHierarchy){
			RangeButtonInitialize();
			getData = true;
		}
		if(speedButton.gameObject.activeInHierarchy){
			SpeedButtonInitialize();
			getData = true;
		}
		if(incomeButton.gameObject.activeInHierarchy){
			IncomeButtonInitialize();
			getData = true;
		}
		return getData;
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

	void Update () {
		UpgradeController uc = upgradeController.GetComponent<UpgradeController>();

		if(InitializeButtonsText()){
			// Set the cost's value
			rangeCostText.text = uc.GetRangeCost().ToString();
			speedCostText.text = uc.GetSpeedCost().ToString();
			incomeCostText.text = uc.GetIncomeCost().ToString();
			// Set the level's value
			rangeLevelText.text = uc.GetRangeLevel().ToString();
			speedLevelText.text = uc.GetSpeedLevel().ToString();
			incomeLevelText.text = uc.GetIncomeLevel().ToString();
		}
	}
}
