using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	void Start () {
		GameObject parent = GameObject.Find ("Enemies");
		if(!parent){
			parent = new GameObject("Enemies");
		}
		transform.parent = parent.transform;
	}

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
