using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public float multiplier = 1f;

	void Start () {
		Vector3 newSize = General.GetCameraSize() * multiplier;
		GetComponent<BoxCollider2D> ().size = newSize;
	}

	void OnTriggerExit2D(Collider2D collision){
		EventManager.HandleMessage ("OnWallHit");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
