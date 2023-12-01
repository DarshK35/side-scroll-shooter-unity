using Unity.Collections;
using UnityEngine;

public class CloudPattern : MonoBehaviour {
	[Header("Position Arguments")]
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	public float zValue;

	[Header("Arrangement Objects")]
	public Transform[] clouds;
	public PatternRepeat[] repeaters;

	[Header("Misc variables")]
	public Transform playerPos;
	
	void Start() {
		ArrangeClouds();
	}

	/*void Update() {
		if(playerPos.position.x >= 20) {
			ArrangeClouds();
			for(int i = 0; i < repeaters.Length; i++) {
				repeaters[i].tryRepeat = true;
			}
		}
	}*/

	public void ArrangeClouds() {
		for(int i = 0; i < clouds.Length; i++) {
			float yPos = Random.Range(yMin, yMax);
			float xPos = Random.Range(xMin, xMax);
			transform.position = new Vector3(xPos, yPos, zValue);
		}
	}
}