using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class BulletBehaviour : MonoBehaviour {
	[Header("Movement Parameters")]
	public Transform playerPos;
	public float radius;
	public float distance;
	public float rotateDuration;
	public float initAnimDuration;		// Initial animation already ensures no collision for 2 seconds, no delay at shooting will be added

	[Header("Hit Status Parameter")]
	public Material readyTexture;

	private float startTime;

	// Clockwise or anticlockwise rotation of the bullet is chosen at random
	// Bullet on bullet collision eliminates both bullets without any score change
	private int direction;

	void Start() {
		// Initializing public variables so that they work as prefabs
		playerPos = GameObject.Find("Player").GetComponent<Transform>();
		radius = 0.7f;
		distance = 2.5f;
		rotateDuration = 0.6f;
		initAnimDuration = 2;


		direction = (Random.Range(0, 2) == 0)? 1: -1;
		startTime = Time.time;
		GetComponent<Collider>().enabled = false;
		Invoke("ShowReady", 2f);
	}

	void Update() {
		float angle = (Time.time - startTime) / rotateDuration;
		Vector3 offset = (radius * new Vector3(Mathf.Cos(angle), direction * Mathf.Sin(angle), 0)) + new Vector3(0, 0, distance);
		float animFactor = Mathf.Clamp01((Time.time - startTime) / initAnimDuration);
		
		transform.position = playerPos.position + offset * animFactor;
		transform.rotation = Quaternion.Euler(0, 0, direction * angle * 180 / Mathf.PI);
	}

	void ShowReady() {
		GetComponent<Collider>().enabled = true;
		GetComponent<Renderer>().material = readyTexture;
	}

	void OnCollisionEnter() {
		Destroy(gameObject);
	}
}