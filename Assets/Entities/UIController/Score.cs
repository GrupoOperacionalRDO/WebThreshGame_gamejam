using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;
	private Text scoreTxt;

	public void SetScore(int scr){
		score = scr;
	}

	public int GetScore(){
		return score;
	}
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
	}

	void Update(){
		scoreTxt.text = "Score: " + score;
	}
}
