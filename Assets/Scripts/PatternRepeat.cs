using UnityEditor;
using UnityEngine;

public class PatternRepeat : MonoBehaviour {
	public Transform[] sourceClouds;
	public Transform[] targetClouds;
	public Vector3 offset;
	public bool tryRepeat;
	private bool panelVisible;

	void Start() {
		for(int i = 0; i < sourceClouds.Length; i++) {
			targetClouds[i].position = sourceClouds[i].position + offset;
		}
	}

	/*void Update() {
		if(!panelVisible && tryRepeat) {
			for(int i = 0; i < sourceClouds.Length; i++) {
				targetClouds[i].position = sourceClouds[i].position + offset;
			}
			tryRepeat = false;
		}
	}*/

	void OnBecameInvisible() {
		panelVisible = false;
	}
	void OnBecameVisible() {
		panelVisible = true;
	}
}