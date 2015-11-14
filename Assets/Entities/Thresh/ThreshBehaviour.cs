using UnityEngine;
using System.Collections;

public class ThreshBehaviour : MonoBehaviour {

	public GameObject hookPrefab;

	private GameObject hookHand;

	void Start () {
		hookHand = GameObject.Find("ThreshHandHook");
		if(!hookHand){
			Debug.LogError("Can't find ThreshHandHook GameObject");
		}
	}	

	void HookThrow() {
		float angle;

		GameObject hookInstance = Instantiate (hookPrefab, hookHand.transform.position, Quaternion.identity) as GameObject;

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

	public GameObject GetHandHook(){
		return hookHand;
	}
}
