using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;
	private Text scoreTxt;

	// Use this for initialization
	void Start () {
		EventManager.AddListener ("OnEnemyDestroyed", this.gameObject);
		scoreTxt = GameObject.Find ("ScoreText").GetComponent<Text>();
		if(!scoreTxt){
			Debug.LogError("Can't find ScoreText");
		}
	}

	private void OnEnemyDestroyed (){
		score ++;
		scoreTxt.text = "Score: " + score;
	}
}
