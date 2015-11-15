using UnityEngine;
using System.Collections;

public class ThreshBehaviour : MonoBehaviour {

	public GameObject hookPrefab;

	private GameObject hookHand;
	private Vector3 positionThrow;
	public float speed = 15.0f, maxRange = 0;
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

	public void StartHookThrow(){
		EventManager.HandleMessage("OnHookCreated");
		positionThrow = Input.mousePosition;
	}
	
	public void HookThrow() {
		float angle;
		Vector3 hookPos = hookHand.transform.position;
		GameObject hookInstance = Instantiate (hookPrefab, hookPos, Quaternion.identity) as GameObject;
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(positionThrow);
		angle = Mathf.Atan2((mousePos.x - hookPos.x), (mousePos.y - hookPos.y)) * Mathf.Rad2Deg;
		hookInstance.transform.Rotate (0, 0, -angle);
		hookInstance.GetComponent<Rigidbody2D>().velocity = hookInstance.transform.up * speed;
	}
}
