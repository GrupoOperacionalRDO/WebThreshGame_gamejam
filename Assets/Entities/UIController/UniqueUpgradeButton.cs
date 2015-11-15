using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeButton : MonoBehaviour {
	
	private GameObject upgradeController;
	
	public GameObject bounceButton;
	public GameObject multipleHookButton;

	private Text bounceCostText;
	private Text multipleHookCostText;

	void Awake () {
		InitializeButtonsText();

		upgradeController = GameObject.Find("UniqueUpgController");
		if(!upgradeController){
			Debug.LogError("Can't find the UpgradeController");
		}
	}
	
	bool InitializeButtonsText(){
		bool getData = false;
		if(bounceButton.gameObject.activeInHierarchy){
			BounceButtonInitialize();
			getData = true;
		}
		if(multipleHookButton.gameObject.activeInHierarchy){
			MultipleHookButtonInitialize();
			getData = true;
		}
		return getData;
	}
	
	void BounceButtonInitialize(){
		Text[] texts = bounceButton.GetComponentsInChildren<Text>();
		foreach(Text text in texts){
			switch(text.name){
			case "ValueText":
				bounceCostText = text;
				break;
			}
		}
	}
	void MultipleHookButtonInitialize(){
		Text[] texts = multipleHookButton.GetComponentsInChildren<Text>();
		foreach(Text text in texts){
			switch(text.name){
			case "ValueText":
				multipleHookCostText = text;
				break;
			}
		}
	}

	void Update () {
		UniqueUpgrade uc = upgradeController.GetComponent<UniqueUpgrade>();

		if(InitializeButtonsText()){
			// Set the cost's value
			bounceCostText.text = uc.GetBounceCost().ToString();
			multipleHookCostText.text = uc.GetMultipleHookCost().ToString();
		}
	}
}
