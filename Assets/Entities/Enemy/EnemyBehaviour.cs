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

	public void DestroyEnemy(){
		EventManager.HandleMessage("OnEnemyDestroyed");
		Destroy(this.gameObject);
	}

	void OnBecameInvisible(){
		DestroyEnemy();
	}
}
