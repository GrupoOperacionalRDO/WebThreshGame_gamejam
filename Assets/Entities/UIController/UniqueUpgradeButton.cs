using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeButton : MonoBehaviour {
	
	private GameObject upgradeController;
	
	public GameObject bounceButton;

	private Text bounceCostText;

	void Awake () {
		InitializeButtonsText();

		upgradeController = GameObject.Find("UpgradeController");
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

	void Update () {
		UpgradeController uc = upgradeController.GetComponent<UpgradeController>();

		if(InitializeButtonsText()){
			// Set the cost's value
			bounceCostText.text = uc.GetRangeCost().ToString();
		}
	}
}
