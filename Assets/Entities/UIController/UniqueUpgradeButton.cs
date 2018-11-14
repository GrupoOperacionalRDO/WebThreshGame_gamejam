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
		upgradeController = GameObject.FindObjectOfType<UniqueUpgradeController>();
		if (!upgradeController) {
			Debug.LogError("Can't find the UniqueUpgradeController");
		}

		InitializeButtonsText();
	}
	
	void InitializeButtonsText() {
		BounceButtonInitialize();
		MultipleHookButtonInitialize();
	}
	
	public void OnBouceUpgradePressed() {
		if (upgradeController.BounceUpgrade()) {
			bounceButton.GetComponentInChildren<Button>().interactable = false;
		}
	}
	
	public void OnMultipleHooksUpgradePressed() {
		if (upgradeController.MultipleHooksUpgrade()) {
			multipleHookButton.GetComponentInChildren<Button>().interactable = false;
		}
	}
	
	void BounceButtonInitialize() {
		bounceButton.transform.Find("UpgradeIcon").GetComponent<Button>().onClick.AddListener(this.OnBouceUpgradePressed);
		bounceCostText = bounceButton.transform.Find("ValuePanel/ValueText").GetComponent<Text>();
	}

	void MultipleHookButtonInitialize() {
		multipleHookButton.transform.Find("UpgradeIcon").GetComponent<Button>().onClick.AddListener(this.OnMultipleHooksUpgradePressed);
        multipleHookCostText = multipleHookButton.transform.Find("ValuePanel/ValueText").GetComponent<Text>();
	}

	void Update () {
		// Set the cost's value
		bounceCostText.text = upgradeController.BounceCost.ToString();
		multipleHookCostText.text = upgradeController.MultipleHookCost.ToString();
	}
}
