using UnityEngine;
using System.Collections;

public class ThreshBehaviour : MonoBehaviour {

	public GameObject hookPrefab;
	
	private ThreshThrow throwHook;
	private GameObject hookHand;
	private Vector3 positionThrow;

	void Start () {
		throwHook = GetComponentInChildren<ThreshThrow>();
		hookHand = GameObject.Find("ThreshHandHook");
		if(!hookHand){
			Debug.LogError("Can't find ThreshHandHook GameObject");
		}
	}	

	void Update () {
		if (Input.GetButtonDown("ThrowHook")){
			if (GameObject.FindObjectsOfType<HookBehaviour>().Length == 0){
				throwHook.SetThrowing(true);
				positionThrow = Input.mousePosition;
			}
		}
	}

	public GameObject GetHandHook(){
		return hookHand;
	}
	
	public void HookThrow() {
		float angle;
		Vector3 hookPos = hookHand.transform.position;
		GameObject hookInstance = Instantiate (hookPrefab, hookPos, Quaternion.identity) as GameObject;
		
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(positionThrow);
		
		angle = Mathf.Atan2((mousePos.x - hookPos.x), (mousePos.y - hookPos.y)) * Mathf.Rad2Deg;
		
		hookInstance.transform.Rotate (0, 0, -angle);
		
		hookInstance.GetComponent<Rigidbody2D>().velocity = hookInstance.transform.up * 15;
		
	}
}
