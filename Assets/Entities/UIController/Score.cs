using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private ThreshBehaviour thresh;
	private GameObject upgradeController;
	private int score;
	private Text scoreTxt;

	public Text rangeLevelText;
	public Text speedLevelText;
	public Text incomeLevelText;

	public void SetScore(int scr){
		score = scr;
	}

	public int GetScore(){
		return score;
	}

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
	}

	private void OnEnemyDestroyed (){
		score += thresh.value; 
	}

	void FixedUpdate(){
		scoreTxt.text = "Score: " + score;
		// Set the cost's value
		UpgradeController uc = upgradeController.GetComponent<UpgradeController>();
		rangeLevelText.text = uc.GetRangeCost().ToString();
		speedLevelText.text = uc.GetSpeedCost().ToString();
		incomeLevelText.text = uc.GetIncomeCost().ToString();
	}
}
