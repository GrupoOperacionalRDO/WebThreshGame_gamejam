using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private ThreshBehaviour thresh;
	private int score = 100;
	private Text scoreText;
	
	void Awake () {
		EventManager.AddListener ("OnEnemyDestroyed", this.OnEnemyDestroyed);
		
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		if (!scoreText) {
			Debug.LogError("Can't find the ScoreText");
		}
	}

	public bool UseScore(int amount) {
		if((score - amount) < 0) return false;
		
        score -= amount;
		return true;
	}

	private void OnEnemyDestroyed () {
		score += thresh.value; 
	}

	void FixedUpdate() {
		scoreText.text = "Score: " + score;
	}

	public void Teste() {
		print ("Teste");
	}
}
