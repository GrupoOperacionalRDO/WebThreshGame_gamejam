using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AutoScalingBg : MonoBehaviour {

	void OnGUI () {
		this.GetComponent<Transform>().localScale = General.GetCameraSize();
	}
}
