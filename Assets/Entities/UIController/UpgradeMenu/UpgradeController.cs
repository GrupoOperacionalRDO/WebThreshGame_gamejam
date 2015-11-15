using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {
	[SerializeField] private ThreshBehaviour thresh;
	public GameObject scrObject;
	

	// Use this for initialization
	void Awake () {
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();

	}

	public void OnSpeedButtonPress(){
		Score scr = scrObject.GetComponent<Score> ();
		int score = scr.GetScore ();

		if ((score - 2) >= 0) {
			scr.SetScore (score - 2);
			thresh.speed += 10;

		}
	}
	// Update is called once per frame
	void Update () {
	}
}
