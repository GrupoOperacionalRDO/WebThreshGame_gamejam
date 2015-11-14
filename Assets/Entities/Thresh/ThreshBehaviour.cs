using UnityEngine;
using System.Collections;

public class ThreshBehaviour : MonoBehaviour {

	public GameObject hookPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void HookThrow() {
		float angle;

		GameObject hookInstance = Instantiate (hookPrefab, transform.position, Quaternion.identity) as GameObject;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	
		angle = Mathf.Atan2((mousePos.x - transform.position.x), (mousePos.y - transform.position.y)) * Mathf.Rad2Deg;

		hookInstance.transform.Rotate (0, 0, -angle);


		hookInstance.GetComponent<Rigidbody2D>().velocity = hookInstance.transform.up * 15;

		
	}

	void Update () {

		if (Input.GetButtonDown("Fire1")){
			if (GameObject.FindObjectsOfType<HookBehaviour>().Length == 0){
			HookThrow();
			}
		}
	}
}
