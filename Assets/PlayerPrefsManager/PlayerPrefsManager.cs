using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string HIGH_SCORE_KEY = "high_score";

	// High score
	public static void SetHighScore(int score){
		if (score >= 0f) {
			PlayerPrefs.SetInt (HIGH_SCORE_KEY, score);
		} else {
			Debug.LogError("High score can't be a negative number!");
		}
	}
	public static int GetHighScore(){
		return PlayerPrefs.GetInt (HIGH_SCORE_KEY);
	}
}
