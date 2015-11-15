using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AutoScalingBg : MonoBehaviour {

	void OnGUI () {
		float quadHeight = Camera.main.orthographicSize * 2.0f;
		float quadWidth = quadHeight * Screen.width / Screen.height;
		this.GetComponent<Transform>().localScale = new Vector3(quadWidth, quadHeight, 1);
	}
}
