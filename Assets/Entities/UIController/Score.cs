using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private ThreshBehaviour thresh;
	private int score = 100;
	private Text scoreTxt;
	
	
	void Awake () {
		EventManager.AddListener ("OnEnemyDestroyed", this.OnEnemyDestroyed);
		
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		
		scoreTxt = GameObject.Find ("ScoreText").GetComponent<Text>();
		if(!scoreTxt){
			Debug.LogError("Can't find the ScoreText");
		}
	}

	public void SetScore(int scr){
		score = scr;
	}

	public int GetScore(){
		return score;
	}

	private void OnEnemyDestroyed (){
		score += thresh.value; 
	}

	void FixedUpdate(){
		scoreTxt.text = "Score: " + score;
	}

	public void Teste(){
		print ("Teste");
	}
}
