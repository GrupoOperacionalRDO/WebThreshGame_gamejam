using UnityEngine;
using System.Collections;

public class ThreshStartMenu : MonoBehaviour {

	public float paddle = 2f;

	void Start()
	{
		Vector3 bounds = General.GetCameraSize();
		float leftBound = -(bounds.x / 2) + paddle;
		Vector3 pos = transform.position;
		pos.x = leftBound;
		transform.position = pos;
	}
	
}
