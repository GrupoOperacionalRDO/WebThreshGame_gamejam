using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D collision){
		EventManager.HandleMessage ("OnWallHit");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
