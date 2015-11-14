using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {
	
	public GameObject enemyPrefab;

	private float timer;
	private float minX = -21.0f, minY = -5.0f, maxX = -19.0f, maxY = 4.0f, speed = 8;

	// Use this for initialization
	void Start () {
		if (!enemyPrefab) {
			Debug.LogError("No instance of enemy found");
		}
		InstantiateEnemy ();
	}
	void aeCaraih(){
		print (name);
	}

	void InstantiateEnemy(){

		Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
		
		GameObject enemy = Instantiate (enemyPrefab, position, Quaternion.identity) as GameObject;
		
		enemy.GetComponent<Rigidbody2D> ().velocity = enemy.transform.right * Random.Range (3,10);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 0.5) {
			InstantiateEnemy();

			timer = 0;
		}
	}
}
