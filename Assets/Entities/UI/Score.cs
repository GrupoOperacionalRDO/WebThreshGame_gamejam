using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;
	public GameObject scoreTxt;

	// Use this for initialization
	void Start () {
		EventManager.AddListener ("OnEnemyDestroyed", this.gameObject);
	}

	private void OnEnemyDestroyed (){
		score ++;
		scoreTxt.GetComponent<Text> ().text = "Score: " + score;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
