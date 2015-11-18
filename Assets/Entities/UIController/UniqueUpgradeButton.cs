using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeButton : MonoBehaviour {
	
	private UniqueUpgradeController upgradeController;
	
	public GameObject bounceButton;
	public GameObject multipleHookButton;

	private Text bounceCostText;
	private Text multipleHookCostText;

	void Awake () {
		InitializeButtonsText();

		upgradeController = GameObject.FindObjectOfType<UniqueUpgradeController>();
		if(!upgradeController){
			Debug.LogError("Can't find the UniqueUpgradeController");
		}
	}
	public void OnBouceUpgradePressed(){
		if(upgradeController.BounceUpgrade()){
			bounceButton.GetComponentInChildren<Button>().interactable = false;
		}
	}
	public void OnMultipleHooksUpgradePressed(){
		if(upgradeController.MultipleHooksUpgrade()){
			multipleHookButton.GetComponentInChildren<Button>().interactable = false;
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
		if(InitializeButtonsText()){
			// Set the cost's value
			bounceCostText.text = upgradeController.GetBounceCost().ToString();
			multipleHookCostText.text = upgradeController.GetMultipleHookCost().ToString();
		}
	}
}
