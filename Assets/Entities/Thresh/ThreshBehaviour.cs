using UnityEngine;
using System.Collections;

public class ThreshBehaviour : MonoBehaviour {

	public GameObject hookPrefab, hookHand;
	private Vector3 positionThrow, hookPos;
	public float angle, speed = 15.0f, maxRange = 3;
	public int value = 1;

	void Start () {
		hookHand = GameObject.Find("ThreshHandHook");
		if(!hookHand){
			Debug.LogError("Can't find ThreshHandHook GameObject");
		}
	}	

	public GameObject GetHandHook(){
		return hookHand;
	}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			positionThrow = Input.mousePosition;
			CalculateAngle();
			if(CanCreateHook()){
				EventManager.HandleMessage("OnHookCreated");
			}
		}
	}

	bool CanCreateHook(){
		print (angle);
		if(GameObject.FindObjectsOfType<HookBehaviour>().Length > 0){
			return false;
		}else if (General.IsPointerOverUIObject()){
			return false;
		}else if (angle > 90 || angle < -90) {
			return true;
		}
		return false;
	}

	void CalculateAngle(){

		hookPos = hookHand.transform.position;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		angle = Mathf.Atan2((mousePos.x - hookPos.x), (mousePos.y - hookPos.y)) * Mathf.Rad2Deg;
	}

	public void HookThrow() {
			GameObject hookInstance = Instantiate (hookPrefab, hookPos, Quaternion.identity) as GameObject;
			hookInstance.transform.Rotate (0, 0, -angle);
			hookInstance.GetComponent<HookBehaviour> ().SetVelocity (speed);

	}
}
