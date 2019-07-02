using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	private ThreshBehaviour thresh;
	private int score = 10;
	private Text scoreText;
	
	void Awake ()
	{
		EventManager.AddListener ("OnEnemyDestroyed", this.OnEnemyDestroyed);
		
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();

    #if UNITY_EDITOR
		score = 100;
	#endif
		
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		if (!scoreText)
		{
			Debug.LogError("Can't find the ScoreText");
		}
	}

		void Update()
		{
			scoreText.text = "Score: " + score;
    #if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Q))
			{
				Debug.Log("Score cheat!");
				score += 100;
			}
	#endif
		}

	public bool UseScore(int amount)
	{
		if((score - amount) < 0) return false;
		
        score -= amount;
		return true;
	}

	private void OnEnemyDestroyed ()
	{
		score += thresh.value; 
	}

}
