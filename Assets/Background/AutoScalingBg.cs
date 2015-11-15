using UnityEngine;
using System.Collections;

public class AutoScalingBg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float quadHeight = Camera.main.orthographicSize * 2.0f;
		float quadWidth = quadHeight * Screen.width / Screen.height;
		this.GetComponent<Transform>().localScale = new Vector3(quadWidth, quadHeight, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
