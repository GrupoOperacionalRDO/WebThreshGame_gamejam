using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Sprite[] sprite;

	private SpriteRenderer spriteRenderer;

	void Start () {
		GameObject parent = GameObject.Find ("Enemies");
		if(!parent){
			parent = new GameObject("Enemies");
		}
		transform.parent = parent.transform;

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprite[Random.Range(0, sprite.Length)];
	}

	public void DestroyEnemy(){
		EventManager.HandleMessage("OnEnemyDestroyed");
		Destroy(this.gameObject);
	}

	void OnBecameInvisible(){
		DestroyEnemy();
	}
}
