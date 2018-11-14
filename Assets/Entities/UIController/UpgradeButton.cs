using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButton : MonoBehaviour {
	
	private UpgradeController upgradeController;
	
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
		upgradeController = GameObject.FindObjectOfType<UpgradeController>();
		if (!upgradeController) {
			Debug.LogError("Can't find the UpgradeController");
		}
		
		InitializeButtonsText();
	}

	void InitializeButtonsText() {
		RangeButtonInitialize();
		SpeedButtonInitialize();
		IncomeButtonInitialize();
	}

	void RangeButtonInitialize() {
        Button btn = rangeButton.transform.Find("Plus").GetComponent<Button>();
        btn.onClick.AddListener(() => upgradeController.UpgradeRange());

		rangeLevelText = rangeButton.transform.Find("LevelPanel/LevelText").GetComponent<Text>();
		rangeCostText = rangeButton.transform.Find("ValuePanel/ValueText").GetComponent<Text>();
	}
	
	void SpeedButtonInitialize() {
        Button btn = speedButton.transform.Find("Plus").GetComponent<Button>();
        btn.onClick.AddListener(() => upgradeController.UpgradeSpeed());

        speedLevelText = speedButton.transform.Find("LevelPanel/LevelText").GetComponent<Text>();
        speedCostText = speedButton.transform.Find("ValuePanel/ValueText").GetComponent<Text>();
	}

	void IncomeButtonInitialize() {
        Button btn = incomeButton.transform.Find("Plus").GetComponent<Button>();
        btn.onClick.AddListener(() => upgradeController.UpgradeIncome());

        incomeLevelText = incomeButton.transform.Find("LevelPanel/LevelText").GetComponent<Text>();
        incomeCostText = incomeButton.transform.Find("ValuePanel/ValueText").GetComponent<Text>();
	}

	void Update () {
		// Set the cost's value
		rangeCostText.text = upgradeController.RangeCost.ToString();
		speedCostText.text = upgradeController.SpeedCost.ToString();
		incomeCostText.text = upgradeController.IncomeCost.ToString();
		// Set the level's value
		rangeLevelText.text = upgradeController.RangeLevel.ToString();
		speedLevelText.text = upgradeController.SpeedLevel.ToString();
		incomeLevelText.text = upgradeController.IncomeLevel.ToString();
	}
}
